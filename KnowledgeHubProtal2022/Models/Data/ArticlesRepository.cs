using KnowledgeHubProtal2022.Models.Entities;
using System;
using System.Collections.Generic;

namespace KnowledgeHubProtal2022.Models.Data
{
    public class ArticlesRepository : IArticlesRepository
    {
        public void Approve(List<int> articleIds)
        {
            throw new NotImplementedException();
        }

        public Article GetArticle(int id)
        {
            throw new NotImplementedException();
        }

        public List<Article> GetArticlesForBrowse()
        {
            throw new NotImplementedException();
        }

        public List<Article> GetArticlesForReview()
        {
            throw new NotImplementedException();
        }

        public void Reject(List<int> articleIds)
        {
            throw new NotImplementedException();
        }

        public List<Article> Search(string data)
        {
            throw new NotImplementedException();
        }

        public void Submit(Article article)
        {
            throw new NotImplementedException();
        }
    }
}