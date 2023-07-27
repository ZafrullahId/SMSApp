using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos.ResponseModel
{
    public class TimeTableResponseModel
    {
        public TimeTableDto Data { get; set; }
    }
    public class TimeTablesResponseModel
    {
        public List<TimeTableDto> Data { get; set; }
    }
}
