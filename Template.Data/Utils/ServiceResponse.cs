using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Template.Data.Utils
{
    public class ServiceResponse<TData> where TData : class
    {

        private static ServiceResponse<TData> _success => new ServiceResponse<TData> { IsSuccess = true };
        private static ServiceResponse<TData> _failed => new ServiceResponse<TData> { IsSuccess = false };



        public bool IsSuccess { get; protected set; }
        public TData Data { get; protected set; }
        public string Message { get; protected set; }

        public ServiceResponse() { }

        public static ServiceResponse<TData> Succeed (TData data)
        {
            ServiceResponse<TData>._success.Data = data;
            return _success;
        }

        public static ServiceResponse<TData> Failed(string message)
        {
            ServiceResponse<TData>._failed.Message = message;
            return _failed;
        }
    }
}
