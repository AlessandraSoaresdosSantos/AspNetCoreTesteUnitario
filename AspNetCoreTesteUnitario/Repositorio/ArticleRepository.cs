using AspNetCoreTesteUnitario.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreTesteUnitario.Repositorio
{
    public class ArticleRepository
    {
        public IEnumerable<Article> CarregarDados()
        {

            var article = new List<Article>()
            {
                new Article() { ArticleId=1, Title="Finanças 2018", Abstract="ABR-456-0987", Contents="Finanças/Brasil", CreatedDate=DateTime.Now},
                new Article() {ArticleId=2, Title="Economia -Principais pilares", Abstract="ABR-125-0800", Contents="Economia/Brasil", CreatedDate=DateTime.Now },
                new Article() {ArticleId=3, Title="Computação Moderna", Abstract="ABR-879-4158", Contents="Informática/Brasil", CreatedDate=DateTime.Now},
            };
            return article;
        }

        public IEnumerable<Article> AtualizarArtigo(Article article)
        {
            List<Article> articles = CarregarDados().ToList();

            List<Article> resultado = (from a in articles.AsEnumerable()
                                       where a.ArticleId == article.ArticleId
                                       select new Article
                                       {
                                           ArticleId = a.ArticleId,
                                           Title = a.Title,
                                           Abstract = a.Abstract,
                                           Contents = a.Contents,
                                           CreatedDate = a.CreatedDate
                                       }).ToList();

            return resultado;

        }
        public Article BuscaArtigo(int idArticle)
        {
            List<Article> articles = CarregarDados().ToList();

            Article resultado = articles.SingleOrDefault(_ => _.ArticleId == idArticle);

            return resultado;

        }

        public void DeletarArtigo(int? idArticle)
        {
            List<Article> articles = CarregarDados().ToList();

            articles.RemoveAll(_ => _.ArticleId == idArticle);
        }

        public IEnumerable<Article> InserirArtigo(Article article)
        {
            List<Article> articles = CarregarDados().ToList();
            articles.Add(article);

            return articles;

        }

    }
}
