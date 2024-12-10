using System;
using System.Collections.Generic;

namespace pr3;

public partial class Partner
{
    public int Id { get; set; }

    public short IdTypePartner { get; set; }

    public string NamePartner { get; set; } = null!;

    public string Address { get; set; } = null!;

    public string Inn { get; set; } = null!;

    public string DirectorName { get; set; } = null!;

    public string MobilePhone { get; set; } = null!;

    public string Email { get; set; } = null!;

    public int Rating { get; set; }

    public virtual TypeOfPartner IdTypePartnerNavigation { get; set; } = null!;

    public virtual ICollection<PartnersProduct> PartnersProducts { get; set; } = new List<PartnersProduct>();
}
