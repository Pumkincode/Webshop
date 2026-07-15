using System;
using System.Collections.Generic;

namespace Webshop.Models;

public partial class Product
{
    public int ProductId { get; set; }

    public string ProductName { get; set; } = null!;

    public string? ShortDescription { get; set; }

    public string? LongDescription { get; set; }

    public string? AdditionalDescription { get; set; }

    public decimal Price { get; set; }

    public int Quantity { get; set; }

    public string? Size { get; set; }

    public string? Color { get; set; }

    public string? CompanyName { get; set; }

    public int CategoryId { get; set; }

    public int SubCategoryId { get; set; }

    public int Sold { get; set; }

    public bool IsCustomized { get; set; }

    public bool? IsActive { get; set; }

    public DateTime? CreatedDate { get; set; }

    public virtual ICollection<Cart> Carts { get; set; } = new List<Cart>();

    public virtual Category Category { get; set; } = null!;

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    public virtual ICollection<Productimage> Productimages { get; set; } = new List<Productimage>();

    public virtual ICollection<Productreview> Productreviews { get; set; } = new List<Productreview>();

    public virtual Subcategory SubCategory { get; set; } = null!;

    public virtual ICollection<Wishlist> Wishlists { get; set; } = new List<Wishlist>();
}
