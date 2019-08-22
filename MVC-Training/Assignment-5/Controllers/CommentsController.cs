using Assignment_5.Models;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace Assignment_5.Controllers
{
    public class CommentsController : Controller
    {
        #region Declarations
        /// <summary>The database</summary>
        private EmployeeContext db = new EmployeeContext();
        #endregion

        #region Index view
        /// <summary>Indexes this instance.</summary>
        /// <returns>Returns the list of comments</returns>
        public ActionResult Index()
        {
            return View(db.Comments.ToList());
        }
        #endregion

        #region Create method
        /// <summary>Creates this instance.</summary>
        public ActionResult Create()
        {
            return View();
        }

        /// <summary>Creates the specified comment.</summary>
        /// <param name="comment">The comment.</param>
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create([Bind(Include = "Id,Name,Comment1")] Comment comment)
        {
            StringBuilder sbComments = new StringBuilder();

            // Encode the text that is coming from comments textbox
            sbComments.Append(HttpUtility.HtmlEncode(comment.Comment1));

            // Only decode bold and underline tags
            sbComments.Replace("&lt;b&gt;", "<b>");
            sbComments.Replace("&lt;/b&gt;", "</b>");
            sbComments.Replace("&lt;u&gt;", "<u>");
            sbComments.Replace("&lt;/u&gt;", "</u>");
            comment.Comment1 = sbComments.ToString();

            // HTML encode the text that is coming from name textbox
            string strEncodedName = HttpUtility.HtmlEncode(comment.Name);
            comment.Name = strEncodedName;

            if (ModelState.IsValid)
            {
                db.Comments.Add(comment);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(comment);
        }
        #endregion

        #region Delete method
        /// <summary>Deletes the specified identifier.</summary>
        /// <param name="id">The identifier.</param>
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comment comment = db.Comments.Find(id);
            if (comment == null)
            {
                return HttpNotFound();
            }
            return View(comment);
        }

        /// <summary>Deletes the confirmed.</summary>
        /// <param name="id">The identifier.</param>
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Comment comment = db.Comments.Find(id);
            db.Comments.Remove(comment);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        #endregion

        #region Connection dispose method
        /// <summary>Releases unmanaged resources and optionally releases managed resources.</summary>
        /// <param name="disposing">true to release both managed and unmanaged resources; false to release only unmanaged resources.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
        #endregion
    }
}
