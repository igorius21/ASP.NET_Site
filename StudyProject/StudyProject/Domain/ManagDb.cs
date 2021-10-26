using StudyProject.Domain.Repositories.Abstract;

namespace StudyProject.Domain
{
    public class ManagDb
    {
        public TextRepo MyTexts { get; set; }
        public ServiceRepo MyServices { get; set; }

        public ManagDb(TextRepo textRepo, ServiceRepo serviceRepo)
        {
            MyTexts = textRepo;
            MyServices = serviceRepo;
        }
    }
}
