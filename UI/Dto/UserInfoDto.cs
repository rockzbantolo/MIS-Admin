
namespace MIS_Admin.UI.Dto
{
    public sealed class UserInfoDto
    {
        public int Id { get; set; }
        public string Personel { get; set; } = string.Empty;
        public string ContactNo { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Role {  get; set; } = string.Empty;
    }
}
