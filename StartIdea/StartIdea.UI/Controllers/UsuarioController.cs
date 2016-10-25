﻿using Microsoft.Owin.Security;
using StartIdea.DataAccess;
using StartIdea.UI.ViewModels;
using System;
using System.Data.Entity;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;

namespace StartIdea.UI.Controllers
{
    public class UsuarioController : Controller
    {
        private StartIdeaDBContext _dbContext;

        public UsuarioController(StartIdeaDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public ActionResult Index()
        {
            return View(new UsuarioVM());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(UsuarioVM vm)
        {
            if (!ModelState.IsValid)
                return View(vm);

            var identity = (ClaimsIdentity)AuthenticationManager.User.Identity;
            string Id = identity.Claims.Where(c => c.Type == ClaimTypes.NameIdentifier)
                                       .Select(c => c.Value).SingleOrDefault() ?? "0";

            var usuario = _dbContext.Usuarios.Find(Convert.ToInt32(Id));
            usuario.Senha = vm.NovaSenha;
            usuario.TokenActivation = new Guid?();

            _dbContext.Entry(usuario).State = EntityState.Modified;
            _dbContext.SaveChanges();

            vm.CssClassMessage = "text-success";
            ModelState.AddModelError("", "Senha alterada com sucesso.");
            return View(vm);
        }

        private IAuthenticationManager AuthenticationManager
        {
            get { return HttpContext.GetOwinContext().Authentication; }
        }
    }
}