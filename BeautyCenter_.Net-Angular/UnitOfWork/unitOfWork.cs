using BeautyCenter_.Net_Angular.Models;
using BeautyCenter_.Net_Angular.Repository;

namespace BeautyCenter_.Net_Angular.UnitOfWork
{
    public class UnitOfWork
    {
        BeautyCenterContext db;
        GenericRepository<Package> packageRepository;
        GenericRepository<PackageUser> packageUserRepository;
        GenericRepository<Service> serviceRepository;
        GenericRepository<Userr> userRepository;
        GenericRepository<UserService> userServiceRepository;

        public UnitOfWork(BeautyCenterContext db)
        {
            this.db = db;
        }

        public GenericRepository<Package> PackageRepository
        {
            get
            {
                if (packageRepository == null)
                {
                    packageRepository = new GenericRepository<Package>(db);
                }
                return packageRepository;
            }
        }

        public GenericRepository<PackageUser> PackageUserRepository
        {
            get
            {
                if (packageUserRepository == null)
                {
                    packageUserRepository = new GenericRepository<PackageUser>(db);
                }
                return packageUserRepository;
            }
        }

        public GenericRepository<Service> ServiceRepository
        {
            get
            {
                if (serviceRepository == null)
                {
                    serviceRepository = new GenericRepository<Service>(db);
                }
                return serviceRepository;
            }
        }

        public GenericRepository<Userr> UserRepository
        {
            get
            {
                if (userRepository == null)
                {
                    userRepository = new GenericRepository<Userr>(db);
                }
                return userRepository;
            }
        }

        public GenericRepository<UserService> UserServiceRepository
        {
            get
            {
                if (userServiceRepository == null)
                {
                    userServiceRepository = new GenericRepository<UserService>(db);
                }
                return userServiceRepository;
            }
        }

        public void SaveChanges()
        {
            db.SaveChanges();
        }
    }
}
