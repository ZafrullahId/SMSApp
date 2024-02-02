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
            CreateMap<SchoolProfile, SchoolProfileDto>();
            CreateMap<ExamSubjects, ExamSubjectsDto>()
                .ForMember(x => x.ExamDto, y => y.MapFrom(z => z.Exam))
                .ForMember(x => x.SubjectDtos, y => y.MapFrom(z => new List<SubjectDto>()));
            CreateMap<Level, LevelDto>();
            CreateMap<Paper, PaperDto>()
                .ForMember(x => x.StartDate, y => y.MapFrom(z => z.StartDate.ToLongDateString()))
                .ForMember(x => x.SubjectName, y => y.MapFrom(z => z.Subject.Name))
                .ForMember(x => x.PaperStatus, y => y.MapFrom(z => z.PaperStatus.ToString()))
                .ForMember(x => x.StartTime, y => y.MapFrom(z => z.StartDate.ToLongTimeString()));
            CreateMap<Question, QuestionDto>();
            CreateMap<Staff, StaffDto>().ForMember(x => x.UserDto, y => y.MapFrom(z => z.User));
            CreateMap<User, UserDto>();
            CreateMap<Role, RoleDto>();
            CreateMap<Paper, SubjectDto>()
                .ForMember(c => c.Id, y => y.MapFrom(z => z.Subject.Id))
                .ForMember(c => c.Name, y => y.MapFrom(z => z.Subject.Name))
                .ForMember(c => c.Description, y => y.MapFrom(z => z.Subject.Description));
            CreateMap<UserRole, RoleDto>()
                .ForMember(x => x.Id, y => y.MapFrom(z => z.Role.Id))
                .ForMember(x => x.Name, y => y.MapFrom(z => z.Role.Name))
                .ForMember(x => x.Description, y => y.MapFrom(z => z.Role.Description));
            CreateMap<Subject, SubjectDto>();
            CreateMap<Student, StudentDto>()
                .ForMember(x => x.AdmissionNo, y => y.MapFrom(x => x.AdmissionNo));
            CreateMap<StaffsLevels, StaffLevelDto>()
                .ForMember(x => x.StaffDto, y => y.MapFrom(x => x.Staff))
                .ForMember(x => x.LevelDtos, y => y.MapFrom(x => new List<LevelDto>()));
            CreateMap<StudentPaper, StudentPapersDto>()
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
                .ForMember(x => x.SubjectDto, y => y.MapFrom(z => z.Subject))
                .ForMember(x => x.StartDate, y => y.MapFrom(z => z.StartTime.ToLongDateString()))
                .ForMember(x => x.StartTime, y => y.MapFrom(z => z.StartTime.ToShortTimeString()));
            CreateMap<LevelTimeTable, LevelTimeTableDto>();
            CreateMap<Department, DepartmentDto>();

            CreateMap<CreateExamRequestModel, Exam>();
            CreateMap<CreateUserRequestModel, User>();
            CreateMap<CreateRoleRequestModel, Role>();
            CreateMap<CreateStaffRequestModel, User>();
            CreateMap<CreateLevelRequestModel, Level>();
            CreateMap<CreatePaperRequestModel, Paper>();
            CreateMap<CreateOptionRequestModel, Choice>();
            CreateMap<CreateOptionRequestModel, Choice>();
            CreateMap<CreateSubjectRequestModel, Subject>();
            CreateMap<CreateStudentRequestModel, Student>();
            CreateMap<CreateQuestionRequestModel, Question>();
            CreateMap<CreateTimeTableRequestModel, TimeTable>();
            CreateMap<CreateDepartmentRequestModel, Department>();
            CreateMap<CreatePaperRequestModel, SubjectTimeTable>()
                .ForMember(x => x.StartTime, y => y.MapFrom(z => z.StartDate));
            CreateMap<CreateSubjectTimeTableRequestModel, SubjectTimeTable>();

        }
    }
}
