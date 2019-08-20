using Assignment_5.Models;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace Assignment_5.Controllers
{
    public class CommentsController : Controller
    {
        private EmployeeContext db = new EmployeeContext();

        // GET: Comments
        public ActionResult Index()
        {
            return View(db.Comments.ToList());
        }

        public ActionResult Create()
        {
            return View();
        }

        // POST: Comments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
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

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Comment comment = db.Comments.Find(id);
            db.Comments.Remove(comment);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
