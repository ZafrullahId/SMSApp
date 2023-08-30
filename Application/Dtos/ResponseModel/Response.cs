using Domain.Entity;
using Pagination.WebApi.Wrappers;
using System.Collections.Generic;
namespace Application.Dtos.ResponseModel
{
    public class Response<T> : BaseResponse
    {
        public T Data { get; set; }
    }
    public class Responses<T> : BaseResponse
    {
        public PagedResponse<IEnumerable<T>> Data { get; set; }
    }
    public class Results<T> : BaseResponse
    {
        public IEnumerable<T> Data { get; set; }
    }
}