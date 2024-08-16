using System;
using System.Collections.Generic;

namespace DataService.DBModels;

public partial class Icicilog
{
    public string RequestId { get; set; } = null!;

    public string? Requestbody { get; set; }

    public string? Encryptedrequest { get; set; }

    public string? Encryptedresponse { get; set; }

    public string? Iv { get; set; }

    public string? Response { get; set; }

    public string? Sourceapi { get; set; }

    public string? Errorlog { get; set; }

    public DateTime? Logdatetime { get; set; }
}
