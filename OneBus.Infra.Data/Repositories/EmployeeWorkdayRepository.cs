using OneBus.Domain.Entities;
using OneBus.Domain.Filters;
using OneBus.Domain.Interfaces.Repositories;
using OneBus.Infra.Data.DbContexts;
using System.Linq.Expressions;

namespace OneBus.Infra.Data.Repositories
{
    public class EmployeeWorkdayRepository : BaseRepository<EmployeeWorkday, EmployeeWorkDayFilter>, IEmployeeWorkdayRepository
    {
        public EmployeeWorkdayRepository(OneBusDbContext dbContext) : base(dbContext)
        {
        }

        protected override Expression<Func<EmployeeWorkday, bool>> ApplyFilter(EmployeeWorkDayFilter filter)
        {
            var value = filter.Value?.ToLower();

            return c =>
                (filter.DayType == null || c.DayType == filter.DayType) &&
                (string.IsNullOrWhiteSpace(value) ||
                ((c.Employee!.Name.ToLower().Contains(value) ||
                c.Employee!.Code.ToLower().Contains(value) ||
                c.Employee!.Rg.ToLower().Contains(value) ||
                c.Employee!.Cpf.ToLower().Contains(value) ||
                c.Employee!.Phone.ToLower().Contains(value) ||
                c.Employee!.CnhNumber!.ToLower().Contains(value)) && value != string.Empty));
        }
    }
}
