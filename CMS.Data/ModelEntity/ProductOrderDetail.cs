﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace CMS.Data.ModelEntity
{
    public partial class ProductOrderDetail
    {
        [Key]
        public int Id { get; set; }
        public int? ProductOrderId { get; set; }
        public int? ProductId { get; set; }
        public int? Quatity { get; set; }
        [Column(TypeName = "money")]
        public decimal? Price { get; set; }
        [Column(TypeName = "money")]
        public decimal? Sum { get; set; }
        [Column(TypeName = "money")]
        public decimal? DisCount { get; set; }
        [Column(TypeName = "money")]
        public decimal? Total { get; set; }
    }
}