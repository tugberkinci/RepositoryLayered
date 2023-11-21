using System.Runtime.CompilerServices;

namespace Template.Api.Models
{
    public class BaseResponse<TData>
    {
        private static BaseResponse<TData> _success => new BaseResponse<TData> { Details = new MetaData { } };
        private static BaseResponse<TData> _failed(string message) => new BaseResponse<TData> { Details = new MetaData {Message = message } };
        public MetaData Details { get; protected set; }

        public TData? Data { get; set; }

        public static BaseResponse<TData> Succeed (TData data)
        {
            _success.Data = data;
            return _success;
        }
        public static BaseResponse<TData> Succeed()
        {
            return _success;
        }
        public static BaseResponse<TData> Failed(string message)
        {
            return _failed(message);
        }

    }

    public class MetaData
    {
        public bool IsSucceed => String.IsNullOrEmpty(Message) ? true : false;
        public string Message { get; set; }
    }
}
