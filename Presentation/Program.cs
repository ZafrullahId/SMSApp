//using System.Net;
//using System.Reflection;
//using System.Reflection.Metadata;
//using System.Text;
//using System.Xml.Linq;
//using Application.Abstractions;
//using Application.Abstractions.Repositories;
//using Application.Abstractions.Services;
//using Application.Exceptions;
//using Application.Services;
//using Application.Uploads;
//using Hangfire;
//using Hangfire.MemoryStorage;

//using Microsoft.AspNetCore.Authentication.JwtBearer;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.IdentityModel.Tokens;
//using Microsoft.OpenApi.Models;
//using NSwag;
//using NSwag.AspNetCore;
//using NSwag.Generation.Processors.Security;
//using Persistence.Auth;
//using Persistence.Context;
//using Persistence.Mail;
//using Persistence.Repositories;
//using Persistence.SMS;

//var builder = WebApplication.CreateBuilder(args);

//// Add builder.Services to the container.


//builder.Services.AddControllers();
//// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
//builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();
//builder.Services.AddHangfire(config =>
//    config.SetDataCompatibilityLevel(CompatibilityLevel.Version_170)
//    .UseSimpleAssemblyNameTypeSerializer()
//    .UseDefaultTypeSerializer()
//   //.UseDashboardStylesheet(Assembly.GetExecutingAssembly(), "sms")
//    .UseMemoryStorage());

//builder.Services.AddHangfireServer();

//builder.Services.AddDbContext<SMSAppContext>(options =>
//    options.UseMySql(
//        builder.Configuration.GetConnectionString("SMSAppConnection"),
//        ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("SMSAppConnection"))
//    )
//);

//builder.Services.AddCors(c => c
//                .AddPolicy("SMSApp", builder => builder
//                .AllowAnyHeader()
//                .AllowAnyMethod()
//                .AllowAnyOrigin()));

//builder.Services.AddControllers();

//#region|Authentication
//builder.Services.AddScoped<IJWTAuthenticationManager, JWTAuthenticationManager>();
//builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
//.AddJwtBearer(options =>
//{
//    options.TokenValidationParameters = new TokenValidationParameters
//    {
//        ValidateIssuer = true,
//        ValidateAudience = true,
//        ValidateLifetime = true,
//        ValidateIssuerSigningKey = true,
//        ValidIssuer = builder.Configuration["Jwt:Issuer"],
//        ValidAudience = builder.Configuration["Jwt:Issuer"],
//        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
//    };
//    options.Events = new JwtBearerEvents
//    {
//        OnAuthenticationFailed = context =>
//        {
//            context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
//            context.Response.ContentType = "application/json";
//            context.Response.WriteAsync("Custom Unauthorized Message");

//            return Task.CompletedTask;
//        },
//        OnMessageReceived = context =>
//        {
//            var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").LastOrDefault();

//            var isTokenValid = JWTAuthenticationManager.IsTokenValid(builder.Configuration["Jwt:Key"].ToString(), builder.Configuration["Jwt:Issuer"].ToString(), token);
//            context.Response.StatusCode = isTokenValid ? (int)HttpStatusCode.OK : (int)HttpStatusCode.Unauthorized;

//            return Task.CompletedTask;
//        }
//    };
//});
//#endregion

//builder.Services.AddOpenApiDocument(options => {
//    options.PostProcess = document =>
//    {
//        document.Info = new NSwag.OpenApiInfo
//        {
//            Version = "v1",
//            Title = "sms API",
//            Description = "An ASP.NET Core Web API for managing Student Activities",
//            TermsOfService = "https://example.com/terms",
//            Contact = new NSwag.OpenApiContact
//            {
//                Name = "Example Contact",
//                Url = "https://example.com/contact"
//            },
//            License = new NSwag.OpenApiLicense
//            {
//                Name = "Example License",
//                Url = "https://example.com/license"
//            }
//        };
//    };
//    //options.AddSecurity(JwtBearerDefaults.AuthenticationScheme, new NSwag.OpenApiSecurityScheme
//    //{
//    //    Name = "Authorization",
//    //    Description = "Input your Bearer token to access this API",
//    //    In = OpenApiSecurityApiKeyLocation.Header,
//    //    Type = OpenApiSecuritySchemeType.Http,
//    //    Scheme = JwtBearerDefaults.AuthenticationScheme,
//    //    BearerFormat = "JWT",
//    //});
//    options.OperationProcessors.Add(new OperationSecurityScopeProcessor("Bearer"));
//    options.DocumentProcessors.Add(new SecurityDefinitionAppender("Bearer", new NSwag.OpenApiSecurityScheme
//    {
//        Type = OpenApiSecuritySchemeType.ApiKey,
//        Name = "Authorization",
//        In = OpenApiSecurityApiKeyLocation.Header,
//        Scheme = JwtBearerDefaults.AuthenticationScheme,
//        BearerFormat = "JWT",
//        Description = "Input your Bearer token to access this API",
//    })
//    );

//    //options.AddSecurityRequirement(new NSwag.OpenApiSecurityRequirement
//    //{
//    //    {
//    //        new NSwag.OpenApiSecurityScheme
//    //        {
//    //            Reference = new OpenApiReference
//    //            {
//    //                Type = ReferenceType.SecurityScheme,
//    //                Id = "Bearer"
//    //            }
//    //        },
//    //        new string[]{}
//    //    }
//    //});
//});

////builder.Services.AddSwaggerGen(c =>
////{
////    c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "SMSApp", Version = "v1" });
////    c.AddSecurityDefinition("Bearer", new Microsoft.OpenApi.Models.OpenApiSecurityScheme
////    {
////        In = ParameterLocation.Header,
////        Description = "Please enter a valid token",
////        Name = "Authorization",
////        Type = SecuritySchemeType.Http,
////        BearerFormat = "JWT",
////        Scheme = "Bearer"
////    });
////    c.AddSecurityRequirement(new Microsoft.OpenApi.Models.OpenApiSecurityRequirement
////    {
////        {
////            new Microsoft.OpenApi.Models.OpenApiSecurityScheme
////            {
////                Reference = new OpenApiReference
////                {
////                    Type = ReferenceType.SecurityScheme,
////                    Id = "Bearer"
////                }
////            },
////            new string[]{}
////        }
////    });
////});

//builder.Services.AddHttpContextAccessor();
//builder.Services.AddSingleton<IUriService>(o =>
//{
//    var accessor = o.GetRequiredService<IHttpContextAccessor>();
//    var request = accessor.HttpContext.Request;
//    var uri = string.Concat(request.Scheme, "://", request.Host.ToUriComponent());
//    return new UriService(uri);
//});


//#region|Services
//builder.Services.AddScoped<IExamService, ExamService>();
//builder.Services.AddScoped<IExamSubjectsServices, ExamSubjectsServices>();
//builder.Services.AddScoped<ILevelService, LevelService>();
//builder.Services.AddScoped<IOptionService, OptionService>();
//builder.Services.AddScoped<IPaperService, PaperService>();
//builder.Services.AddScoped<IQuestionService, QuestionService>();
//builder.Services.AddScoped<IRoleService, RoleService>();
//builder.Services.AddScoped<IStaffService, StaffService>();
//builder.Services.AddScoped<IStudentPaperService, StudentPaperService>();
//builder.Services.AddScoped<IStudentService, StudentService>();
//builder.Services.AddScoped<ISubjectService, SubjectService>();
//builder.Services.AddScoped<IUserService, UserService>();
//builder.Services.AddScoped<IMailService, MailService>();
//builder.Services.AddScoped<ISMSService, SMSService>();
//builder.Services.AddScoped<ITimeTableService, TimeTableService>();
//builder.Services.AddScoped<IFileUpload, FileUpload>();
//builder.Services.AddScoped<ISubjectTimeTableService, SubjectTimeTableService>();
//builder.Services.AddScoped<ILevelTimeTableService, LevelTimeTableService>();
//#endregion

//#region|Repositories
//builder.Services.AddScoped<IExamRepository, ExamRepository>();
//builder.Services.AddScoped<IExamSubjectsRepository, ExamSubjectsRepository>();  
//builder.Services.AddScoped<ILevelRepository, LevelRepository>();
//builder.Services.AddScoped<IOptionRepository, OptionRepository>();
//builder.Services.AddScoped<IPaperRepository, PaperRepository>();
//builder.Services.AddScoped<IQuestionRepository, QuestionRepository>();
//builder.Services.AddScoped<IRoleRepository, RoleRepository>();
//builder.Services.AddScoped<IStaffRepository, StaffRepository>();
//builder.Services.AddScoped<IStaffLevelRepository, StaffLevelRepository>();
//builder.Services.AddScoped<IStaffSubjectRepository, StaffSubjectRepository>();
//builder.Services.AddScoped<IStudentPaperRepository, StudenPaperRepository>();
//builder.Services.AddScoped<IStudentRepository, StudentRepository>();
//builder.Services.AddScoped<ISubjectRepository, SubjectRepository>();
//builder.Services.AddScoped<IUserRepository, UserRepository>();
//builder.Services.AddScoped<IUserRoleRepository, UserRoleRepository>();
//builder.Services.AddScoped<ITimeTableRepository, TimeTableRepository>();
//builder.Services.AddScoped<ILevelTimeTableRepository, LevelTimeTableRepository>();
//builder.Services.AddScoped<ISubjectTimeTableRepository, SubjectTimeTableRepository>();
//#endregion



//builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

//builder.Services.AddTransient<GlobalExceptionMiddleware>();

//var app = builder.Build();

//// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    //app.UseSwagger();
//    app.UseOpenApi();
//    app.UseSwaggerUi3(options =>
//    {
//        options.DefaultModelsExpandDepth = -1;
//        options.DocExpansion = "none";
//        options.TagsSorter = "alpha";
//    });
//}

//app.UseStaticFiles();

//app.UseHttpsRedirection();

//app.UseRouting();

//app.UseCors("SMSApp");

//app.UseAuthentication();

//app.UseAuthorization();

//app.UseMiddleware<GlobalExceptionMiddleware>();

//app.MapControllers();

//app.UseHangfireDashboard();

//app.Run();

using System.Net;
using System.Reflection;
using System.Text;
using Application.Abstractions;
using Application.Abstractions.Repositories;
using Application.Abstractions.Services;
using Application.Exceptions;
using Application.Services;
using Application.Uploads;
using Hangfire;
using Hangfire.MemoryStorage;

using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Persistence.Auth;
using Persistence.Context;
using Persistence.File;
using Persistence.Mail;
using Persistence.Payment;
using Persistence.Repositories;
using Persistence.SMS;

var builder = WebApplication.CreateBuilder(args);

// Add builder.Services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddHangfire(x =>  x.UseSqlServerStorage(builder.Configuration.GetConnectionString("SMSAppConnection")));
builder.Services.AddHangfireServer();


builder.Services.AddDbContext<SMSAppContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("SMSAppConnection")
));

builder.Services.AddCors(c => c
                .AddPolicy("SMSApp", builder => builder
                .AllowAnyHeader()
                .AllowAnyMethod()
                .AllowAnyOrigin()));

builder.Services.AddControllers();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "SMSApp", Version = "v1" });
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Please enter a valid token",
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        BearerFormat = "JWT",
        Scheme = "Bearer"
    });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[]{}
        }
    });
});

builder.Services.AddHttpContextAccessor();
builder.Services.AddSingleton<IUriService>(o =>
{
    var accessor = o.GetRequiredService<IHttpContextAccessor>();
    var request = accessor.HttpContext.Request;
    var uri = string.Concat(request.Scheme, "://", request.Host.ToUriComponent());
    return new UriService(uri);
});



#region|Services
builder.Services.AddScoped<IExamService, ExamService>();
builder.Services.AddScoped<IExamSubjectsServices, ExamSubjectsServices>();
builder.Services.AddScoped<ILevelService, LevelService>();
builder.Services.AddScoped<IOptionService, OptionService>();
builder.Services.AddScoped<IPaperService, PaperService>();
builder.Services.AddScoped<IQuestionService, QuestionService>();
builder.Services.AddScoped<IRoleService, RoleService>();
builder.Services.AddScoped<IStaffService, StaffService>();
builder.Services.AddScoped<IStudentPaperService, StudentPaperService>();
builder.Services.AddScoped<IStudentService, StudentService>();
builder.Services.AddScoped<ISubjectService, SubjectService>();
builder.Services.AddScoped<IUserService, AuthService>();
builder.Services.AddScoped<IMailService, MailService>();
builder.Services.AddScoped<IPaystackService, PaystackService>();
builder.Services.AddScoped<IPaymentRequestService, PaymentRequestService>();
builder.Services.AddScoped<IPdfGeneratorService, PdfGeneratorService>();
builder.Services.AddScoped<ISMSService, SMSService>();
builder.Services.AddScoped<ITimeTableService, TimeTableService>();
builder.Services.AddScoped<IFileUpload, FileUpload>();
builder.Services.AddScoped<ISubjectTimeTableService, SubjectTimeTableService>();
builder.Services.AddScoped<ILevelTimeTableService, LevelTimeTableService>();
builder.Services.AddScoped<ISchoolProfileService, SchoolProfileService>();
builder.Services.AddScoped<IDepartmentService, DepartmentService>();
builder.Services.AddSingleton<HttpClient>();

#endregion

#region|Repositories
builder.Services.AddScoped<IExamRepository, ExamRepository>();
builder.Services.AddScoped<IExamSubjectsRepository, ExamSubjectsRepository>();
builder.Services.AddScoped<ILevelRepository, LevelRepository>();
builder.Services.AddScoped<IOptionRepository, OptionRepository>();
builder.Services.AddScoped<IPaperRepository, PaperRepository>();
builder.Services.AddScoped<IQuestionRepository, QuestionRepository>();
builder.Services.AddScoped<IRoleRepository, RoleRepository>();
builder.Services.AddScoped<IStaffRepository, StaffRepository>();
builder.Services.AddScoped<IStaffLevelRepository, StaffLevelRepository>();
builder.Services.AddScoped<IStaffSubjectRepository, StaffSubjectRepository>();
builder.Services.AddScoped<IStudentPaperRepository, StudenPaperRepository>();
builder.Services.AddScoped<IStudentRepository, StudentRepository>();
builder.Services.AddScoped<ISubjectRepository, SubjectRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserRoleRepository, UserRoleRepository>();
builder.Services.AddScoped<ITimeTableRepository, TimeTableRepository>();
builder.Services.AddScoped<ILevelTimeTableRepository, LevelTimeTableRepository>();
builder.Services.AddScoped<ISubjectTimeTableRepository, SubjectTimeTableRepository>();
builder.Services.AddScoped<IDepartmentRepository, DepartmentRepository>();
builder.Services.AddScoped<ISchoolProfileRepository, SchoolProfileRepository>();
#endregion


#region|Authentication
builder.Services.AddScoped<IJWTAuthenticationManager, JWTAuthenticationManager>();
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        ValidAudience = builder.Configuration["Jwt:Issuer"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
    };
    options.Events = new JwtBearerEvents
    {
        //OnAuthenticationFailed = context =>
        //{
        //    //context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
        //    context.Response.ContentType = "application/json";
        //    context.Response.WriteAsync("Custom Unauthorized Message");

        //    return Task.CompletedTask;
        //},
        OnMessageReceived = context =>
        {
            var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").LastOrDefault();

            var isTokenValid = JWTAuthenticationManager.IsTokenValid(builder.Configuration["Jwt:Key"].ToString(), builder.Configuration["Jwt:Issuer"].ToString(), token);
            context.Response.StatusCode = isTokenValid ? (int)HttpStatusCode.OK : (int)HttpStatusCode.Unauthorized;

            return Task.CompletedTask;
        }
    };
});
#endregion

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddTransient<GlobalExceptionMiddleware>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "SMSApp v1"));
}

app.UseStaticFiles();

app.UseHttpsRedirection();

app.UseHangfireDashboard();

app.UseRouting();

app.UseCors("SMSApp");

app.UseAuthentication();

app.UseAuthorization();

app.UseMiddleware<GlobalExceptionMiddleware>();

app.MapControllers();


app.Run();