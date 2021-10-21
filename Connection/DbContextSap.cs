using Microsoft.Extensions.Options;
using SAPbobsCOM;
using SapExtensions.Dtos;
using SapExtensions.Exceptions;

namespace SapExtensions.Connection
{
    public class DbContextSap
    {
        public Company Company { get; }
        public DbContextSap(
            IOptionsMonitor<SapOptions> options
        )
        {
            Company = Connect(options.CurrentValue);
        }
        public Company Connect(SapOptions options)
        {
            var oNewCompany = new Company
            {
                LicenseServer = $"{options.LicenseServer}:{options.Port}",
                Server = options.Server,
                DbServerType = BoDataServerTypes.dst_MSSQL2016,
                CompanyDB = options.CompanyDb,
                UserName = options.UserName,
                Password = options.Password,
                language = BoSuppLangs.ln_Spanish_La
            };
            if (oNewCompany.Connect() == 0) return oNewCompany;
            oNewCompany.GetLastError(out int errorCode, out string errorMessage);
            throw new ConnectionException(errorMessage, errorCode);
        }
        public void Disconnect()
        {
            Company.Disconnect();
        }
        public void ValidateActionSap(int lRetCode, string transactionType)
        {
            if (lRetCode == 0) return;
            Company.GetLastError(out int errorCode, out string errorMessage);
            throw new TransactionError(transactionType, errorMessage, errorCode);
        }

        public TransactionResult GetTransactionResult(int lRetCode, string transactionType)
        {
            if (lRetCode == 0) return new TransactionResult() { Code = lRetCode, Message = "Succesful Transaction" };
            Company.GetLastError(out int errorCode, out string errorMessage);
            return new TransactionResult() { Code = errorCode, Message = errorMessage };
        }
        public bool IsConnected() => Company.Connected;
    }
}
