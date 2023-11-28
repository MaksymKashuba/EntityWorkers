using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EntityWorkers.Models;

public partial class WorkersCountry
{
    [Key]
    public string Country { get; set; } = null!;
    public List<Worker> workers { get; set; } = new();
}
