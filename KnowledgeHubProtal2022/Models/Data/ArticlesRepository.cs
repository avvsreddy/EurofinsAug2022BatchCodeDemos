using KnowledgeHubProtal2022.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace KnowledgeHubProtal2022.Models.Data
{
    public class ArticlesRepository : IArticlesRepository
    {
        KnowledgeHubDbContext db = new KnowledgeHubDbContext();

        public void Approve(List<int> articleIds)
        {
            // TODO: need to optimize the logic
            foreach (var aid in articleIds)
            {
                var article = db.Articles.Find(aid);
                if (article != null)
                    article.IsApproved = true;
            }
            db.SaveChanges();
        }

        public Article GetArticle(int id)
        {
            throw new NotImplementedException();
        }

        public List<Article> GetArticlesForBrowse()
        {
            return db.Articles.Where(a => a.IsApproved).ToList();
        }

        public List<Article> GetArticlesForReview()
        {
            return db.Articles.Where(a => !a.IsApproved).ToList();
        }

        public void Reject(List<int> articleIds)
        {
            // TODO: need to optimize the logic
            foreach (var aid in articleIds)
            {
                var article = db.Articles.Find(aid);
                if (article != null)
                    db.Articles.Remove(article);
            }
            db.SaveChanges();
        }

        public List<Article> Search(string data)
        {
            throw new NotImplementedException();
        }

        public void Submit(Article article)
        {
            db.Articles.Add(article);
            db.SaveChanges();
        }
    }
}