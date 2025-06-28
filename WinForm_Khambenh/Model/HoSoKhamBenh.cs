using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinForm_Khambenh.Model
{
    public class HoSoKhamBenh
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MaHoSo { get; set; }
        public string KhoaKham { get; set; }
        public int MaBenhNhan { get; set; }
        public DateTime NgayKham { get; set; }
        public string LoaiBenh { get; set; }
        public bool CapCuu { get; set; }
    }

}
