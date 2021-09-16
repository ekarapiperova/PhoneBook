using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using DataAccess.Entity;
using DataAccess.Repository;
using PhoneBook.Filters;
using PhoneBook.ViewModels.Shared;
using PhoneBook.ViewModels.Contacts;
using PhoneBook.Models;
using System.Linq.Expressions;

namespace PhoneBook.Controllers
{
    [AuthenticationFilter]
    public class ContactsController : Controller
    {
        public ActionResult Index(IndexVM model)
        {
            model.Pager = model.Pager ?? new PagerVM();
            model.Pager.Page = model.Pager.Page <= 0 ? 1 : model.Pager.Page;
            model.Pager.ItemsPerPage = model.Pager.ItemsPerPage <= 0 ? 10 : model.Pager.ItemsPerPage;

            model.Filter = model.Filter ?? new FilterVM();
            model.Filter.UserId = AuthenticationManager.LoggedUser.Id;

            Expression<Func<Contact, bool>> filter = model.Filter.GenerateFilter();
            
            ContactsRepository repo = new ContactsRepository();
            model.Items = repo.GetAll(filter, model.Pager.Page, model.Pager.ItemsPerPage);
            model.Pager.PagesCount = (int)Math.Ceiling(repo.Count(filter) / (double)(model.Pager.ItemsPerPage));

            return View(model);
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            Contact item = null;

            ContactsRepository repo = new ContactsRepository();
            
            item = id == null ? new Contact() : repo.GetById(id.Value);

            EditVM model = item == null ? new EditVM() : new EditVM(item);

            if (model.Id <= 0)
            {
                model.UserId = AuthenticationManager.LoggedUser.Id;
            }

            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(EditVM model)
        {
            if(!ModelState.IsValid)
            {
                return View(model);
            }

            ContactsRepository repo = new ContactsRepository();
            Contact item = new Contact();
            model.PopulateEntity(item);

            repo.Save(item);

            return RedirectToAction("Index", "Contacts");
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            ContactsRepository repo = new ContactsRepository();
            Contact item = repo.GetById(id);

            repo.Delete(item);
            
            return RedirectToAction("Index", "Contacts");
        }
    }
}