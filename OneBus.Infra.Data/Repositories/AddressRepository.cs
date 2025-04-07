using OneBus.Domain.Entities;
using OneBus.Domain.Filters;
using OneBus.Domain.Interfaces.Repositories;
using OneBus.Infra.Data.DbContexts;
using OneBus.Infra.Data.Extensions;

namespace OneBus.Infra.Data.Repositories
{
    public class AddressRepository : BaseRepository<Address, AddressFilter>, IAddressRepository
    {
        public AddressRepository(OneBusDbContext dbContext) : base(dbContext) { }

        protected override Predicate<Address> ApplyFilter(AddressFilter filter)
        {
            return base
                .ApplyFilter(filter)
                .AndApply(c => filter.AreaType == null || c.Area.ToLower().Contains(filter.AreaType.ToString()!));        
        }
    }
}
