using System;
using System.Collections.Generic;

namespace Entities.Models;

public partial class TCertificate
{
    public int IdCertificate { get; set; }

    public string? CertificateName { get; set; }

    public DateTime? RegisrrationDate { get; set; }

    public string? Tsa { get; set; }

    public string? IdFile { get; set; }
}
