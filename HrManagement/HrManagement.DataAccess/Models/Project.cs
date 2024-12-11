using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace HrManagement.DataAccess.Models;

public partial class Project
{
    [Key]
    public int Id { get; set; }

    [StringLength(50)]
    public string Name { get; set; } = null!;

    public DateTime StartDate { get; set; }

    public DateTime EndDate { get; set; }

    public int Budgets { get; set; }

    [InverseProperty("Project")]
    public virtual ICollection<Assignment> Assignments { get; set; } = new List<Assignment>();
}
