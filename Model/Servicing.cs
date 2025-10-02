
namespace MIS_Admin.Model
{
    public class Servicing
    {
        public string JobNo { get; set; } = string.Empty;
        public string RequestNo { get; set; } = string.Empty;
        public string RequestDate { get; set; } = string.Empty;
        public string TargetDate { get; set; } = string.Empty;
        public string Service { get; set; } = string.Empty;
        public string Merchant { get; set; } = string.Empty;
        public string Region { get; set; } = string.Empty;
        public string Terminal { get; set; } = string.Empty;
        public string Sim { get; set; } = string.Empty;
        public int? Days { get; set; }
        public string TAT { get; set; } = string.Empty;
        public string DispatchBy { get; set; } = string.Empty;
        public string DispatchDate { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
        public string Result { get; set; } = string.Empty;
        public string ServicedDate { get; set; } = string.Empty;
    }
}
