using Application.Abstractions.Repositories;
using Application.Abstractions.Services;
using Application.Dtos;
using Application.Dtos.RequestModel;
using Application.Dtos.ResponseModel;
using AutoMapper;
using Domain.Entity;
using Domain.Enum;
using Microsoft.IdentityModel.Tokens;

namespace Application.Services
{
    public class OptionService : IOptionService
    {
        private readonly IOptionRepository _optionRepository;
        private readonly IStudentPaperRepository _studentPaperRepository;
        private readonly IQuestionRepository _questionRepository;
        private readonly IStudentRepository _studentRepository;
        private readonly IMapper _mapper;
        public OptionService(IOptionRepository optionRepository, IStudentPaperRepository studentPaperRepository, IQuestionRepository questionRepository, IStudentRepository studentRepository, IMapper mapper)
        {
            _optionRepository = optionRepository;
            _studentPaperRepository = studentPaperRepository;
            _questionRepository = questionRepository;
            _studentRepository = studentRepository;
            _mapper = mapper;
        }

        public async Task<BaseResponse> CreateOptionsAsync(List<CreateOptionRequestModel> optionRequestModels, Guid questionId)
        {
            foreach (var opt in optionRequestModels)
            {
                if (opt is null) { return new BaseResponse { Message = "Option can't be null", Success = false, }; }

                var option = _mapper.Map<Choice>(opt);
                await _optionRepository.CreateAsync(option);
            }

            await _optionRepository.SaveChangesAsync();
            return new BaseResponse { Message = "Options Successfully Created", Success = true };
        }

        public async Task<OptionsResponseModel> GetOptionByQuestionIdAsync(Guid id)
        {
            var options = await _optionRepository.GetAllAsync(x => x.QuestionId == id && x.IsDeleted == false);
            if (options is null) { return new OptionsResponseModel { Message = "Option not found", Success = false }; }

            var data = _mapper.Map<List<OptionDto>>(options);
            return new OptionsResponseModel { Message = "Options found", Success = true, Data = data };
        }

        public async Task<BaseResponse> SubmitPaperAsync(List<Guid> optionIds, Guid studentId)
        {
            double score = 0;
            var student = await _studentRepository.GetAsync(studentId);
            if (student is null) { return new BaseResponse { Message = "Student not found", Success = false }; }

            foreach (var optionId in optionIds)
            {
                var option = await _optionRepository.GetAsync(x => x.Id == optionId && !x.IsDeleted);
                if (option is null) { continue; }

                if (!option.IsCorrect) { continue; }

                var question = await _questionRepository.GetQuestionAsync(option.QuestionId);
                if (question is null) { return new BaseResponse { Message = "Question not found", Success = false }; }

                if (question.Paper.LevelId != student.LevelId) { return new BaseResponse { Message = "Opps!. You are not eligible to take this exam", Success = false }; }

                var studentPaper = await _studentPaperRepository.GetAsync(x => x.PaperId == question.PaperId && x.StudentId == studentId);
                if (studentPaper is null) { return new BaseResponse { Message = "Oppps something went wrong", Success = false }; }

                studentPaper.Score += question.Marks;
                score = studentPaper.Score;
            }

            await _studentPaperRepository.SaveChangesAsync();
            return new BaseResponse { Message = $"Successfully Submited. Your score is {score}", Success = true, };
        }

        public async Task<BaseResponse> CheckOptionAsync(Guid optionId, Guid questionId, Guid studentId)
        {
            var student = await _studentRepository.GetAsync(studentId);
            if (student is null) { return new BaseResponse { Message = "Student not found", Success = false }; }

            var options = await _optionRepository.GetAllAsync(x => x.QuestionId == questionId && x.IsDeleted == false);
            if (options.IsNullOrEmpty()) { return new BaseResponse { Message = "Question not found", Success = false }; }

            var option = await _optionRepository.GetAsync(x => x.Id == optionId && x.IsDeleted == false);
            if (option is null) { return new BaseResponse { Message = "Option not found", Success = false }; }

            if (options.Contains(option) && option.IsCorrect == true)
            {
                var question = await _questionRepository.GetAsync(questionId);
                var studentPaper = await _studentPaperRepository.GetAsync(x => x.PaperId == question.PaperId && x.StudentId == studentId);
                if (studentPaper is null) { return new BaseResponse { Message = "Opps Something went wrong", Success = false }; }

                studentPaper.Score += question.Marks;
                await _studentPaperRepository.SaveChangesAsync();
                return new BaseResponse { Message = "Option was correct", Success = true };
            }
            
            return new BaseResponse { Message = "Option not correct", Success = false };
        }

        public async Task<BaseResponse> UpdateAsync(Guid id, UpdateOptionRequestModel model)
        {
            var option = await _optionRepository.GetOptionAsync(id);
            if (option is null) { return new BaseResponse { Message = "Option not found", Success = false }; }

            if (option.Question.Paper.PaperStatus != PaperStatus.Pending) { return new BaseResponse { Message = "Paper might have started or ended", Success = false }; }

            option.IsCorrect = model.IsCorrect;
            option.Text = model.Text;
            await _optionRepository.SaveChangesAsync();
            return new BaseResponse { Message = "Option Successfully updated", Success = true };
        }

        public async Task<BaseResponse> DeleteAsync(Guid id)
        {
            var option = await _optionRepository.GetOptionAsync(id);
            if (option is null) { return new BaseResponse { Message = "Option not found", Success = false }; }

            if (option.Question.Paper.PaperStatus != PaperStatus.Pending) { return new BaseResponse { Message = "Paper might have started or ended", Success = false }; }

            option.IsDeleted = true;
            await _optionRepository.SaveChangesAsync();
            return new BaseResponse { Message = "Option Successfully deleted", Success = true };
        }
    }
}