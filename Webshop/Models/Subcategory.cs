using System;
using System.Collections.Generic;

namespace Webshop.Models;

public partial class Subcategory
{
    public int SubCategoryId { get; set; }

    public string SubCategoryName { get; set; } = null!;

    public int CategoryId { get; set; }

    public bool? IsActive { get; set; }

    public DateTime? CreatedDate { get; set; }

    public virtual Category Category { get; set; } = null!;

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
