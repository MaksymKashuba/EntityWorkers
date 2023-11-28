using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;

namespace EntityWorkers.Models;

public partial class Worker
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Age { get; set; }

    public string WorkersCityCity { get; set; }
    public WorkersCity City { get; set; } = null!;
    public string WorkersCountryCountry { get; set; }
    public WorkersCountry Country { get; set; } = null!;
}
