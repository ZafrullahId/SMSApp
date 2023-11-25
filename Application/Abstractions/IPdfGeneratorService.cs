using Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Abstractions
{
    public interface IPdfGeneratorService
    {
        Task<bool> GeneratePdf(string fileName, string title, IEnumerable<SubjectTimeTableDto> data, List<string> columns);
    }
}
