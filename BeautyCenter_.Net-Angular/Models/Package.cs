﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BeautyCenter_.Net_Angular.Models;

[Table("Package")]
public partial class Package
{
    [Key]
    public int Id { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string Name { get; set; }

    [Column(TypeName = "decimal(10, 2)")]
    public decimal? Price { get; set; }

    [InverseProperty("Package")]
    public virtual ICollection<PackageUser> ?PackageUsers { get; set; } = new List<PackageUser>();

    [ForeignKey("PackageId")]
    [InverseProperty("Packages")]
    public virtual ICollection<Service> ?Services { get; set; } = new List<Service>();
}