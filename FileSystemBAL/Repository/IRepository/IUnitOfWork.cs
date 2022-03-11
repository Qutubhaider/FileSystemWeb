using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileSystemBAL.Repository.IRepository;

namespace FileSystemBAL.Repository.IRepository
{
    public interface IUnitOfWork:IDisposable
    {
        IDivisionRepository DivisionRepository { get; }
        IZoneRepository ZoneRepository { get; }
        IDepartmentRepository DepartmentRepository { get; }
        IDesignationRepository DesignationRepository { get; }
        IUserRepository UserRepository { get; }
        IDeskRepository DeskRepository { get; }
        IStoreRepository StoreRepository { get; }
        IRoomRepository RoomRepository { get; }
        void Save();
    }
}