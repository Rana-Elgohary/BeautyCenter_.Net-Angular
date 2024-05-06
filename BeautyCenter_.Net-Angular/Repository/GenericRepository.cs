using BeautyCenter_.Net_Angular.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BeautyCenter_.Net_Angular.Repository
{
    public class GenericRepository<type> where type : class
    {
        BeautyCenterContext db;


        public GenericRepository(BeautyCenterContext db)
        {
          this.db =db;
        }


        public List<type> selectall()
        {
            return db.Set<type>().ToList();
        }
        public List<Package> selectallPackagesWithServices()
        {
            return db.Packages.Include(s=> s.Services).ToList();
        }

        public type selectbyid(int id)
        {
            return db.Set<type>().Find(id);
        }
      
        public UserService SelectByCompositeKey(int userId, int serviceId)
        {
            return db.UserServices.Find(userId, serviceId);
        }

        public List<UserService> GetUserServicesByDate(DateTime? date)
        {
            if (!date.HasValue)
            {
                return new List<UserService>(); 
            }
            else
            {
                // Retrieve UserService records for the specified date
                return db.Set<UserService>().Where(us => us.Date.HasValue && us.Date.Value.Date == date.Value.Date).ToList();
            }
        }


        public void add(type entity)
        {
            db.Set<type>().Add(entity);

        }

        public void update(type entity)
        {
            db.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        }

        public void delete(int id)
        {
            type obj = db.Set<type>().Find(id);
            db.Set<type>().Remove(obj);
        }

    

        public void save()
        {
            db.SaveChanges();
        }


       
    }
}
