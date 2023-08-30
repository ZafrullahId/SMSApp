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
using Persistence.Mail;
using Persistence.Repositories;
using Persistence.SMS;

var builder = WebApplication.CreateBuilder(args);

// Add builder.Services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHangfire(config =>
    config.SetDataCompatibilityLevel(CompatibilityLevel.Version_170)
    .UseSimpleAssemblyNameTypeSerializer()
    .UseDefaultTypeSerializer()
   //.UseDashboardStylesheet(Assembly.GetExecutingAssembly(), "sms")
    .UseMemoryStorage());

builder.Services.AddHangfireServer();

builder.Services.AddDbContext<SMSAppContext>(options =>
    options.UseMySql(
        builder.Configuration.GetConnectionString("SMSAppConnection"),
        ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("SMSAppConnection"))
    )
);

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
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IMailService, MailService>();
builder.Services.AddScoped<ISMSService, SMSService>();
builder.Services.AddScoped<ITimeTableService, TimeTableService>();
builder.Services.AddScoped<IFileUpload, FileUpload>();
builder.Services.AddScoped<ISubjectTimeTableService, SubjectTimeTableService>();
builder.Services.AddScoped<ILevelTimeTableService, LevelTimeTableService>();
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
        OnAuthenticationFailed = context =>
        {
            context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
            context.Response.ContentType = "application/json";
            context.Response.WriteAsync("Custom Unauthorized Message");

            return Task.CompletedTask;
        },
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

app.UseRouting();

app.UseCors("SMSApp");

app.UseAuthentication();

app.UseAuthorization();

app.UseMiddleware<GlobalExceptionMiddleware>();

app.MapControllers();

app.UseHangfireDashboard();

app.Run();
