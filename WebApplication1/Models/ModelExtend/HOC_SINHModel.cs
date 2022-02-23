using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models.ModelExtend
{
    public class HOC_SINHModel
    {
        public long ID_HS { get; set; }
        public int ID_LOP { get; set; }
        public string MA_HS { get; set; }
        public int ID_GV { get; set; }
        public string VANG_CO_PHEP { get; set; }
        public bool VANG_CO_PHEP_BOOL { get; set; }
        public string VANG_KHONG_PHEP { get; set; }
        public bool VANG_KHONG_PHEP_BOOL { get; set; }
        public Nullable<System.DateTime> NGAY_THEO_DOI { get; set; }
        public string NGAY_THEO_DOI_TEXT { get; set; }
        public string BIEU_HIEN_CUA_TRE { get; set; }
        public string TEN_HOC_SINH { get; set; }
        public bool Checked { get; set; } = false;
        public bool Edit { get; set; } = false;
    }
}