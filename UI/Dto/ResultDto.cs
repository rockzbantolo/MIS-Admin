namespace MIS_Admin.UI.Dto
{
    public sealed class ResultDto
    {
        public bool Success { get; set; }
        public string Message { get; set; } = string.Empty;

        public static ResultDto Ok() => new ResultDto { Success = true };
        public static ResultDto Fail(string message) => new ResultDto { Success = false, Message = message };

    }
}
