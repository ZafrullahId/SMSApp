using Application.Abstractions.Repositories;
using Application.Abstractions.Services;
using Application.Dtos;
using Application.Dtos.RequestModel;
using Application.Dtos.ResponseModel;
using AutoMapper;
using Domain.Entity;
using Microsoft.IdentityModel.Tokens;

namespace Application.Services
{
    public class SubjectService : ISubjectService
    {
        private readonly IMapper _mapper;
        private readonly IStaffRepository _staffRepository;
        private readonly ISubjectRepository _subjecutorRepository;
        private readonly IStaffSubjectRepository _staffSubjectRepository;
        public SubjectService(ISubjectRepository subjecutorRepository, IStaffRepository staffRepository, IStaffSubjectRepository staffSubjectRepository, IMapper mapper)
        {
            _mapper = mapper;
            _staffRepository = staffRepository;
            _subjecutorRepository = subjecutorRepository;
            _staffSubjectRepository = staffSubjectRepository;
        }
        public async Task<BaseResponse> CreateAsync(CreateSubjectRequestModel model)
        {
            var exist = await _subjecutorRepository.ExistsAsync(x => x.Name == model.Name);
            if (exist) { return new BaseResponse { Message = "Subject has been created Already", Success = false }; }
            
            var subject = _mapper.Map<Subject>(model);
            await _subjecutorRepository.CreateAsync(subject);
            await _subjecutorRepository.SaveChangesAsync();
            return new BaseResponse { Message = "Subject Success", Success = true };
        }
        public async Task<SubjectResponseModel> GetSubjectByIdAsync(Guid id)
        {
            var subject = await _subjecutorRepository.GetAsync(id);
            if (subject is null) { return new SubjectResponseModel { Message = "Subject not found", Success = false }; }
            
            var subjectDto = _mapper.Map<SubjectDto>(subject);
            return new SubjectResponseModel { Message = "Subject found Successfully", Success = true, Data = subjectDto };
        }
        public async Task<SubjectsResponseModel> GetSubjects()
        {
            var subjects = await _subjecutorRepository.GetAllAsync();
            if (subjects.IsNullOrEmpty()) { return new SubjectsResponseModel { Message = "No subject found", Success = false }; }
            
            var subjectDtos = _mapper.Map<List<SubjectDto>>(subjects);
            return new SubjectsResponseModel { Message = "Subject found successfully", Success = true, Data = subjectDtos };
        }
        public async Task<SubjectsResponseModel> GetSubjectsByStaffIdAsync(Guid staffId)
        {
            var staff = await _staffRepository.GetAsync(staffId);
            if (staff is null) { return new SubjectsResponseModel { Message = "Staff not found", Success = false, }; }
            
            var subjects = await _staffSubjectRepository.GetStaffSubjectsAsync(staffId);
            if (subjects.IsNullOrEmpty()) { return new SubjectsResponseModel { Message = "This Staff Doesn't teach any SUbject", Success = false, }; }
            
            var subjectDtos = _mapper.Map<List<SubjectDto>>(subjects);
            return new SubjectsResponseModel { Message = "Success", Success = true, Data = subjectDtos };
        }
    }
}