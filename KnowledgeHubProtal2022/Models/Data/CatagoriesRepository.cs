﻿using KnowledgeHubProtal2022.Models.Entities;
using System.Collections.Generic;
using System.Linq;

namespace KnowledgeHubProtal2022.Models.Data
{
    public class CatagoriesRepository : ICatagoriesRepository
    {
        private KnowledgeHubDbContext db = new KnowledgeHubDbContext();
        public void Create(Catagory catagory)
        {
            db.Catagories.Add(catagory);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            db.Catagories.Remove(db.Catagories.Find(id));
            db.SaveChanges();
        }

        public List<Catagory> GetCatagories()
        {
            return db.Catagories.ToList();
        }

        public Catagory GetCatagory(int id)
        {
            return db.Catagories.Find(id);
        }

        public List<Catagory> SearchCatagories(string data)
        {
            return (from c in db.Catagories
                    where c.Name.Contains(data) || c.Description.Contains(data)
                    select c).ToList();
        }

        public void Update(Catagory catagory)
        {
            db.Entry(catagory).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
        }
    }
}