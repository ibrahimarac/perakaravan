namespace Perakaravan.Application.Wrapper
{
    public class Result
    {
        public dynamic Data { get; set; }
        public ResultStatus Status { get; set; }
        public string SuccessMessage { get; private set; } = string.Empty;
        public IEnumerable<string> Errors { get; set; } = Enumerable.Empty<string>();


        private Result(dynamic data)
        {
            Status = ResultStatus.Ok;
            Data = data;
        }

        private Result(ResultStatus status)
        {
            Status = status;
        }

        public static Result Success<T>(T data)
        {
            return new Result(data);
        }

        public static Result Success()
        {
            return new Result(ResultStatus.Ok);
        }

        public static Result Success<T>(T data, string successMessage)
        {
            return new Result(data)
            {
                SuccessMessage = successMessage
            };
        }

        public static Result Error(params string[] errorMessages)
        {
            return new Result(ResultStatus.Error)
            {
                Errors = errorMessages
            };
        }

        public static Result NotFound()
        {
            return new Result(ResultStatus.NotFound);
        }

        public static Result NotFound(params string[] errorMessages)
        {
            return new Result(ResultStatus.NotFound)
            {
                Errors = errorMessages
            };
        }

    }
}
