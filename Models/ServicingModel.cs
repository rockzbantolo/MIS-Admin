using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace MIS_Admin.Models
{
    public class ServiceRecord
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ServiceNo { get; set; }                      // PRI, auto_increment

        public int IRIDNo { get; set; }                         // default 0, indexed

        [StringLength(45)]
        public string IRNo { get; set; } = string.Empty;        // varchar(45), indexed

        public int JobType { get; set; }                        // default 0, indexed

        [StringLength(255)]
        public string JobTypeDescription { get; set; }         // nullable

        [StringLength(255)]
        public string JobTypeSubDescription { get; set; }

        [StringLength(255)]
        public string JobTypeStatusDescription { get; set; }

        public int MerchantID { get; set; }                     // default 0, indexed
        [StringLength(255)]
        public string MerchantName { get; set; }

        public int TerminalID { get; set; }                     // default 0, indexed

        [StringLength(45)]
        public string TerminalSN { get; set; }                 // nullable, indexed

        public int SIMID { get; set; }                          // default 0, indexed

        [StringLength(45)]
        public string SIMSerialNo { get; set; } = string.Empty; // NOT NULL, indexed

        public int ReplaceTerminalID { get; set; }             // nullable
        [StringLength(45)]
        public string ReplaceTerminalSN { get; set; }

        public int ReplaceSIMID { get; set; }
        [StringLength(45)]
        public string ReplaceSIMSN { get; set; }

        public int ReplaceDockID { get; set; }
        [StringLength(45)]
        public string ReplaceDockSN { get; set; }

        [StringLength(45)]
        public string ReplacePowerSN { get; set; }

        public int FEID { get; set; }                           // default 0, indexed
        [StringLength(45)]
        public string FEName { get; set; }

        public int ClientID { get; set; }                       // default 0, indexed
        [StringLength(255)]
        public string ClientName { get; set; }

        [StringLength(1000)]
        public string ActionMade { get; set; }

        public DateTime ServiceDateTime { get; set; }          // nullable datetime

        [StringLength(45)]
        public string ServiceDate { get; set; }                // varchar date (string)

        [StringLength(45)]
        public string ServiceTime { get; set; } = "09:00:00";

        [StringLength(45)]
        public string ReqInstallationDate { get; set; }

        [StringLength(45)]
        public string ReqInstallationTime { get; set; } = "09:00:00";

        [StringLength(45)]
        public string ServiceReqDate { get; set; }

        [StringLength(45)]
        public string ServiceReqTime { get; set; } = "09:00:00";

        [StringLength(45)]
        public string ReportedDate { get; set; } = "0000-00-00";

        [StringLength(45)]
        public string LastServiceRequest { get; set; }

        public int CurTerminalSNStatus { get; set; } = 0;
        public int CurSIMSNStatus { get; set; } = 0;
        public int CurDockSNStatus { get; set; } = 0;

        [StringLength(45)]
        public string CurTerminalSNStatusDescription { get; set; }

        [StringLength(45)]
        public string CurSIMSNStatusDescription { get; set; }

        [StringLength(45)]
        public string CurDockSNStatusDescription { get; set; }

        public int RepTerminalSNStatus { get; set; } = 0;
        public int RepSIMSNStatus { get; set; } = 0;
        public int RepDockSNStatus { get; set; } = 0;

        [StringLength(45)]
        public string RepTerminalSNStatusDescription { get; set; }
        [StringLength(45)]
        public string RepSIMSNStatusDescription { get; set; }
        [StringLength(45)]
        public string RepDockSNStatusDescription { get; set; }

        public int ServiceStatus { get; set; } = 0;            // indexed
        [StringLength(255)]
        public string ServiceStatusDescription { get; set; }

        [StringLength(45)]
        public string ServiceCode { get; set; } = "0";

        public int RegionID { get; set; } = 0;                 // indexed
        public int RegionType { get; set; } = 0;               // indexed

        [StringLength(45)]
        public string CounterNo { get; set; } = "0";

        public int DockID { get; set; } = 0;
        [StringLength(45)]
        public string DockSN { get; set; }

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

        public string ProblemReported { get; set; }            // longtext
        public string Remarks { get; set; }                    // longtext
        public string RMInstruction { get; set; }              // longtext

        [StringLength(45)]
        public string NewServiceRequest { get; set; }

        public int ReasonID { get; set; } = 0;                 // indexed
        public int ExpensesID { get; set; } = 0;               // indexed

        public double TExpenses { get; set; } = 0;

        [StringLength(45)]
        public string ReferenceNo { get; set; }

        [StringLength(45)]
        public string ProcessedBy { get; set; }

        [StringLength(45)]
        public string ModifiedBy { get; set; }

        public DateTime ProcessedDateTime { get; set; }
        public DateTime ModifiedDateTime { get; set; }

        public int DispatchID { get; set; } = 0;               // indexed

        [StringLength(45)]
        public string DispatchBy { get; set; }

        [StringLength(45)]
        public string DispatchDateTime { get; set; }

        [StringLength(45)]
        public string DispatchDate { get; set; }

        [StringLength(45)]
        public string DispatchTime { get; set; } = "09:00:00";

        public int isPrimary { get; set; } = 0;
        public int isClose { get; set; } = 0;

        [StringLength(45)]
        public string AppVersion { get; set; } = "0";

        [StringLength(45)]
        public string AppCRC { get; set; } = "0";

        public bool isCancelled { get; set; } = false;         // tinyint(1)

        public int isBillable { get; set; } = 1;               // indexed

        public int TicketStatus { get; set; } = 0;
        public int TicketID { get; set; } = 0;

        [StringLength(45)]
        public string TicketDateTime { get; set; } = "0";

        public DateTime DateTimeStamp { get; set; }            // auto CURRENT_TIMESTAMP

        public int SourceID { get; set; } = 0;                 // indexed
        public int CategoryID { get; set; } = 0;               // indexed
        public int SubCategoryID { get; set; } = 0;            // indexed

        [StringLength(45)]
        public string Vendor { get; set; } = "CITAS";

        [StringLength(45)]
        public string Requestor { get; set; }

        public int AssistNo { get; set; }                       // NOT NULL, default 0
        public int ProblemNo { get; set; }                      // NOT NULL, default 0

        public bool isReport { get; set; } = true;             // tinyint(1)

        public int BillingTypeID { get; set; } = 0;            // indexed

        public bool isActive { get; set; } = true;             // tinyint(1), indexed
    }

}
