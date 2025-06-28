using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebMVC_GiaoVien_LichGiangDay.Models
{
    public class GiaoVien
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MaGV{ get; set; }
        [Required(ErrorMessage = "Họ và tên không được để trống")]
        public String HoTen { get; set; }
        [Required]
        public String BoMon { get; set; }
        [Required]
        public String SoDienThoai { get; set; }

        public virtual ICollection<LichGiangDay> LichGiangDays { get; set; }

    }
}
