using Application.Dtos;
using Application.Dtos.ResponseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Abstractions.Services
{
    public interface ISchoolProfileService
    {
        Task<Response<SchoolProfileDto>> GetSchoolProfileAsync();
    }
}
