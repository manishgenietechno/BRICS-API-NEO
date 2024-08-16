using Newtonsoft.Json;
namespace BRICS_API_Neo.Models
{
    public class ConfigurationModel
    {

        public string? CorpId { get; set; }

        public string? UserId { get; set; }

        public string? AggrId { get; set; }

        public string? Urn { get; set; }

        public string? BalanceApiUrl {  get; set; }

        public string? AccountStatementApiUrl {  get; set; }

        public string? ApiKey { get; set; }

        public string? SecreatKey { get; set; }

        public string? BalanceAccountNumber { get; set; }

        public string? StatementAccountNumber { get; set; }

        public string? StatementFromDate { get; set; }

        public string? StatementToDate { get; set; }
    }
}
