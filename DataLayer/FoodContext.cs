using BusinessLayer;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{

    public class FoodContext : IDb<Food, int>
    {
            private readonly AppDbContext context;

            public FoodContext()
            {
                context = new AppDbContext();
            }

            public FoodContext(AppDbContext context)
            {
                this.context = context;
            }

            public void Create(Food item)
            {
                context.Foods.Add(item);
                context.SaveChanges();
            }

            public Food Read(int key, bool useNavigationalProperties = false, bool isReadOnly = false)
            {
                IQueryable<Food> query = context.Foods;

                if (useNavigationalProperties)
                    query = query.Include(f => f.User);

                if (isReadOnly)
                    query = query.AsNoTracking();

                return query.FirstOrDefault(f => f.Id == key);
            }

            public List<Food> ReadAll(bool useNavigationalProperties = false, bool isReadOnly = false)
            {
                IQueryable<Food> query = context.Foods;

                if (useNavigationalProperties)
                    query = query.Include(f => f.User);

                if (isReadOnly)
                    query = query.AsNoTracking();

                return query.ToList();
            }

            public void Update(Food item, bool useNavigationalProperties = false)
            {
                context.Entry(item).State = EntityState.Modified;
                context.SaveChanges();
            }

            public void Delete(int key)
            {
                var item = context.Foods.Find(key);
                if (item == null) return;

                context.Foods.Remove(item);
                context.SaveChanges();
            }
        
    }
}
