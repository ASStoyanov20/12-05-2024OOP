using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace HrManagement.DataAccess.Models;

public partial class Assignment
{
    [Key]
    public int Id { get; set; }

    public int EmployeeId { get; set; }

    public int ProjectId { get; set; }

    public int HoursWorked { get; set; }

    [StringLength(50)]
    public string Role { get; set; } = null!;

    [ForeignKey("EmployeeId")]
    [InverseProperty("Assignments")]
    public virtual Employee Employee { get; set; } = null!;

    [ForeignKey("ProjectId")]
    [InverseProperty("Assignments")]
    public virtual Project Project { get; set; } = null!;
}
