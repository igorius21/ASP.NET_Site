using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using StudyProject.Domain.Entities;
using StudyProject.Domain.Repositories.Abstract;

namespace StudyProject.Domain.Repositories.EntityFramework
{
    public class EFTextRepo : TextRepo
    {
        private readonly ContextDb myContext;
        public EFTextRepo(ContextDb myContext)
        {
            this.myContext = myContext;
        }

        public IQueryable<Text> AllText()
        {
            return myContext.Text;
        }

        public Text TextId(Guid id)
        {
            return myContext.Text.FirstOrDefault(x => x.Id == id);
        }

        public Text GetTextKeyWord(string keyWord)
        {
            return myContext.Text.FirstOrDefault(x => x.KeyWord == keyWord);
        }

        public void SaveText(Text count)
        {
            if (count.Id == default)
                myContext.Entry(count).State = EntityState.Added;
            else
                myContext.Entry(count).State = EntityState.Modified;
            myContext.SaveChanges();
        }

        public void DelText(Guid id)
        {
            myContext.Text.Remove(new Text() { Id = id });
            myContext.SaveChanges();
        }
    }
}

