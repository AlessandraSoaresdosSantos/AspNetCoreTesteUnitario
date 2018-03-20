using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCoreTesteUnitario.Models;
using AspNetCoreTesteUnitario.Repositorio;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreTesteUnitario.Controllers
{
    public class ArticlesController : Controller
    {
        // GET: Articles
        public ActionResult Index()
        {

            IEnumerable<Article> articles = new ArticleRepository().CarregarDados();
            return View(articles);
        }
        // GET: Articles/Details/5
        public IActionResult Details(int id)
        {

            Article article = new ArticleRepository().BuscaArtigo(id);

            return View(article);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create([Bind("Title, Abstract,Contents")] Article article)
        {
            if (ModelState.IsValid)
            {
                article.CreatedDate = DateTime.Now;
                new ArticleRepository().InserirArtigo(article);
                return RedirectToAction("Index");
            }
            return View(article);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            new ArticleRepository().DeletarArtigo(id);


            return RedirectToAction("Index");
        }

        // POST: Articles/Delete/5
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            new ArticleRepository().DeletarArtigo(id);


            return RedirectToAction("Index");
        }
    }
}