using System;
using System.Collections.Generic;

namespace kipas_Odev.Models;

public partial class Personel
{
    public int Id { get; set; }

    public string? Title { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public DateOnly? BirthDate { get; set; }

    public string? Position { get; set; }

    public DateOnly? HireDate { get; set; }

    public string? State { get; set; }

    public string? Address { get; set; }

    public string? Notes { get; set; }

    public DateTime CreatedAt { get; set; }
}
