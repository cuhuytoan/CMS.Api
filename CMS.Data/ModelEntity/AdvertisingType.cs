// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace CMS.Data.ModelEntity
{
    public partial class AdvertisingType
    {
        /// <summary>
        /// Id tự tăng
        /// </summary>
        [Key]
        public int Id { get; set; }
        /// <summary>
        /// Loại hiển thị: Văn bản, Ảnh, HTML Code
        /// </summary>
        [StringLength(200)]
        public string Name { get; set; }
    }
}