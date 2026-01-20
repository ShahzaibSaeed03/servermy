using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace DAL.Models;

public partial class TFaq
{
    public int FaqId { get; set; }

    public int CategoryId { get; set; }

    public string Question { get; set; } = null!;

    public string Answer { get; set; } = null!;

    public virtual TCategory Category { get; set; } = null!;
}
