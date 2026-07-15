using System;
using System.Collections.Generic;

namespace Webshop.Models;

public partial class Category
{
    public int CategoryId { get; set; }

    public string CategoryName { get; set; } = null!;

    public string? CategoryImageUrl { get; set; }

    public bool? IsActive { get; set; }

    public DateTime? CreatedDate { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();

    public virtual ICollection<Subcategory> Subcategories { get; set; } = new List<Subcategory>();
}
