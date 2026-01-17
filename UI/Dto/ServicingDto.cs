
namespace MIS_Admin.UI.Dto
{
    public sealed class ServicingDto
    {
        public int Job_ID { get; set; }             // Job_ID
        public string Request_No { get; set; }        // Request_No
        public string Merchant { get; set; }         // Merchant_Name
        public string Service { get; set; }          // Request (cleaned)
        public string Priority { get; set; }         // calculated from Days
        public string Status { get; set; }           // mapped status
        public string Result { get; set; }           // mapped result
        public string Terminal { get; set; }         // Terminal_SN
        public string Sim { get; set; }              // Sim_SN
        public string Region { get; set; }           // Province mapping
        public int SLA { get; set; }                 // Days
        public string Request_Date { get; set; }      // Dispatch_Date_Time formatted
        public string Dispatch_Date { get; set; }     // Dispatch_Date_Time formatted (long)
    }
}
