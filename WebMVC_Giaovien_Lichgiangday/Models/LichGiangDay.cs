using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebMVC_GiaoVien_LichGiangDay.Models
{
    public class LichGiangDay
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MaLich { get; set; }
        [Required]
        public int MaGV { get; set; }
        [Required]
        public String TenMonHoc { get; set; }
        [Required]
        public DateTime NgayGiangDay { get; set; }

        [ForeignKey("MaGV")]
        public virtual GiaoVien ? GiaoVien { get; set; }

    }
}
