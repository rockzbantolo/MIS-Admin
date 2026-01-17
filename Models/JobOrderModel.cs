using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace MIS_Admin.Models
{
    public class JobOrderModel
    {
        [Key]
        public int Id { get; set; }

        public int IRId { get; set; }
        [StringLength(45)]
        public string IRNumber { get; set; } = string.Empty;

        public int JobTypeId { get; set; }
        [StringLength(255)]
        public string JobTypeDesc { get; set; }
        [StringLength(255)]
        public string JobTypeSubDesc { get; set; }
        [StringLength(255)]
        public string JobTypeStatusDesc { get; set; }

        public int MerchantId { get; set; }
        [StringLength(255)]
        public string MerchantName { get; set; }

        public int TerminalId { get; set; }
        [StringLength(45)]
        public string TerminalSerial { get; set; }

        public int SIMId { get; set; }
        [StringLength(45)]
        public string SIMSerial { get; set; }

        public int ReplaceTerminalId { get; set; }
        [StringLength(45)]
        public string ReplaceTerminalSerial { get; set; }

        public int ReplaceSIMId { get; set; }
        [StringLength(45)]
        public string ReplaceSIMSerial { get; set; }

        public int ReplaceDockId { get; set; }
        [StringLength(45)]
        public string ReplaceDockSerial { get; set; }

        [StringLength(45)]
        public string ReplacePowerSerial { get; set; }

        public int FEId { get; set; }
        [StringLength(45)]
        public string FEName { get; set; }

        public int ClientId { get; set; }
        [StringLength(255)]
        public string ClientName { get; set; }

        [StringLength(1000)]
        public string ActionMade { get; set; }

        public DateTime ServiceDateTime { get; set; }
        [StringLength(45)]
        public string ServiceDate { get; set; }
        [StringLength(45)]
        public string ServiceTime { get; set; } = "09:00:00";

        [StringLength(45)]
        public string ReqInstallDate { get; set; }
        [StringLength(45)]
        public string ReqInstallTime { get; set; } = "09:00:00";

        [StringLength(45)]
        public string ServiceReqDate { get; set; }
        [StringLength(45)]
        public string ServiceReqTime { get; set; } = "09:00:00";

        [StringLength(45)]
        public string ReportedDate { get; set; } = "0000-00-00";
        [StringLength(45)]
        public string LastServiceRequest { get; set; }

        public int CurTerminalStatus { get; set; }
        public int CurSIMStatus { get; set; }
        public int CurDockStatus { get; set; }

        [StringLength(45)]
        public string CurTerminalStatusDesc { get; set; }
        [StringLength(45)]
        public string CurSIMStatusDesc { get; set; }
        [StringLength(45)]
        public string CurDockStatusDesc { get; set; }

        public int RepTerminalStatus { get; set; }
        public int RepSIMStatus { get; set; }
        public int RepDockStatus { get; set; }

        [StringLength(45)]
        public string RepTerminalStatusDesc { get; set; }
        [StringLength(45)]
        public string RepSIMStatusDesc { get; set; }
        [StringLength(45)]
        public string RepDockStatusDesc { get; set; }

        public int ServiceStatusId { get; set; }
        [StringLength(255)]
        public string ServiceStatusDesc { get; set; }

        [StringLength(45)]
        public string ServiceCode { get; set; } = "0";

        public int RegionId { get; set; }
        public int RegionType { get; set; }

        [StringLength(45)]
        public string CounterNo { get; set; } = "0";

        public int DockId { get; set; }
        [StringLength(45)]
        public string DockSerial { get; set; }

        [StringLength(45)]
        public string RequestNo { get; set; }

        [StringLength(255)]
        public string CustomerName { get; set; }
        [StringLength(255)]
        public string CustomerContactNo { get; set; }
        [StringLength(255)]
        public string CustomerPosition { get; set; }
        [StringLength(255)]
        public string CustomerEmail { get; set; }

        public string ProblemReported { get; set; }
        public string Remarks { get; set; }
        public string RMInstruction { get; set; }

        [StringLength(45)]
        public string NewServiceRequest { get; set; }

        public int ReasonId { get; set; }
        public int ExpensesId { get; set; }
        public double TotalExpenses { get; set; }

        [StringLength(45)]
        public string ReferenceNo { get; set; }
        [StringLength(45)]
        public string ProcessedBy { get; set; }
        [StringLength(45)]
        public string ModifiedBy { get; set; }

        public DateTime ProcessedDateTime { get; set; }
        public DateTime ModifiedDateTime { get; set; }

        public int DispatchId { get; set; }
        [StringLength(45)]
        public string DispatchBy { get; set; }
        [StringLength(45)]
        public string DispatchDateTime { get; set; }
        [StringLength(45)]
        public string DispatchDate { get; set; }
        [StringLength(45)]
        public string DispatchTime { get; set; } = "09:00:00";

        public bool IsPrimary { get; set; }
        public bool IsClose { get; set; }

        [StringLength(45)]
        public string AppVersion { get; set; } = "0";
        [StringLength(45)]
        public string AppCRC { get; set; } = "0";

        public bool IsCancelled { get; set; }
        public bool IsBillable { get; set; }

        public int TicketStatus { get; set; }
        public int TicketId { get; set; }
        [StringLength(45)]
        public string TicketDateTime { get; set; }

        public DateTime DateTimeStamp { get; set; }

        public int SourceId { get; set; }
        public int CategoryId { get; set; }
        public int SubCategoryId { get; set; }

        [StringLength(45)]
        public string Vendor { get; set; } = "CITAS";
        [StringLength(45)]
        public string Requestor { get; set; }

        public int AssistNo { get; set; }
        public int ProblemNo { get; set; }

        public bool IsReport { get; set; }
        public int BillingTypeId { get; set; }
        public bool IsActive { get; set; }
    }
}
