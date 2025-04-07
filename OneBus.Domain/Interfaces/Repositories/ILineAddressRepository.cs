﻿using OneBus.Domain.Entities;
using OneBus.Domain.Filters;

namespace OneBus.Domain.Interfaces.Repositories
{
    public interface ILineAddressRepository : IBaseRepository<LineAddress, BaseFilter>
    {
    }
}
