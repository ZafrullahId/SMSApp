using Application.Abstractions.Repositories;
using Application.Abstractions.Services;
using Application.Dtos;
using Application.Dtos.RequestModel;
using Application.Dtos.ResponseModel;
using AutoMapper;
using Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IMapper _mapper;
        private readonly IDepartmentRepository _departmentRepository;
        public DepartmentService(IDepartmentRepository departmentRepository, IMapper mapper)
        {
            _departmentRepository = departmentRepository;
            _mapper = mapper;
        }

        public async Task<BaseResponse> CreateAsync(CreateDepartmentRequestModel model)
        {
            var departmentExist = await _departmentRepository.ExistsAsync(x => x.Name == model.Name);
            if (departmentExist) { return new BaseResponse { Message = "Department already exist", Success = true }; }

            var department = _mapper.Map<Department>(model);
            await _departmentRepository.CreateAsync(department);
            await _departmentRepository.SaveChangesAsync();
            return new BaseResponse { Message = $"{model.Name} Department Successfully craeted", Success = true };
        }
        public async Task<Results<DepartmentDto>> GetAllAsync()
        {
            var departments = await _departmentRepository.GetAllAsync();
            var departmentsData = _mapper.Map<List<DepartmentDto>>(departments);
            return new Results<DepartmentDto> { Message = "Successful", Data = departmentsData, Success = true };
        }
        public async Task<BaseResponse> DeleteAsync(Guid departmentId)
        {
            var deprtment = await _departmentRepository.GetAsync(departmentId);
            if (deprtment == null) { return new BaseResponse { Message = "not found", Success = false}; }
            await _departmentRepository.DeleteAsync(deprtment);
            return new BaseResponse { Message = "Successfully deleted", Success = true };
        }
    }
}
