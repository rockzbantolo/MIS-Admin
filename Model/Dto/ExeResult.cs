

namespace MIS_Admin.Model.Dto
{
    public sealed class ExeResult
    {
        public bool Success { get; set; }
        public string Message { get; set; } = string.Empty;

        public static ExeResult Ok() => new ExeResult { Success = true };
        public static ExeResult Fail(string message) => new ExeResult { Success = false, Message = message };

    }
}
