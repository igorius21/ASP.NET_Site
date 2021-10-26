using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using StudyProject.Domain.Entities;
using StudyProject.Domain.Repositories.Abstract;

namespace StudyProject.Domain.Repositories.EntityFramework
{
    public class EFServiceRepo : ServiceRepo
    {
        private readonly ContextDb myContext;
        public EFServiceRepo(ContextDb myContext)
        {
            this.myContext = myContext;
        }

        public IQueryable<Entities.MyService> AllService()
        {
            return myContext.Service;
        }

        public Entities.MyService ServiceId(Guid id)
        {
            return myContext.Service.FirstOrDefault(x => x.Id == id);
        }

        public void SaveService(Entities.MyService count)
        {
            if (count.Id == default)
                myContext.Entry(count).State = EntityState.Added;
            else
                myContext.Entry(count).State = EntityState.Modified;
            myContext.SaveChanges();
        }

        public void DelService(Guid id)
        {
            myContext.Service.Remove(new Entities.MyService() { Id = id });
            myContext.SaveChanges();
        }
    }
}

