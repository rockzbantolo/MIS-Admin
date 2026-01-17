using MIS_Admin.Core;
using MIS_Admin.UI.Dto;
using MIS_Admin.UI.Dto.Lookup;
using Next.Clients.Providers;

namespace MIS_Admin.Repository
{
    public class SimRepo
    {
        private readonly MySqlDb Db;

        public SimRepo() {
            Db = Database.Instance;
        }

        public async Task<PaginationDto<SimInfoDto>> GetAllSimCardsAsync(
            int? id = null,
            string search = null,
            IEnumerable<string> filters = null,
            DateTime? startDate = null,
            DateTime? endDate = null,
            int page = 1,
            int pageSize = 100)
        {
            string countStmt = @"
            SELECT COUNT(*)
            FROM vw_sim_info
            WHERE
                (@Id IS NULL OR SIM_ID = @Id)
                AND (@Filters IS NULL OR Status IN @Filters)
                AND (@StartDate IS NULL OR Delivery_Date >= @StartDate)
                AND (@EndDate IS NULL OR Delivery_Date <= @EndDate)
                AND (@Search IS NULL OR @Search = ''
                    OR SIM_SN LIKE CONCAT('%', @Search, '%')
                    OR Carrier LIKE CONCAT('%', @Search, '%')
                    OR Status LIKE CONCAT('%', @Search, '%')
                    OR Location LIKE CONCAT('%', @Search, '%'));";

            var totalCount = await Db.ExecuteScalarAsync<int>(countStmt, new
            {
                Id = id,
                Filters = filters,
                StartDate = startDate,
                EndDate = endDate,
                Search = search
            });

            string dataStmt = @"
            SELECT 
                SIM_ID AS Id,
                SIM_SN AS Serial,
                Status,
                Carrier_ID AS CarrierID,
                Carrier as Description,
                Location,
                Delivery_Date AS DeliveryDate,
                Receive_Date AS ReceiveDate,
                Release_Date AS ReleaseDate
            FROM vw_sim_info
            WHERE
                (@Id IS NULL OR SIM_ID = @Id)
                AND (@Filters IS NULL OR Status IN @Filters)
                AND (@StartDate IS NULL OR Delivery_Date >= @StartDate)
                AND (@EndDate IS NULL OR Delivery_Date <= @EndDate)
                AND (@Search IS NULL OR @Search = ''
                    OR SIM_SN LIKE CONCAT('%', @Search, '%')
                    OR Carrier LIKE CONCAT('%', @Search, '%')
                    OR Status LIKE CONCAT('%', @Search, '%')
                    OR Location LIKE CONCAT('%', @Search, '%'))
            ORDER BY SIM_SN
            LIMIT @PageSize OFFSET @Offset;";

            var data = await Db.QueryAsync<SimInfoDto>(dataStmt, new
            {
                Id = id,
                Filters = filters,
                StartDate = startDate,
                EndDate = endDate,
                Search = search,
                PageSize = pageSize,
                Offset = (page - 1) * pageSize
            });

            return new PaginationDto<SimInfoDto>
            {
                Data = data,
                TotalCount = totalCount,
                Page = page,
                PageSize = pageSize
            };
        }

        public async Task<IEnumerable<DeviceLookupDto>> GetSimsForSelectAsync(
           string search = null, 
           int limit = 10)
        {
            string stmt = @"
            SELECT 
                SIM_ID AS Id,
                SIM_SN AS Serial
            FROM vw_sim_info
            WHERE (@Search IS NULL OR SIM_SN LIKE CONCAT('%', @Search, '%'))
            AND isActive = 1
            ORDER BY SIM_SN
            LIMIT @Limit;";

            return await Db.QueryAsync<DeviceLookupDto>(stmt, new 
            { 
                Search = search,
                Limit = limit }
            );
        }


        public void Save() { }
        public void Delete() { }
        public void Update() { }
    }
}
