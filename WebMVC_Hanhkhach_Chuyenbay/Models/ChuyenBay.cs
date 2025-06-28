using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace WebMVC_Hanhkhach_Chuyenbay.Models
{
    public class ChuyenBay
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MaChuyenBay { get; set; }

        [Required]
        public int MaHanhKhach { get; set; }

        [Required]
        public DateTime NgayBay { get; set; }

        [Required]
        [Range(0, double.MaxValue, ErrorMessage = "Giá vé phải ≥ 0")]
        public decimal GiaVe { get; set; }

        // Navigation
        [ForeignKey("MaHanhKhach")]
        public virtual HanhKhach? HanhKhach { get; set; }
    }
}
