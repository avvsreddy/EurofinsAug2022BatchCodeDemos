using KnowledgeHubProtal2022.Models.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KnowledgeHubProtal2022.Models.Data
{
    public interface ICatagoriesRepository
    {
        void Create(Catagory catagory);

        Task CreateAsync(Catagory catagory);

        void Update(Catagory catagory);
        Catagory GetCatagory(int id);
        List<Catagory> GetCatagories();
        List<Catagory> SearchCatagories(string data);
        void Delete(int id);
    }
}
