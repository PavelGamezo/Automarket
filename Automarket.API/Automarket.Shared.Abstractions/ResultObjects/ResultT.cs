namespace Automarket.Shared.Abstractions.ResultObjects
{
    public class Result<TValue> : Result
    {
        public TValue _value;

        public Result(TValue? value, bool isSuccess, Error error)
            : base(isSuccess, error)
        {
            _value = value;
        }

        public TValue? Value => IsSuccess 
            ? _value!
            : throw new InvalidOperationException("The value of a failure result can not be accessed");

        public static implicit operator Result<TValue>(TValue value) => new Result<TValue>(value, true, null);
    }
}
