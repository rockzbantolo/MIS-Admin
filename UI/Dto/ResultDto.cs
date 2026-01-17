namespace MIS_Admin.UI.Dto
{
    public sealed class ResultDto<T>
    {
        public bool Success { get; }
        public string Message { get; }
        public T Data { get; }

        private ResultDto(bool success, T data, string message)
        {
            Success = success;
            Data = data;
            Message = message;
        }

        public static ResultDto<T> Ok(T data, string message = "")
            => new(true, data, message);

        public static ResultDto<T> Fail(string message)
            => new(false, default, message);
    }

    public sealed class ResultDto
    {
        public bool Success { get; }
        public string Message { get; }

        private ResultDto(bool success, string message)
        {
            Success = success;
            Message = message;
        }

        public static ResultDto Ok(string message = "")
            => new(true, message);

        public static ResultDto Fail(string message)
            => new(false, message);
    }
}
