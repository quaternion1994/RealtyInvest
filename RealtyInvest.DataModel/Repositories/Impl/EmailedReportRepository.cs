using System.Linq;
using Latitude.DataAccess.Entities;

namespace Latitude.DataAccess.Repositories.Impl
{
    public class EmailedReportRepository : Repository<EmailedReport, int>, IEmailedReportRepository
    {
        public EmailedReportRepository(ArgusDbContext context) : base(context)
        {
        }

        public override EmailedReport GetById(int id)
        {
            return _context.EmailedReports.SingleOrDefault(x => x.Id == id);
        }
    }
}
