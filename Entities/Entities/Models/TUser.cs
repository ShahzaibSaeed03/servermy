using System;
using System.Collections.Generic;

namespace Entities.Models;

public partial class TUser
{
    public int Id { get; set; }

    public int IdRole { get; set; }

    public DateTime CreationDate { get; set; }

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    public DateTime DateEndSubscription { get; set; }

    public int RemainingTokens { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string Address1 { get; set; } = null!;

    public string? Address2 { get; set; }

    public string Zipcode { get; set; } = null!;

    public string City { get; set; } = null!;

    public string? StateRegion { get; set; }

    public int IdCountry { get; set; }

    public string? PhoneNumber { get; set; }

    public string Profession { get; set; } = null!;

    public string HowHearAboutUs { get; set; } = null!;

    public string? CompanyName { get; set; }

    public string? OwnerName { get; set; }

    public string? CompanyOfficialId { get; set; }

    public string BillingAddress1 { get; set; } = null!;

    public string? BillingAddress2 { get; set; }

    public string BillingZipcode { get; set; } = null!;

    public string BillingCity { get; set; } = null!;

    public string? BillingStateRegion { get; set; }

    public int IdBillingCountry { get; set; }

    public string? BillingPhoneNumber { get; set; }

    public virtual TlkpCountry IdCountryNavigation { get; set; } = null!;

    public virtual TlkpRole? IdRoleNavigation { get; set; }
}
