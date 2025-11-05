using FluentValidation;
using OneBus.Application.DTOs.EmployeeWorkday;

namespace OneBus.Application.Validators.EmployeeWorkday
{
    public class UpdateEmployeeWorkdayDTOValidator : AbstractValidator<UpdateEmployeeWorkdayDTO>
    {        
        public UpdateEmployeeWorkdayDTOValidator()
        {          
        }
    }
}
