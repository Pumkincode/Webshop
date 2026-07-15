using System;
using System.Collections.Generic;

namespace Webshop.Models;

public partial class Productreview
{
    public int ReviewId { get; set; }

    public int Rating { get; set; }

    public string? Comment { get; set; }

    public int ProductId { get; set; }

    public int UserId { get; set; }

    public DateTime? CreatedDate { get; set; }

    public virtual Product Product { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
