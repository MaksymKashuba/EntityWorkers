using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EntityWorkers.Models;

public partial class WorkersCity
{
    [Key]
    public string City { get; set; } = null!;
    public List<Worker> workers { get; set; } = new();
}
