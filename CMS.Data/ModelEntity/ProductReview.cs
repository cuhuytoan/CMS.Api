﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace CMS.Data.ModelEntity
{
    public partial class ProductReview
    {
        [Key]
        public int Id { get; set; }
        public int? ProductReviewTypeId { get; set; }
        public int? ProductBrandId { get; set; }
        public int? ProductId { get; set; }
        public int? CustomerId { get; set; }
        [Column("QRCodePublicContent")]
        [StringLength(100)]
        public string QrcodePublicContent { get; set; }
        [Column("QRCodeSecretContent")]
        [StringLength(100)]
        public string QrcodeSecretContent { get; set; }
        public int? Star { get; set; }
        [StringLength(100)]
        public string CustomerName { get; set; }
        [StringLength(100)]
        public string Phone { get; set; }
        [StringLength(100)]
        public string Email { get; set; }
        [StringLength(500)]
        public string Address { get; set; }
        [StringLength(4000)]
        public string Content { get; set; }
        public bool? Active { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? CreateDate { get; set; }
        [StringLength(450)]
        public string CreateBy { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? LastEditDate { get; set; }
        [StringLength(450)]
        public string LastEditBy { get; set; }
    }
}