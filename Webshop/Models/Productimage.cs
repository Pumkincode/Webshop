using System;
using System.Collections.Generic;

namespace Webshop.Models;

public partial class Productimage
{
    public int ImageId { get; set; }

    public string ImageUrl { get; set; } = null!;

    public int ProductId { get; set; }

    public bool DefaultImage { get; set; }

    public virtual Product Product { get; set; } = null!;
}
