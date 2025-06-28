using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebMVC_Hanhkhach_Chuyenbay.Models;

namespace WebMVC_Hanhkhach_Chuyenbay.Models
{
    public class HanhKhach
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MaHanhKhach { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Họ tên tối đa 100 ký tự")]
        public string HoTen { get; set; } = string.Empty;

        [Required]
        [StringLength(20, ErrorMessage = "Số CMND/CCCD tối đa 20 ký tự")]
        public string SoCMND { get; set; } = string.Empty;

        [Required]
        [StringLength(20, ErrorMessage = "Số điện thoại tối đa 20 ký tự")]
        [Phone(ErrorMessage = "Không đúng định dạng số điện thoại")]
        public string SoDT { get; set; } = string.Empty;

        [Required]
        [StringLength(100, ErrorMessage = "Nơi đến tối đa 100 ký tự")]
        public string NoiDen { get; set; } = string.Empty;

        // Navigation
        public virtual ICollection<ChuyenBay>? ChuyenBays { get; set; } 
    }
}
