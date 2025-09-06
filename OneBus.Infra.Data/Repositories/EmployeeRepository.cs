using OneBus.Domain.Entities;
using OneBus.Domain.Filters;
using OneBus.Domain.Interfaces.Repositories;
using OneBus.Infra.Data.DbContexts;
using System.Linq.Expressions;

namespace OneBus.Infra.Data.Repositories
{
    public class EmployeeRepository : BaseRepository<Employee, EmployeeFilter>, IEmployeeRepository
    {
        public EmployeeRepository(OneBusDbContext dbContext) : base(dbContext)
        {
        }

        protected override Expression<Func<Employee, bool>> ApplyFilter(EmployeeFilter filter)
        {
            var value = filter.Value?.ToLower();

            return c =>
                (filter.BloodType == null || c.BloodType == filter.BloodType) &&
                (filter.Status == null || c.Status == filter.Status) &&
                (filter.Role == null || c.Role == filter.Role) &&
                (filter.CnhCategory == null || c.CnhCategory == filter.CnhCategory) &&
                (string.IsNullOrWhiteSpace(value) ||
                ((c.Name.ToLower().Contains(value) ||
                c.Code.ToLower().Contains(value) ||
                c.Rg.ToLower().Contains(value) ||
                c.Cpf.ToLower().Contains(value) ||
                c.Phone.ToLower().Contains(value) ||
                c.CnhNumber!.ToLower().Contains(value)) && value != string.Empty));
        }
    }
}
