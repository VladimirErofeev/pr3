using System;
using System.Collections.Generic;

namespace pr3;

public partial class TypesProduct
{
    public short Id { get; set; }

    public string TypeProduct { get; set; } = null!;

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
