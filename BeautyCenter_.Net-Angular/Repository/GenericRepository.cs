<<<<<<< HEAD
﻿using BeautyCenter_.Net_Angular.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
=======
﻿using BeautyCenter_.Net_Angular.DTO;
using BeautyCenter_.Net_Angular.Models;
>>>>>>> c7f4bb8caea96eef2454dfd48eb611fc6a3ddf62

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
        //here getting service by category
        public List<Service> GetServicesByCategory(string Categ)
        {

            List<Service> ls =db.Services.Where(s => s.Category == Categ).ToList();
            return ls;
        }

        public List<Service> GetServicesByName(string Name)
        {

            List<Service> ls = db.Services.Where(s => s.Name == Name).ToList();
            return ls;
        }


    

        public void save()
        {
            db.SaveChanges();
        }


       
    }
}
