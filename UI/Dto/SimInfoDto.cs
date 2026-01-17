
namespace MIS_Admin.UI.Dto
{
    public sealed class SimInfoDto
    {
        public int Id { get; set; }
        public int CarrierID { get; set; }
        public string Description { get; set; }
        public string Serial { get; set; }
        public string Status { get; set; }
        public string Location { get; set; }
        public DateTime? DeliveryDate { get; set; }
        public DateTime? ReceiveDate { get; set; }
        public DateTime? ReleaseDate { get; set; }
    }

}
