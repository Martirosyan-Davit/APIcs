using Microsoft.AspNetCore.Http;

namespace WEB.AUTH.DAL.Exceptions;

public abstract class BaseException : Exception
{
        protected abstract string _message { get; }

        public BaseException() : base() { }

        public BaseException(string message) : base(message) { }

        public override string Message => _message ?? base.Message;

        public  abstract int StatusCode { get; } 
}