using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web.Mvc;
using DataAccess.Entity;
using DataAccess.Repository;
using PhoneBook.Filters;
using PhoneBook.ViewModels.Shared;
using PhoneBook.ViewModels.Users;

namespace PhoneBook.Controllers
{
    [AuthenticationFilter]
    public class UsersController : Controller
    {
        public ActionResult Index(IndexVM model)
        {
            model.Pager = model.Pager ?? new PagerVM();
            model.Pager.Page = model.Pager.Page <= 0 ? 1 : model.Pager.Page;
            model.Pager.ItemsPerPage = model.Pager.ItemsPerPage <= 0 ? 10 : model.Pager.ItemsPerPage;

            model.Filter = model.Filter ?? new FilterVM();
            Expression<Func<User, bool>> filter = model.Filter.GenerateFilter();

            UsersRepository repo = new UsersRepository();
            model.Items = repo.GetAll(filter, model.Pager.Page, model.Pager.ItemsPerPage);
            model.Pager.PagesCount = (int)Math.Ceiling(repo.Count(filter) / (double)(model.Pager.ItemsPerPage));

            return View(model);
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            User item = null;

            UsersRepository repo = new UsersRepository();
            item = id == null ? new User() : repo.GetById(id.Value);

            EditVM model = new EditVM(item);

            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(EditVM model)
        {
            if(!ModelState.IsValid)
            {
                return View(model);
            }

            UsersRepository repo = new UsersRepository();
            User item = new User();
            model.PopulateEntity(item);

            repo.Save(item);

            return RedirectToAction("Index", "Users");
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            UsersRepository repo = new UsersRepository();
            User item = repo.GetById(id);

            repo.Delete(item);
            
            return RedirectToAction("Index", "Users");
        }
    }
}