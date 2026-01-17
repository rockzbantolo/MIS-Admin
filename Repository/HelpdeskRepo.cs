using MIS_Admin.Core;
using Next.Clients.Providers;

namespace MIS_Admin.Repository
{
    public class HelpdeskRepo
    {
        private readonly MySqlDb Db;

        public HelpdeskRepo() {
            Db = Database.Instance;
        }

        public async Task<IEnumerable<dynamic>> GetAllHelpdeskRequestAsync(string search = null, int? id = null, int limit = 100)
        {
            string stmt = $@"
                SELECT 
                    j.Description, 
                    h.RequestID,
                    i.MerchantName,
                    p.Name, 
                    s.JobTypeStatusDescription
                FROM tblhddetail h
                JOIN tblparticular p ON p.ParticularID = h.HelpdeskID
                JOIN tblhdmaster m ON m.AssistNo = h.AssistNo
                JOIN tblirdetail i ON i.IRIDNo = m.IRIDNo
                JOIN tblservicetype j ON j.JobType = m.JobType
                LEFT JOIN tblservicingdetail s ON s.ProblemNo = h.ProblemNo
                WHERE (@Id IS NULL OR h.HelpdeskID = @Id)
                    AND h.Status = 'NEGATIVE'
                    AND (s.JobTypeStatusDescription IS NULL OR s.JobTypeStatusDescription <> 'COMPLETED')
                    AND DATE(h.CreatedAt) = CURRENT_DATE()
                    AND (@Search IS NULL OR @Search = '' OR
                        h.RequestID LIKE CONCAT('%', @Search, '%') OR
                        i.MerchantName LIKE CONCAT('%', @Search, '%') OR
                        j.Description LIKE CONCAT('%', @Search, '%')
                    )
                LIMIT {limit};";

            return await Db.QueryAsync<dynamic>(stmt, new { Search = search, Id = id });
        }

        public void Save() { }

        public void Delete() { }

        public void Update() { }

    }
}
