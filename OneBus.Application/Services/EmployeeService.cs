using FluentValidation;
using OneBus.Application.DTOs.Employee;
using OneBus.Application.Interfaces.Services;
using OneBus.Application.Utils;
using OneBus.Domain.Commons;
using OneBus.Domain.Commons.Result;
using OneBus.Domain.Entities;
using OneBus.Domain.Enums.Employee;
using OneBus.Domain.Filters;
using OneBus.Domain.Interfaces.Repositories;

namespace OneBus.Application.Services
{
    public class EmployeeService : BaseService<Employee, CreateEmployeeDTO, ReadEmployeeDTO, UpdateEmployeeDTO, EmployeeFilter>,
        IEmployeeService
    {
        public EmployeeService(
            IBaseRepository<Employee, EmployeeFilter> baseRepository,
            IValidator<CreateEmployeeDTO> createValidator,
            IValidator<UpdateEmployeeDTO> updateValidator)
            : base(baseRepository, createValidator, updateValidator)
        {
        }

        public override async Task<Result<Pagination<ReadEmployeeDTO>>> GetPaginedAsync(EmployeeFilter filter, CancellationToken cancellationToken = default)
        {
            var result = await base.GetPaginedAsync(filter, cancellationToken);

            if (!result.Sucess)
                return result;

            foreach (var employee in result.Value!.Items)
            {
                employee.BloodTypeName = EnumUtils.GetName<BloodType>(employee.BloodType);
                employee.RoleName = EnumUtils.GetName<Role>(employee.Role);
                employee.CnhCategoryName = EnumUtils.GetName<CnhCategory>(employee.CnhCategory);
                employee.StatusName = EnumUtils.GetName<EmployeeStatus>(employee.Status);
            }

            return result;
        }

        public override async Task<Result<ReadEmployeeDTO>> GetByIdAsync(long id, CancellationToken cancellationToken = default)
        {
            var result = await base.GetByIdAsync(id, cancellationToken);

            if (!result.Sucess)
                return result;

            var employee = result.Value!;

            employee.BloodTypeName = EnumUtils.GetName<BloodType>(employee.BloodType);
            employee.RoleName = EnumUtils.GetName<Role>(employee.Role);
            employee.CnhCategoryName = EnumUtils.GetName<CnhCategory>(employee.CnhCategory);
            employee.StatusName = EnumUtils.GetName<EmployeeStatus>(employee.Status);

            return result;
        }

        public Result<IEnumerable<ReadStatusDTO>> GetStatus()
        {
            var values = Enum.GetValues<EmployeeStatus>();

            List<ReadStatusDTO> status = [];

            foreach (var value in values)
            {
                status.Add(new ReadStatusDTO { Value = (byte)value, Name = value.GetDisplayName() });
            }

            return SuccessResult<IEnumerable<ReadStatusDTO>>.Create(status);
        }

        public Result<IEnumerable<ReadCnhCategoryDTO>> GetCnhCategories()
        {
            var values = Enum.GetValues<CnhCategory>();

            List<ReadCnhCategoryDTO> cnhCategories = [];

            foreach (var value in values)
            {
                cnhCategories.Add(new ReadCnhCategoryDTO { Value = (byte)value, Name = value.GetDisplayName() });
            }

            return SuccessResult<IEnumerable<ReadCnhCategoryDTO>>.Create(cnhCategories);
        }

        public Result<IEnumerable<ReadRoleDTO>> GetRoles()
        {
            var values = Enum.GetValues<Role>();

            List<ReadRoleDTO> roles = [];

            foreach (var value in values)
            {
                roles.Add(new ReadRoleDTO { Value = (byte)value, Name = value.GetDisplayName() });
            }

            return SuccessResult<IEnumerable<ReadRoleDTO>>.Create(roles);
        }

        public Result<IEnumerable<ReadBloodTypeDTO>> GetBloodTypes()
        {
            var values = Enum.GetValues<BloodType>();

            List<ReadBloodTypeDTO> bloodTypes = [];

            foreach (var value in values)
            {
                bloodTypes.Add(new ReadBloodTypeDTO { Value = (byte)value, Name = value.GetDisplayName() });
            }

            return SuccessResult<IEnumerable<ReadBloodTypeDTO>>.Create(bloodTypes);
        }

        protected override void UpdateFields(Employee entity, UpdateEmployeeDTO updateDTO)
        {
            entity.Name = updateDTO.Name;
            entity.Rg = updateDTO.Rg;
            entity.Cpf = updateDTO.Cpf;
            entity.BloodType = updateDTO.BloodType;
            entity.Code = updateDTO.Code;
            entity.Role = updateDTO.Role;
            entity.Email = updateDTO.Email;
            entity.Phone = updateDTO.Phone;
            entity.HiringDate = updateDTO.HiringDate;
            entity.CnhNumber = updateDTO.CnhNumber;
            entity.CnhCategory = updateDTO.CnhCategory;
            entity.CnhExpiration = updateDTO.CnhExpiration;
            entity.Status = updateDTO.Status;
            entity.Image = updateDTO.Image;
        }
    }
}
