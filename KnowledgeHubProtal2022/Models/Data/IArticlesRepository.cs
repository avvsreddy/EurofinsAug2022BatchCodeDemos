using KnowledgeHubProtal2022.Models.Entities;
using System.Collections.Generic;

namespace KnowledgeHubProtal2022.Models.Data
{
    public interface IArticlesRepository
    {
        void Submit(Article article);
        List<Article> Search(string data);
        Article GetArticle(int id);
        void Approve(List<int> articleIds);
        void Reject(List<int> articleIds);
        List<Article> GetArticlesForReview();
        List<Article> GetArticlesForBrowse();



    }
}
