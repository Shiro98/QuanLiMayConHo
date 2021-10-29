using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models.ModelExtend
{
    public class GIAO_VIENModel
    {
        public long ID { get; set; }
        public string HO_TEN { get; set; }
        public string CHUC_VU { get; set; }
        public string TRINH_DO { get; set; }
        public string CHUYEN_MON { get; set; }
        public string DIA_CHI { get; set; }
        public string SO_DIEN_THOAI { get; set; }
        public bool Checked { get; set; } = false;
        public bool Edit { get; set; } = false;
    }
}