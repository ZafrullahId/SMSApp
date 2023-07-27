using Application.Dtos;
using Application.Dtos.RequestModel;
using AutoMapper;
using Domain.Entity;
using Domain.Entity.Identity;

namespace Application.Mapping
{
    public class MappingObj : Profile
    {
        public MappingObj()
        {
            CreateMap<Choice, OptionDto>();
            CreateMap<Exam, ExamDto>();
            CreateMap<ExamSubjects, ExamSubjectsDto>()
                .ForMember(x => x.ExamDto, y => y.MapFrom(z => z.Exam))
                .ForMember(x => x.SubjectDtos, y => y.MapFrom(z => new List<SubjectDto>()));
            CreateMap<Level, LevelDto>();
            CreateMap<Paper, PaperDto>()
                .ForMember(x => x.StartDate, y => y.MapFrom(z => z.StartDate.ToLongDateString()))
                .ForMember(x => x.StartTime, y => y.MapFrom(z => z.StartDate.ToLongTimeString()));
            CreateMap<Question, QuestionDto>();
            CreateMap<Staff, StaffDto>().ForMember(x => x.UserDto, y => y.MapFrom(z => z.User));
            CreateMap<User, UserDto>();
            CreateMap<Role, RoleDto>();
            CreateMap<UserRole, RoleDto>()
                .ForMember(x => x.Id, y => y.MapFrom(z => z.Role.Id))
                .ForMember(x => x.Name, y => y.MapFrom(z => z.Role.Name))
                .ForMember(x => x.Description, y => y.MapFrom(z => z.Role.Description));
            CreateMap<Subject, SubjectDto>();
            CreateMap<Student, StudentDto>();
            CreateMap<StaffsLevels, StaffLevelDto>()
                .ForMember(x => x.StaffDto, y => y.MapFrom(x => x.Staff))
                .ForMember(x => x.LevelDtos, y => y.MapFrom(x => new List<LevelDto>()));
            CreateMap<StudentsPapers, StudentPapersDto>()
                .ForMember(x => x.FullName, y => y.MapFrom(z => z.Student.User.FullName))
                .ForMember(x => x.ProfileImage, y => y.MapFrom(z => z.Student.User.ProfileImage));
            CreateMap<StaffsLevels, LevelDto>()
                .ForMember(x => x.Id, x => x.MapFrom(x => x.Level.Id))
                .ForMember(x => x.Name, x => x.MapFrom(x => x.Level.Name))
                .ForMember(x => x.Description, x => x.MapFrom(x => x.Level.Description));
            CreateMap<Question, QuestionOptionsDto>();
            CreateMap<Staff, StaffLevelSubjectDto>()
                .ForMember(x => x.Subject, y => y.MapFrom(z => z.StaffsSubjects.Select(x => x.Subject)))
                .ForMember(x => x.Level, y => y.MapFrom(z => z.StaffsLevels.Select(x => x.Level)));
            CreateMap<StaffsSubjects, SubjectDto>()
                .ForMember(x => x.Id, y => y.MapFrom(z => z.Subject.Id))
                .ForMember(x => x.Name, y => y.MapFrom(z => z.Subject.Name))
                .ForMember(x => x.Description, y => y.MapFrom(z => z.Subject.Description));
            CreateMap<Question, Question>();
            CreateMap<TimeTable, TimeTableDto>();
            CreateMap<SubjectTimeTable, SubjectTimeTableDto>()
                .ForMember(x => x.SubjectDto, y => y.MapFrom(z => z.Subject));
            CreateMap<LevelTimeTable, LevelTimeTableDto>();

            CreateMap<CreateExamRequestModel, Exam>();
            CreateMap<CreateLevelRequestModel, Level>();
            CreateMap<CreateOptionRequestModel, Choice>();
            CreateMap<CreatePaperRequestModel, Paper>();
            CreateMap<CreateOptionRequestModel, Choice>();
            CreateMap<CreateQuestionRequestModel, Question>();
            CreateMap<CreateStaffRequestModel, User>();
            CreateMap<CreateStudentRequestModel, Student>();
            CreateMap<CreateUserRequestModel, User>();
            CreateMap<CreateRoleRequestModel, Role>();
            CreateMap<CreateSubjectRequestModel, Subject>();
            CreateMap<CreateTimeTableRequestModel, TimeTable>();
            CreateMap<CreateSubjectTimeTableRequestModel, SubjectTimeTable>();

        }
    }
}
