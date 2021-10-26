using System;
using System.Linq;
using StudyProject.Domain.Entities;

namespace StudyProject.Domain.Repositories.Abstract
{
    public interface ServiceRepo
    {
        IQueryable<Entities.MyService> AllService();
        Entities.MyService ServiceId(Guid id);
        void SaveService(Entities.MyService entity);
        void DelService(Guid id);
    }
}

