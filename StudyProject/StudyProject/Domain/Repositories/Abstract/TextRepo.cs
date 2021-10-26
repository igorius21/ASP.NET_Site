using System;
using System.Linq;
using StudyProject.Domain.Entities;

namespace StudyProject.Domain.Repositories.Abstract
{
    public interface TextRepo
    {
        IQueryable<Text> AllText();
        Text TextId(Guid id);
        Text GetTextKeyWord(string keyWord);
        void SaveText(Text entity);
        void DelText(Guid id);
    }
}
