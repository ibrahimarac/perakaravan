namespace Perakaravan.Application.Wrapper
{
    public class Result<T>
    {
        public T Data { get; }
        public ResultStatus Status { get; private set; }
        public bool IsSuccess => Status == ResultStatus.Ok;
        public string SuccessMessage { get; private set; } = string.Empty;
        public IEnumerable<string> Errors { get; private set; } = new List<string>();


        public Result(T data)
        {
            Data = data;
        }

        private Result(ResultStatus status)
        {
            Status = status;
        }


        public static Result<T> Success(T value)
        {
            return new Result<T>(value);
        }

        public static Result<T> Success(T value, string successMessage)
        {
            return new Result<T>(value)
            {
                SuccessMessage = successMessage
            };
        }

        public static Result<T> Error(params string[] errorMessages)
        {
            return new Result<T>(ResultStatus.Error)
            {
                Errors = errorMessages
            };
        }

        public static Result<T> NotFound()
        {
            return new Result<T>(ResultStatus.NotFound);
        }
    }
}
