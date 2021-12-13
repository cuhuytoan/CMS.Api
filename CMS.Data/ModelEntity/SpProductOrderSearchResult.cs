﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace CMS.Data.ModelEntity
{
    public partial class SpProductOrderSearchResult
    {
        public int NoItem { get; set; }
        public int? ProductOrderDetailId { get; set; }
        public int? ProductOrderId { get; set; }
        public int? ProductBrandId { get; set; }
        public string ProductBrandName { get; set; }
        public string ProductBrandImage { get; set; }
        public string ProductBrandUrl { get; set; }
        public int? ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductImage { get; set; }
        public decimal? ProductPrice { get; set; }
        public decimal? ProductPriceOld { get; set; }
        public int? ProductRate { get; set; }
        public string ProductUrl { get; set; }
        public int? ProductOrderDetailQty { get; set; }
        public decimal? ProductOrderDetailPrice { get; set; }
        public decimal? ProductOrderDetailSum { get; set; }
        public decimal? ProductOrderDetailDiscount { get; set; }
        public decimal? ProductOrderDetailTotal { get; set; }
        public int? ProductOrderStatusId { get; set; }
        public int? ProductOrderPaymentStatusId { get; set; }
        public int? ProductOrderPaymentMethodId { get; set; }
        public string BillNumber { get; set; }
        public string CustomerName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string Voucher { get; set; }
        public string Description { get; set; }
        public decimal? Sum { get; set; }
        public decimal? DisCount { get; set; }
        public decimal? Total { get; set; }
        public string CreateBy { get; set; }
        public DateTime? CreateDate { get; set; }
        public string LastEditBy { get; set; }
        public DateTime? LastEditDate { get; set; }
        public int? LocationId { get; set; }
        public int? DistrictId { get; set; }
        public int? WardId { get; set; }
        public string ProductOrderPaymentMethodName { get; set; }
        public string ProductOrderPaymentStatusName { get; set; }
        public string ProductOrderStatusName { get; set; }
    }
    
}
