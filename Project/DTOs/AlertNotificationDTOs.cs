namespace BRICS_API_NEO.DTOs
{
    public class AlertNotificationDTOs
    {
        public string AlertSequenceNo { get; set; }

        public string VirtualAccount { get; set; }

        public string AccountNumber { get; set; }

        public string DebitCredit { get; set; }

        public decimal Amount { get; set; }

        public string RemitterName { get; set; }

        public string RemitterAccount { get; set; }

        public string RemitterBank { get; set; }

        public string RemitterIfsc { get; set; }

        public string ChequeNo { get; set; }

        public string UserReferenceNumber { get; set; }

        public string MnemonicCode { get; set; }

        public DateOnly? ValueDate { get; set; }

        public DateTime? TransactionDate { get; set; }
    }
}
