using Application.Abstractions.Repositories;
using Application.Abstractions.Services;
using Application.Dtos;
using Application.Dtos.ResponseModel;
using AutoMapper;
using Domain.Enum;
using Hangfire;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class SchoolProfileService : ISchoolProfileService
    {
        private readonly ISchoolProfileRepository _schoolProfileRepository;
        private readonly IMapper _mapper;
        public SchoolProfileService(ISchoolProfileRepository schoolProfileRepository, IMapper mapper )
        {
            _schoolProfileRepository = schoolProfileRepository;
            _mapper = mapper;
        }
        public async Task<Response<SchoolProfileDto>> GetSchoolProfileAsync()
        {
            var profile = await _schoolProfileRepository.GetAsync();
            var profileDto = _mapper.Map<SchoolProfileDto>(profile);
            return new Response<SchoolProfileDto>()
            { Data = profileDto, Message = profile is null ? "Something went wrong, School profile not found" : "School profile found", Success = profile is not null ? true : false };
        }
        public async Task UpdateSchoolProfileAsync()
        {
            var profile = await _schoolProfileRepository.GetAsync();
            profile.Term = Term.FirstTerm;
            var session = profile.Session.Split("/");
            session[0] = session[1];
            var session2 = int.Parse(session[1]);
            session2++;
            session[1] = session2.ToString();
            var newSession = string.Join("/", session);
            profile.Session = newSession;
            await _schoolProfileRepository.UpdateAsync(profile);
        }
        public void UpdateAsync()
        {
            RecurringJob.AddOrUpdate(
         "Run every September 18th",
         () => UpdateSchoolProfileAsync(),
         "0 0 18 9 *");
        }
    }
}
