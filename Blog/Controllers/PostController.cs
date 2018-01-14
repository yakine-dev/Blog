using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Blog.Models;

namespace Blog.Controllers
{
    public class PostController : Controller
    {
        // GET: Post
        public ActionResult Index()
        {
            var db = new ApplicationDbContext();
            var posts = db.Posts.ToList();
            return View(posts);
        }

        [HttpGet]
        public ActionResult Create()
        {
            var post = new Post();
            return View(post);
        }

        [HttpPost]
        public ActionResult Create(Post post)
        {
            var db = new ApplicationDbContext();
            post.DateCreation = DateTime.Now;
            post.DateModification = post.DateCreation;
            post.Supprimer = false;
            db.Posts.Add(post);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Update(int id)
        {
            var db = new ApplicationDbContext();
            var post = db.Posts.Find(id);
            if (post == null)
            {
                return HttpNotFound();
            }          
            return View(post);
        }
        [HttpPost]
        public ActionResult Update(Post post)
        {
            var db = new ApplicationDbContext();          
            var oldPost = db.Posts.Find(post.Id);
            if (oldPost==null)
            {
                return HttpNotFound();
            }
            oldPost.DateModification = DateTime.Now;
            oldPost.Titre = post.Titre;
            oldPost.Contenu = post.Contenu;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            var db = new ApplicationDbContext();
            var post = db.Posts.Find(id);
            if (post == null)
            {
                return HttpNotFound();
            }
            db.Posts.Remove(post);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}