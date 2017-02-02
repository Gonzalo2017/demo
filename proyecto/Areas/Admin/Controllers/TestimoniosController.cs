using Helper;
using Model;
using proyecto.Areas.Admin.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace proyecto.Areas.Admin.Controllers
{
    [Autenticado]
    public class TestimoniosController : Controller
    {
        private Testimonio testimonio = new Testimonio();
        private TablaDato dato = new TablaDato();

        // GET: Admin/Testimonios
        public ActionResult Index()
        {
            ViewBag.Estado = dato.Listar("testimonioestado");
            return View();
        }

        public JsonResult Listar(AnexGRID grid)
        {
            return Json(testimonio.Listar(grid, SessionHelper.GetUser()));
        }

        public ActionResult Crud(int id)
        {
            return View(testimonio.Obtener(id));
        }

        public JsonResult Guardar(Testimonio model)
        {
            var rm = new ResponseModel();
            if (ModelState.IsValid)
            {
                rm = model.Guardar();
                if (rm.response)
                {
                    rm.href = Url.Content("~/admin/testimonios/");
                }
            }
            return Json(rm);
        }

        public JsonResult Eliminar(int id)
        {
            Redirect("~/admin/testimonios/index");
            return Json(testimonio.Eliminar(id), JsonRequestBehavior.AllowGet);
        }
    }
}