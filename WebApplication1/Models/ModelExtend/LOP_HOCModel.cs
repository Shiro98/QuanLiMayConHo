using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models.ModelExtend
{
    public class LOP_HOCModel
    {
        public int ID { get; set; }
        public string MA_LOP { get; set; }
        public string NAM_HOC { get; set; }
        public string TEN_LOP { get; set; }
        public bool Checked { get; set; } = false;
        public bool Edit { get; set; } = false;
    }
}