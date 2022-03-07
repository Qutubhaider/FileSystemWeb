using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileSystemBAL.Repository.IRepository;
using FileSystemBAL.Data;

namespace FileSystemBAL.Repository
{    
    public class UnitOfWork:IUnitOfWork
    {
        private readonly DatabaseContext moDatabaseContext;
        public UnitOfWork(DatabaseContext foDatabaseContext)
        {
            moDatabaseContext = foDatabaseContext;
            DivisionRepository = new DivisionRepository(moDatabaseContext);
            ZoneRepository = new ZoneRepository(moDatabaseContext);
            DepartmentRepository = new DepartmentRepository(moDatabaseContext);
            DesignationRepository = new DesignationRepository(moDatabaseContext);
            UserRepository = new UserRepository(moDatabaseContext);
        }

        public IDivisionRepository DivisionRepository {get;private set;}
        public IZoneRepository ZoneRepository{get;private set;}
        public IDepartmentRepository DepartmentRepository{get;private set;}
        public IDesignationRepository DesignationRepository{get;private set;}
        public IUserRepository UserRepository{get;private set;}


        public void Dispose()
        {
            moDatabaseContext.Dispose();
        }
        public void Save()
        {
            moDatabaseContext.SaveChanges();
        }
    }
}