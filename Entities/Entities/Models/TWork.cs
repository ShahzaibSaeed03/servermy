using System;
using System.Collections.Generic;

namespace Entities.Models;

public partial class TWork
{
    public int IdWork { get; set; }

    public int? IdClient { get; set; }

    public int? NumberForClient { get; set; }

    public string? DisplayedId { get; set; }

    public bool? Status { get; set; }

    public string? Title { get; set; }

    public string? CopyrightOwner { get; set; }

    public string? AdditionalCopyrightOwners { get; set; }

    public DateTime? RegisrrationDate { get; set; }

    public string? FileName { get; set; }

    public string? FileFingerprint { get; set; }

    public string? IdFile { get; set; }

    public int? IdCertificate { get; set; }
}
