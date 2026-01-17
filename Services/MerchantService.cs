using MIS_Admin.Models;
using MIS_Admin.Repository;
using MIS_Admin.UI.Dto;
using Next.Extention;
using System.Data;

namespace MIS_Admin.Services
{
    public class MerchantService
    {
        private readonly MerchantRepo _repo;

        public MerchantService() {
            _repo = new MerchantRepo();
        }

        public async Task<DataTable> GetMerchants(
           string search = null,
           IEnumerable<string> filter = null,
           int page = 1,
           int pageSize = 100)
        {
            var result = await _repo.GetAllMerchantAsync(
                id: null,
                search: string.IsNullOrWhiteSpace(search) ? null : search.Trim(),
                filters: filter,
                startDate: null,
                endDate: null,
                page: page,
                pageSize: pageSize
            );

            return result.Data.ToDataTable("Stores");
        }

        public async Task<MerchantModel> GetInstallationRecordAsync(int? id = null)
        {
            if (!id.HasValue)
                return null;

            var rawResults = await _repo.GetMerchantInstallationInfoAsync(id.Value);

            var dt = rawResults.ToDataTable("InstallationRequest");

            if (dt.Rows.Count == 0)
                return null;

            var row = dt.Rows[0];

            return new MerchantModel
            {
                RequestNo = row["Request_No"]?.ToString(),
                Merchant = row["Merchant"]?.ToString(),
                TID = row["TID"]?.ToString(),
                MID = row["MID"]?.ToString(),
                ModelName = row["Model_Name"]?.ToString(),
                TerminalSN = row["Terminal_SN"]?.ToString(),
                Carrier = row["Carrier"]?.ToString(),
                SimSN = row["Sim_SN"]?.ToString(),
                Address = row["Address"]?.ToString(),
                ContactPerson = row["Contact_Person"]?.ToString(),
                ContactNo = row["Contact_No"]?.ToString(),
                Email = row["Email"]?.ToString(),
                Region = row["Region"]?.ToString(),
                AppCrc = row["App_Crc"]?.ToString(),
                AppVersion = row["App_Version"]?.ToString(),
                CreatedDate = row["Created_Date"] == DBNull.Value
                                    ? DateTime.MinValue
                                    : Convert.ToDateTime(row["Created_Date"])
            };
        }

        public async Task<DataTable> GetMultiMerchant(int id)
        {
            var data = await _repo.GetMultiMerchant(id);
            return data.ToDataTable("MultiMerchant");
        }

        public async Task<ResultDto> SetReplaceMerchantDeviceAsync(int id, string terminalSn, string simSn)
        {
            return await _repo.ReplaceMerchantDeviceAsync(id, terminalSn, simSn);
        }

        public async Task<ResultDto> SetPullOutMerchantAsync(int IrID)
        {
            if (IrID <= 0)
            {
                return ResultDto.Fail("Invalid merchant/request ID");
            }

            return await _repo.PullOutMerchantAsync(IrID);
        }

        public void Save() {

        }

        public void Delete() {
        
        }

        public void Update() {
        
        }
    }
}
