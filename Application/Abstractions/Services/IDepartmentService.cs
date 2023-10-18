using Application.Dtos.ResponseModel;
using Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Dtos.RequestModel;

namespace Application.Abstractions.Services
{
    public interface IDepartmentService
    {
        Task<BaseResponse> CreateAsync(CreateDepartmentRequestModel model);
        Task<BaseResponse> DeleteAsync(Guid departmentId);
        Task<Results<DepartmentDto>> GetAllAsync();
    }
}
