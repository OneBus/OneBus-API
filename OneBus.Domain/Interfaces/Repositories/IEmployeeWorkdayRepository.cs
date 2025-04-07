﻿using OneBus.Domain.Entities;
using OneBus.Domain.Filters;

namespace OneBus.Domain.Interfaces.Repositories
{
    public interface IEmployeeWorkdayRepository : IBaseRepository<EmployeeWorkday, BaseFilter>
    {
    }
}
