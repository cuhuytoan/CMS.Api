using CMS.Data.ModelEntity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CMS.Data.ModelDTO
{
    public class ProductDTO
    {
        /// <summary>
        /// Id tự tăng
        /// </summary>        
        public int? Id { get; set; }
        /// <summary>
        /// Kiểu sản phẩm
        /// </summary>
        public int? ProductTypeId { get; set; }
        /// <summary>
        /// Chủng loại hàng hóa
        /// </summary>
        [StringLength(200)]
        [Required(ErrorMessage = "Chọn chủng loại hàng hóa")]
        public string ProductCategoryIds { get; set; }
        /// <summary>
        /// Hãng sản xuất
        /// </summary>
        /// 
        [Required(ErrorMessage = "Chọn hãng sản xuất")]
        public int? ProductManufactureId { get; set; }
        /// <summary>
        /// Doanh nghiệp
        /// </summary>
        public int? ProductBrandId { get; set; }
        /// <summary>
        /// Xuất xứ
        /// </summary>
        /// 
        [Required(ErrorMessage = "Chọn xuất xứ")]
        public int? CountryId { get; set; }
        /// <summary>
        /// Trạng thái sản phẩm
        /// </summary>
        public int? ProductStatusId { get; set; }
        /// <summary>
        /// Tên sản phẩm
        /// </summary>
        /// 
        [Required(ErrorMessage = "Nhập tên sản phẩm")]
        [StringLength(1000)]
        public string Name { get; set; }
        /// <summary>
        /// Mã vạch sản phẩm
        /// </summary>
        [StringLength(50)]
        public string BarCode { get; set; }
        /// <summary>
        /// Mã QRCode sản phẩm
        /// </summary>        
        [StringLength(100)]
        public string QrcodePublic { get; set; }
        /// <summary>
        /// Tiêu đề phụ (chưa dùng)
        /// </summary>
        [StringLength(200)]
        public string SubTitle { get; set; }
        /// <summary>
        /// Tên file ảnh đại diện chính
        /// </summary>
        [StringLength(200)]
        public string Image { get; set; }
        /// <summary>
        /// (chưa dùng)
        /// </summary>
        [StringLength(200)]
        public string ImageDescription { get; set; }
        /// <summary>
        /// (chưa dùng)
        /// </summary>
        [StringLength(200)]
        public string BannerImage { get; set; }
        /// <summary>
        /// Mô tả tóm lược sản phẩm
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// Mô tả chi tiết sản phẩm
        /// </summary>     
        public string Content { get; set; }
        /// <summary>
        /// Thông số kỹ thuật
        /// </summary>
        [Column(TypeName = "ntext")]
        public string Specification { get; set; }
        /// <summary>
        /// Các chứng chỉ đạt được
        /// </summary>
        [Column(TypeName = "ntext")]
        public string ProductCertificate { get; set; }
        /// <summary>
        /// Thông tin pháp lý
        /// </summary>
        [StringLength(4000)]
        public string LegalInfo { get; set; }
        /// <summary>
        /// Giá
        /// </summary>
        [Column(TypeName = "money")]
        public decimal? Price { get; set; }
        /// <summary>
        /// Giá cũ (để mờ hoặc gạch ngang)
        /// </summary>
        [Column(TypeName = "money")]
        public decimal? PriceOld { get; set; }
        /// <summary>
        /// Giảm giá (tính bằng tiền)
        /// </summary>
        [Column(TypeName = "money")]
        public decimal? Discount { get; set; }
        /// <summary>
        /// Giảm giá (tính bằng %)
        /// </summary>
        public int? DiscountRate { get; set; }
        /// <summary>
        /// Hàng cũ
        /// </summary>
        public bool? IsSecondHand { get; set; }
        /// <summary>
        /// Hàng chính hãng
        /// </summary>
        public bool? IsAuthor { get; set; }
        /// <summary>
        /// Hàng bán chạy
        /// </summary>
        public bool? IsBestSale { get; set; }
        /// <summary>
        /// Hàng giảm giá
        /// </summary>
        public bool? IsSaleOff { get; set; }
        /// <summary>
        /// Hàng mới về
        /// </summary>
        public bool? IsNew { get; set; }
        /// <summary>
        /// Hàng sắp về
        /// </summary>
        public bool? IsComming { get; set; }
        /// <summary>
        /// Hết hàng
        /// </summary>
        public bool? IsOutStock { get; set; }
        /// <summary>
        /// Ngừng kinh doanh
        /// </summary>
        public bool? IsDiscontinue { get; set; }
        /// <summary>
        /// Khối lượng
        /// </summary>
        public int? AmountDefault { get; set; }
        /// <summary>
        /// Đơn vị tính
        /// </summary>
        public int? UnitId { get; set; }
        /// <summary>
        /// Hạn sử dụng hiển thị trên web
        /// </summary>
        [StringLength(500)]
        public string ExpiryDisplay { get; set; }
        /// <summary>
        /// Hạn sử dụng tính theo ngày
        /// </summary>
        public int? ExpiryByDay { get; set; }
        /// <summary>
        /// Thời gian bảo hành hiển thị trên web
        /// </summary>
        [StringLength(500)]
        public string WarrantyDisplay { get; set; }
        /// <summary>
        /// Thời gian bảo hành tính theo tháng
        /// </summary>
        public int? WarrantyByMonth { get; set; }
        /// <summary>
        /// Điểm đánh giá
        /// </summary>
        public int? Rate { get; set; }
        /// <summary>
        /// Ngày bắt đầu đăng
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? StartDate { get; set; }
        /// <summary>
        /// Ngày kết thúc đăng +100 năm
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? EndDate { get; set; }
        /// <summary>
        /// Hoạt động
        /// </summary>
        public bool? Active { get; set; }
        /// <summary>
        /// Số lượt xem
        /// </summary>
        public int? Counter { get; set; }
        public int? LikeCount { get; set; }
        /// <summary>
        /// Số lượt bán
        /// </summary>
        public int? SellCount { get; set; }
        /// <summary>
        /// Người tạo
        /// </summary>
        [StringLength(450)]
        public string CreateBy { get; set; }
        /// <summary>
        /// Thời gian tạo
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? CreateDate { get; set; }
        /// <summary>
        /// Người chỉnh sửa cuối cùng
        /// </summary>
        [StringLength(450)]
        public string LastEditBy { get; set; }
        /// <summary>
        /// Thời gian chỉnh sửa cuối cùng
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? LastEditDate { get; set; }
        /// <summary>
        /// Trạng thái kiểm tra
        /// </summary>
        public int? Checked { get; set; }
        /// <summary>
        /// Người Kiểm tra
        /// </summary>
        [StringLength(450)]
        public string CheckBy { get; set; }
        /// <summary>
        /// Thời gian kiểm tra
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? CheckDate { get; set; }
        /// <summary>
        /// Trạng thái duyệt
        /// </summary>
        public int? Approved { get; set; }
        /// <summary>
        /// Người duyệt
        /// </summary>
        [StringLength(450)]
        public string ApproveBy { get; set; }
        /// <summary>
        /// Thời gian duyệt
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? ApproveDate { get; set; }
        /// <summary>
        /// Đường dẫn
        /// </summary>
        [Column("URL")]
        [StringLength(1000)]
        public string Url { get; set; }
        /// <summary>
        /// Tag (cách nhau dấu ,)
        /// </summary>
        public string Tags { get; set; }
        /// <summary>
        /// Cho phép copy trên giao diện người dùng
        /// </summary>
        public bool? CanCopy { get; set; }
        /// <summary>
        /// Cho phép comment
        /// </summary>
        public bool? CanComment { get; set; }
        /// <summary>
        /// Cho phép xóa
        /// </summary>
        public bool? CanDelete { get; set; }
        /// <summary>
        /// Thẻ SEO
        /// </summary>
        [StringLength(500)]
        public string MetaTitle { get; set; }
        /// <summary>
        /// Thẻ SEO
        /// </summary>
        [StringLength(500)]
        public string MetaDescription { get; set; }
        /// <summary>
        /// Thẻ SEO
        /// </summary>
        [StringLength(500)]
        public string MetaKeywords { get; set; }
        /// <summary>
        /// Tài liệu tham khảo
        /// </summary>
        [StringLength(500)]
        public string DocumentRefer { get; set; }
        public string ProductBrandName { get; set; }
        public string ProductCategoryIdsName { get; set; }
        public string CountryName { get; set; }
        public string UnitName { get; set; }
        public int QtyInCart { get; set; }
        public int TotalProductReview { get; set; }
        public int AveragePointReview { get; set; }
       
    }
    public class ProductPropertiesDTO
    {
        public List<ProductPropertiesCategoryDTO> lstProductPropertyCate { get; set; } = new();
    }

    public class ProductPropertiesCategoryDTO : ProductPropertyCategory
    {
        public List<SpGetLstProductPropertiesResult> lstProductProperties { get; set; } = new();
    }
    public class ProductCategoryGroupDTO
    {
        public ProductCategory Item1 { get; set; }
        public ProductCategory Item2 { get; set; }
    }
    public class ProductGroupDTO
    {
        public SpProductSearchResult Item1 { get; set; }
        public SpProductSearchResult Item2 { get; set; }
    }
    public class ProductCategoryTreeGroup
    {
        public SpProductCategoryTreeResult ParentItem { get; set; } = new();
        public List<SpProductCategoryTreeResult> ChildItem { get; set; } = new();
    }
    public class ProductCartDTO
    {
        public ProductBrandDTO productBrand { get; set; } = new();
        public List<ProductDTO> lstProduct { get; set; } = new();
    }
    public class ProductReviewAverageDTO
    {
        public int TotalProductReview { get; set; } = 0;
        public int AveragePointReview { get; set; } = 0;
    }
    public class ProductReviewDTO
    {

    }
}
