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
    public class QuestionService : IQuestionService
    {
        private readonly IQuestionRepository _questionRepository;
        private readonly IOptionRepository _optionRepository;
        private readonly IPaperRepository _paperRepository;
        private readonly IMapper _mapper;
        public QuestionService(IQuestionRepository questionRepository, IOptionRepository optionRepository, IPaperRepository paperRepository, IMapper mapper)
        {
            _questionRepository = questionRepository;
            _optionRepository = optionRepository;
            _paperRepository = paperRepository;
            _mapper = mapper;
        }
        public async Task<BaseResponse> CreateQuestionAsync(CreateQuestionRequestModel model, Guid paperId)
        {
            if (model.Marks == 0 || model.Text == null || model.OptionType == 0 || model.Options.IsNullOrEmpty())
            {
                return new BaseResponse { Message = "Pls Make sure you fill all forms", Success = false };
            }

            var paper = await _paperRepository.GetAsync(x => x.Id == paperId && x.PaperStatus == PaperStatus.Pending && x.IsDeleted == false);
            if (paper == null) { return new BaseResponse { Message = "Subject not found", Success = false }; }

            var question = _mapper.Map<Question>(model);
            question.PaperId = paper.Id;

            await _questionRepository.CreateAsync(question);
            await _questionRepository.SaveChangesAsync();
            return new BaseResponse { Message = $"Question Successfull Created", Success = true };
        }

        public async Task<QuestionOptionsResponseModel> GetQuestionByIdAsync(Guid id)
        {
            var question = await _questionRepository.GetAsync(x => x.Id == id && x.IsDeleted == false);
            if (question == null) { return new QuestionOptionsResponseModel { Message = "Question not found", Success = false }; }

            var options = await _optionRepository.GetAllAsync(x => x.QuestionId == question.Id && x.IsDeleted == false);
            if (options.IsNullOrEmpty()) { return new QuestionOptionsResponseModel { Message = "No Option found for this Question", Success = false }; }
            
            var questionOptionDtoData = _mapper.Map<QuestionOptionsDto>(question);
            return new QuestionOptionsResponseModel { Message = "Question successfully found", Success = true, Data = questionOptionDtoData };
        }

        public async Task<QuestionsOptionsResponseModel> GetAllQuestionsByPaperIdAsync(Guid paperId)
        {
            var paper = await _paperRepository.GetAsync(x => x.Id == paperId && x.IsDeleted == false);
            if (paper == null) { return new QuestionsOptionsResponseModel { Message = "Paper not found", Success = false }; }

            var questions = await _questionRepository.GetQuestionByPaperIdAsync(paper.Id);
            if (questions.IsNullOrEmpty()) { return new QuestionsOptionsResponseModel { Message = $"No Question found", Success = false }; }

            List<Question> questionsOptions = new();
            foreach (var question in questions)
            {
                var questionOptions = await _optionRepository.GetOptionsByQuestionId(question.Id);
                var quest = _mapper.Map<Question>(question);
                //quest.Options = _mapper.Map<List<Choice>>(questionOptions);
                questionsOptions.Add(quest);
            }
            var questionOptionsDtoData = _mapper.Map<List<QuestionOptionsDto>>(questionsOptions);
            return new QuestionsOptionsResponseModel { Message = "Questions found", Success = true, Data = questionOptionsDtoData };
        }

        public async Task<BaseResponse> UpdateAsync(Guid questionId, UpdateQuestionRequestModel model)
        {
            var question = await _questionRepository.GetAsync(questionId);
            if (question == null) { return new BaseResponse { Message = "Question not found", Success = false }; }

            var paper = await _paperRepository.GetAsync(x => x.Id == question.PaperId);
            if (paper == null) { return new BaseResponse { Message = "Paper not found", Success = false }; }
            
            if (paper.PaperStatus != PaperStatus.Pending) { return new BaseResponse { Message = "This paper might have startes or ended", Success = false }; }
            
            question.Text = model.Text ?? question.Text;
            question.OptionType = model.OptionType == 0 ? question.OptionType : model.OptionType;
            question.Marks = model.Marks;
            await _questionRepository.SaveChangesAsync();
            return new BaseResponse { Message = "Question Successfully  Updated", Success = true };
        }

        public async Task<BaseResponse> DeletAsync(Guid id)
        {
            var question = await _questionRepository.GetAsync(id);
            if (question == null) { return new BaseResponse { Message = "Question not found", Success = false }; }
           
            var paper = await _paperRepository.GetAsync(x => x.Id == question.PaperId);
            if (paper == null) { return new BaseResponse { Message = "Paper not found", Success = false }; }
            
            if (paper.PaperStatus != PaperStatus.Pending) { return new BaseResponse { Message = "This paper might have startes or ended", Success = false }; }
            var options = await _optionRepository.GetAllAsync(x => x.QuestionId == question.Id);

            if (options.IsNullOrEmpty()) { return new BaseResponse { Message = "No Options for this question", Success = false }; }
            
            foreach (var option in options) { option.IsDeleted = true; }
            question.IsDeleted = true;
            await _questionRepository.UpdateAsync(question);
            return new BaseResponse { Message = "Question Successfully Deleted", Success = false };
        }
    }
}