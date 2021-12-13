﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace CMS.Data.ModelEntity
{
    public partial class ProductOrder
    {
        [Key]
        public int Id { get; set; }
        public int? ProductOrderStatusId { get; set; }
        public int? ProductOrderPaymentStatusId { get; set; }
        public int? ProductOrderPaymentMethodId { get; set; }
        [StringLength(200)]
        public string BillNumber { get; set; }
        [StringLength(200)]
        public string CustomerName { get; set; }
        [StringLength(50)]
        public string Email { get; set; }
        [StringLength(50)]
        public string Phone { get; set; }
        [StringLength(200)]
        public string Address { get; set; }
        [StringLength(100)]
        public string Voucher { get; set; }
        [StringLength(4000)]
        public string Description { get; set; }
        [Column(TypeName = "money")]
        public decimal? Sum { get; set; }
        [Column(TypeName = "money")]
        public decimal? DisCount { get; set; }
        [Column(TypeName = "money")]
        public decimal? Total { get; set; }
        [StringLength(450)]
        public string CreateBy { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? CreateDate { get; set; }
        [StringLength(450)]
        public string LastEditBy { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? LastEditDate { get; set; }
        public int? LocationId { get; set; }
        public int? DistrictId { get; set; }
        public int? WardId { get; set; }
    }
}