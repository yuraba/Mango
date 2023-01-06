using System;
using System.Threading.Tasks;
using MangoWebb.Models;

namespace MangoWebb.Services.IServices
{
    public interface IBaseService: IDisposable
    {
        ResponseDto responseModel { get; set; }
        Task<T> SendAsync<T>(ApiRequest apiRequest);
    }
}