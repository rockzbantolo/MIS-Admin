
namespace MIS_Admin.UI.Dto
{
    public class TerminalInfoDto
    {
        public int Id { get; set; }
        public string Serial { get; set; }
        public string Status { get; set; }
        public int ModelId { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public string Type { get; set; }
        public string Code { get; set; }
        public string Brand { get; set; }
        public string PartNo { get; set; }
        public string AppVersion { get; set; }
        public string AppCrc { get; set; }
        public string Asset { get; set; }
        public DateTime? DeliveryDate { get; set; }
    }

}
