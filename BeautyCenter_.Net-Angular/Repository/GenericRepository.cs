
﻿using BeautyCenter_.Net_Angular.DTO;
using BeautyCenter_.Net_Angular.Models;
using Microsoft.EntityFrameworkCore;


﻿using BeautyCenter_.Net_Angular.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

﻿using BeautyCenter_.Net_Angular.DTO;
using BeautyCenter_.Net_Angular.Models;


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

        //------------------------------------------------

        public UserService SelectByCompositeKey(int userId, int serviceId)
        {
            return db.UserServices.Find(userId, serviceId);
        }   
        //--------------------------------------------------
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
        //-----------------------------------------------

        public List<PackageUser> selectAllFromPU()
        {
            return db.Set<PackageUser>()
                .Include(pu=>pu.Package)
                .Include(pu=>pu.User)
                .ToList();
        }

       
        public PackageUser getByCompositeKeyPU(int packageId, int userId)
        {
            return db.Set<PackageUser>()
            .Include(pu => pu.Package) // Include the Package navigation property
            .Include(pu => pu.User)    // Include the User navigation property
            .FirstOrDefault(pu => pu.PackageId == packageId && pu.UserId == userId);

        }


        public UserService getByCompositeKeyUS(int ServiceId, int userId)
        {
            return db.Set<UserService>()
            .Include(us => us.Service) // Include the Service navigation property
            .Include(us => us.User)    // Include the User navigation property
            .FirstOrDefault(us => us.ServiceId == ServiceId && us.UserId == userId);

        }
        public void deleteByCompositeKeyG(int forignId1, int forignId2)
        {
            type obj = db.Set<type>().Find(forignId1, forignId2);
            db.Set<type>().Remove(obj);
        }
        public List<PackageUser> getByUserIdfromPU(int userId)
        {
            return db.PackageUsers.Where(t => t.User.Id == userId)
            .Include(pu => pu.Package)
            .Include(pu => pu.User)
            .ToList();
        }
        public List<UserService> getByUserIdfromUS(int userId)
        {
            return db.UserServices.Where(t => t.User.Id == userId)
            .Include(us =>us.Service )
            .Include(us => us.User)
            .ToList();
        }


        public List<PackageUser> getByPackageIdfromPU(int packageId)
        {
             return db.PackageUsers.Where(t => t.Package.Id == packageId)
            .Include(pu => pu.Package)
            .Include(pu => pu.User)
            .ToList();
           
        }
        public List<PackageUser> getPackageUserByDate(DateTime date)
        {

            return db.Set<PackageUser>().Where(PU => PU.Date == date)
            .Include(pu => pu.Package) // Include the Package navigation property
            .Include(pu => pu.User)    // Include the User navigation property
            .ToList();

        }

        public void deletePackageUserByDate(DateTime date)
        {

            List<PackageUser> packagesUsers = db.Set<PackageUser>()
            .Where(PU => PU.Date == date)
            .ToList();
            foreach (PackageUser packageUser in packagesUsers)
            {
                db.Set<PackageUser>().Remove(packageUser);
            }
        }

        public void deleteUserServiceByDate(DateTime date)
        {

            List<UserService> UserServices = db.Set<UserService>()
            .Where(US => US.Date == date)
            .ToList();
            foreach (UserService UserService in UserServices)
            {
                db.Set<UserService>().Remove(UserService);
            }
        }
        //-----------------------------------------------
        public void add(type entity)
        {
            db.Set<type>().Add(entity);

        }


        //--------------------------------------------------

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
        public List<ServiceResponse> GetServicesByCategory(string Categ)
        {

            List<ServiceResponse> ls =db.Services.Where(s => s.Category == Categ).ToList();
            return ls;
        }

        public List<ServiceResponse> GetServicesByName(string Name)
        {

            List<ServiceResponse> ls = db.Services.Where(s => s.Name == Name).ToList();
            return ls;
        }

        public List<string> GetAllCategories()
        {
            List<string> ls = db.Services.Select(s=>s.Category).Distinct().ToList();
            return ls;
        }
    

        public void save()
        {
            db.SaveChanges();
        }


       
    }
}
