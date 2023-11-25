﻿using Application.Dtos.RequestModel;
using Application.Dtos.ResponseModel;
using Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Abstractions.Services
{
    public interface ITimeTableService
    {
        Task<BaseResponse> CreateTimeTableAsync(CreateTimeTableRequestModel model, Guid levelId);
        Task<BaseResponse> DownloadTimeTable(Guid levelId, Term term, string seasion);
    }
}
