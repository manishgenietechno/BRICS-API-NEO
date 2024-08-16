using System;
using System.Collections.Generic;

namespace DataService.DBModels;

public partial class Icicialertnotification
{
    public int Id { get; set; }

    public string? AlertSequenceNumber { get; set; }

    public string? VirtualAccount { get; set; }

    public string? AccountNumber { get; set; }

    public string? DebitCredit { get; set; }

    public decimal? Amount { get; set; }

    public string? RemitterName { get; set; }

    public string? RemitterAccount { get; set; }

    public string? RemitterBank { get; set; }

    public string? RemitterIfscCode { get; set; }

    public string? ChequeNumber { get; set; }

    public string? UserReferenceNumber { get; set; }

    public string? MnemonicCode { get; set; }

    public DateOnly? ValueDate { get; set; }

    public DateTime? TransactionDate { get; set; }

    public DateTime? CreatedOn { get; set; }
}
