using Common;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;
using WebApplication1.Models.ModelExtend;

namespace WebApplication1.Controllers
{
    //[Authorize]
    public class HomeController : Controller
    {
        private QuanLiEntities _db = new QuanLiEntities();
        public ActionResult Index()
        {
            if (Session["idUser"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index","Login");
            }
        }

        public ActionResult About()
        {
            ViewBag.Message = "Student";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Teacher";

            return View();
        }
        public ActionResult Classroom()
        {
            ViewBag.Message = "Classroom";

            return View();
        }
        [HttpPost]
        public ActionResult Search(string kyword)
        {
            try
            {
                var data = _db.GIAO_VIEN.Select(x => new GIAO_VIENModel
                {
                    ID = x.ID,
                    HO_TEN = x.HO_TEN,
                    CHUC_VU = x.CHUC_VU,
                    TRINH_DO = x.TRINH_DO,
                    DIA_CHI = x.DIA_CHI,
                    CHUYEN_MON = x.CHUYEN_MON,
                    SO_DIEN_THOAI = x.SO_DIEN_THOAI,
                }).ToList();
                return Json(new { data = data, Error = false, Title = "Lấy dữ liệu thành công" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {

                return Json(new { Error = true, Title = "Lấy dữ liệu không thành công: " + ex }, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpPost]
        public ActionResult Add(List<GIAO_VIENModel> ds)
        {
            try
            {
                foreach(var i in ds)
                {
                    var insertDB = new GIAO_VIEN();
                    insertDB.HO_TEN = i.HO_TEN;
                    insertDB.CHUC_VU = i.CHUC_VU;
                    insertDB.TRINH_DO = i.TRINH_DO;
                    insertDB.DIA_CHI = i.DIA_CHI;
                    insertDB.CHUYEN_MON = i.CHUYEN_MON;
                    insertDB.SO_DIEN_THOAI = i.SO_DIEN_THOAI;
                    _db.GIAO_VIEN.Add(insertDB);
                    _db.SaveChanges();
                }
                return Json(new { Error = false });
            }
            catch (Exception ex)
            {
                return Json(new { Error = true, Title = ex.Message });
            }
        }
        [HttpPost]
        public ActionResult Delete(List<GIAO_VIENModel> dt)
        {
            try
            {
                foreach(var i in dt)
                {
                    var delete = (from d in _db.GIAO_VIEN
                                  where d.ID == i.ID
                                  select d).Single();
                    //delete.IS_HIEU_LUC = "N";
                    _db.GIAO_VIEN.Remove(delete);
                    _db.SaveChanges();
                }

                return Json(new { Error = false });
            }
            catch (Exception ex)
            {
                return Json(new { Error = true, Title = ex.Message });
            }
        }
        [HttpPost]
        public ActionResult edit(List<GIAO_VIENModel> ds)
        {
            
            try
            {
                foreach (GIAO_VIENModel i in ds)
                {
                    var update = (from d in _db.GIAO_VIEN where d.ID == i.ID select d).Single();
                    update.HO_TEN = i.HO_TEN;
                    update.CHUC_VU = i.CHUC_VU;
                    update.TRINH_DO = i.TRINH_DO;
                    update.DIA_CHI = i.DIA_CHI;
                    update.CHUYEN_MON = i.CHUYEN_MON;
                    update.SO_DIEN_THOAI = i.SO_DIEN_THOAI;
                    _db.SaveChanges();
                }
                return Json(new { Error = false });
            }
            catch (Exception ex)
            {
                return Json(new { Error = true, Title = ex.Message });
            }
        }
        [HttpPost]
        public ActionResult SearchClass(string kyword)
        {
            try
            {
                var data = _db.LOP_HOC.Select(x => new LOP_HOCModel
                {
                    ID = x.ID,
                    MA_LOP = x.MA_LOP,
                    TEN_LOP = x.TEN_LOP,
                    NAM_HOC = x.NAM_HOC,
                }).ToList();
                return Json(new { data = data, Error = false, Title = "Lấy dữ liệu thành công" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {

                return Json(new { Error = true, Title = "Lấy dữ liệu không thành công: " + ex }, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpPost]
        public ActionResult Addclass(List<LOP_HOCModel> ds)
        {
            try
            {
                foreach (var i in ds)
                {
                    var insertDB = new LOP_HOC();
                    insertDB.MA_LOP = i.MA_LOP;
                    insertDB.TEN_LOP = i.TEN_LOP;
                    insertDB.NAM_HOC = i.NAM_HOC;
                    _db.LOP_HOC.Add(insertDB);
                    _db.SaveChanges();
                }
                return Json(new { Error = false });
            }
            catch (Exception ex)
            {
                return Json(new { Error = true, Title = ex.Message });
            }
        }
        [HttpPost]
        public ActionResult Deleteclass(List<LOP_HOCModel> dt)
        {
            try
            {
                foreach (var i in dt)
                {
                    var delete = (from d in _db.LOP_HOC
                                  where d.ID == i.ID
                                  select d).Single();
                    //delete.IS_HIEU_LUC = "N";
                    _db.LOP_HOC.Remove(delete);
                    _db.SaveChanges();
                }

                return Json(new { Error = false });
            }
            catch (Exception ex)
            {
                return Json(new { Error = true, Title = ex.Message });
            }
        }
        [HttpPost]
        public ActionResult editclass(List<LOP_HOCModel> ds)
        {

            try
            {
                foreach (LOP_HOCModel i in ds)
                {
                    var update = (from d in _db.LOP_HOC where d.ID == i.ID select d).Single();
                    update.MA_LOP = i.MA_LOP;
                    update.TEN_LOP = i.TEN_LOP;
                    update.NAM_HOC = i.NAM_HOC;
                    _db.SaveChanges();
                }
                return Json(new { Error = false });
            }
            catch (Exception ex)
            {
                return Json(new { Error = true, Title = ex.Message });
            }
        }
        [HttpPost]
        public ActionResult SearchStu(string kyword)
        {
            try
            {
                var data = _db.HOC_SINH.Select(x => new HOC_SINHModel
                {
                    ID_HS = x.ID_HS,
                    ID_LOP = x.ID_LOP,
                    MA_HS = x.MA_HS,
                    ID_GV = x.ID_GV,
                    VANG_CO_PHEP = x.VANG_CO_PHEP,
                    VANG_KHONG_PHEP = x.VANG_KHONG_PHEP,
                    NGAY_THEO_DOI = x.NGAY_THEO_DOI,
                    BIEU_HIEN_CUA_TRE = x.BIEU_HIEN_CUA_HOC_SINH,
                    TEN_HOC_SINH = x.TEN_HOC_SINH,
                }).ToList();
                foreach (var i in data)
                {
                    i.NGAY_THEO_DOI_TEXT =  Convert.ToDateTime(i.NGAY_THEO_DOI).ToString("MM/dd/yyyy");
                    if (String.Compare(i.VANG_CO_PHEP, "Y", true) == 0)
                    {
                        i.VANG_CO_PHEP_BOOL = true;
                    }
                    else i.VANG_CO_PHEP_BOOL = false;
                    if (String.Compare(i.VANG_KHONG_PHEP, "Y", true) == 0)
                    {
                        i.VANG_KHONG_PHEP_BOOL = true;
                    }
                    else i.VANG_KHONG_PHEP_BOOL = false;
                }
                return Json(new { data = data, Error = false, Title = "Lấy dữ liệu thành công" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {

                return Json(new { Error = true, Title = "Lấy dữ liệu không thành công: " + ex }, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpPost]
        public ActionResult Addstu(List<HOC_SINHModel> ds)
        {
            try
            {
                foreach (var i in ds)
                {
                    var insertDB = new HOC_SINH();
                    insertDB.ID_LOP = i.ID_LOP;
                    insertDB.MA_HS = i.MA_HS;
                    insertDB.ID_GV = i.ID_GV;
                    if (i.VANG_CO_PHEP_BOOL == true)
                    {
                        insertDB.VANG_CO_PHEP = "Y";
                    }
                    else insertDB.VANG_CO_PHEP = "N";
                    if (i.VANG_KHONG_PHEP_BOOL == true)
                    {
                        insertDB.VANG_KHONG_PHEP = "Y";
                    }
                    else insertDB.VANG_KHONG_PHEP = "N";
                    insertDB.NGAY_THEO_DOI = DateTime.Now;
                    insertDB.BIEU_HIEN_CUA_HOC_SINH = i.BIEU_HIEN_CUA_TRE;
                    insertDB.TEN_HOC_SINH = i.TEN_HOC_SINH;
                    _db.HOC_SINH.Add(insertDB);
                    _db.SaveChanges();
                }
                return Json(new { Error = false });
            }
            catch (Exception ex)
            {
                return Json(new { Error = true, Title = ex.Message });
            }
        }
        [HttpPost]
        public ActionResult DeleteStu(List<HOC_SINHModel> dt)
        {
            try
            {
                foreach (var i in dt)
                {
                    var delete = (from d in _db.HOC_SINH
                                  where d.ID_HS == i.ID_HS
                                  select d).Single();
                    //delete.IS_HIEU_LUC = "N";
                    _db.HOC_SINH.Remove(delete);
                    _db.SaveChanges();
                }

                return Json(new { Error = false });
            }
            catch (Exception ex)
            {
                return Json(new { Error = true, Title = ex.Message });
            }
        }
        [HttpPost]
        public ActionResult editStu(List<HOC_SINHModel> ds)
        {

            try
            {
                foreach (HOC_SINHModel i in ds)
                {
                    var update = (from d in _db.HOC_SINH where d.ID_HS == i.ID_HS select d).Single();
                    update.ID_LOP = i.ID_LOP;
                    update.MA_HS = i.MA_HS;
                    update.ID_GV = i.ID_GV;
                    if (i.VANG_CO_PHEP_BOOL == true)
                    {
                        update.VANG_CO_PHEP = "Y";
                    }
                    else update.VANG_CO_PHEP = "N";
                    if (i.VANG_KHONG_PHEP_BOOL == true)
                    {
                        update.VANG_KHONG_PHEP = "Y";
                    }
                    else update.VANG_KHONG_PHEP = "N";
                    update.NGAY_THEO_DOI = DateTime.Now;
                    update.BIEU_HIEN_CUA_HOC_SINH = i.BIEU_HIEN_CUA_TRE;
                    update.TEN_HOC_SINH = i.TEN_HOC_SINH;
                    _db.SaveChanges();
                }
                return Json(new { Error = false });
            }
            catch (Exception ex)
            {
                return Json(new { Error = true, Title = ex.Message });
            }
        }
    }
}