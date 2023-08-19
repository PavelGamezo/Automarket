using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automarket.Shared.Abstractions.ResultObjects
{
    public class Result
    {
        protected internal Result(bool isSuccess, Error error)
        {
            if(isSuccess && error != Error.None)
            {
                throw new InvalidOperationException();
            }
            if (!isSuccess && error == Error.None)
            {
                throw new InvalidOperationException();
            }

            IsSuccess = isSuccess;
            Error = error;
        }

        public bool IsSuccess { get; set; }

        public bool IsFailure => !IsSuccess;

        public Error Error { get; }

        public static Result Success() => new(true, Error.None);

        public static Result<TValue> Success<TValue>(TValue value)
            => new(value, true, Error.None);

        public static Result Fail(Error error) => new(false, error);

        public static Result<TValue> Fail<TValue>(Error error)
            => new (default(TValue), false, error);
    }
}
