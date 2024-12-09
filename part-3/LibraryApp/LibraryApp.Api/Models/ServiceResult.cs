using Microsoft.AspNetCore.Mvc;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace LibraryApp.Api.Models
{
    public class ServiceResult
    {
        public int Status {  get; set; }
        public ProblemDetails? ProblemDetails { get; set; }

        // Success method doesn't need generic T anymore
        public static ServiceResult Success(int status)
        {
            return new ServiceResult
            {
                Status = status,
            };
        }

        public static ServiceResult Fail(string message)
        {
            return new ServiceResult
            {
                ProblemDetails = new ProblemDetails
                {
                    Detail = message
                }
            };
        }
    }


    public class ServiceResult<T> : ServiceResult
    {
        public T? Data { get; set; }
    
        //static factory method
        public static ServiceResult<T> Success (T data, int status)
        {
            return new ServiceResult<T> 
            { 
                Data = data,
                Status = status,
            };

        
        }
        public static ServiceResult<T> Fail(string message)
        {
            return new ServiceResult<T>
            {
                ProblemDetails = new ProblemDetails
                {
                    Detail = message
                }
            };


        }

    }
}