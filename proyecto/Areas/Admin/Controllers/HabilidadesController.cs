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
    public class HabilidadesController : Controller
    {
        private Habilidad habilidades = new Habilidad();

        // GET: Admin/Habilidades
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult Listar(AnexGRID grid)
        {
            return Json(habilidades.Listar(grid, SessionHelper.GetUser()));
        }

        public ActionResult Crud(int id = 0)
        {
            if (id == 0)habilidades.Usuario_id = SessionHelper.GetUser();
            else habilidades = habilidades.Obtener(id);

            return View(habilidades);
        }

        public JsonResult Guardar(Habilidad model)
        {
            var rm = new ResponseModel();
            if (ModelState.IsValid)
            {
                rm = model.Guardar();
                if (rm.response)
                {
                    rm.href = Url.Content("~/admin/habilidades/");
                }
            }
            return Json(rm);
        }

        public JsonResult Eliminar(int id)
        {
            Redirect("~/admin/habilidades/index");
            return Json(habilidades.Eliminar(id), JsonRequestBehavior.AllowGet);
        }
    }
}