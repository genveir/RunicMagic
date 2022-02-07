using System;

namespace SharedUtil
{
    public class ResultOrError<ResultType>
    {
        public bool IsError { get; }

        private readonly string? _error;
        public string Error
        {
            get
            {
                if (!IsError) throw new InvalidOperationException("Cannot get Error when ResultOrError is not an error (check IsError at runtime)");
                return _error!;
            }
        }

        private readonly ResultType? _result;
        public ResultType Result
        {
            get
            {
                if (IsError) throw new InvalidOperationException("Cannot get Result when ResultOrError is an error (check IsError at runtime)");
                return _result!;
            }
        }

        public ResultOrError(ResultType result)
        {
            IsError = false;
            _result = result;
        }

        public ResultOrError(string error)
        {
            IsError = true;
            _error = error;
        }

        public static implicit operator ResultOrError<ResultType>(ResultType result) => new(result);
        public static implicit operator ResultOrError<ResultType>(string error) => new(error);
    }
}