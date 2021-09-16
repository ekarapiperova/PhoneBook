using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using DataAccess.Entity;
using DataAccess.Repository;
using PhoneBook.Filters;
using PhoneBook.ViewModels.Shared;
using PhoneBook.ViewModels.Phones;
using PhoneBook.Models;
using System.Linq.Expressions;

namespace PhoneBook.Controllers
{
    [AuthenticationFilter]
    public class PhonesController : Controller
    {
        public ActionResult Index(IndexVM model)
        {
            model.Pager = model.Pager ?? new PagerVM();
            model.Pager.Page = model.Pager.Page <= 0 ? 1 : model.Pager.Page;
            model.Pager.ItemsPerPage = model.Pager.ItemsPerPage <= 0 ? 10 : model.Pager.ItemsPerPage;

            model.Filter = model.Filter ?? new FilterVM();
            model.Filter.ContactId = model.ContactId;

            Expression<Func<Phone, bool>> filter = model.Filter.GenerateFilter();
            
            PhonesRepository repo = new PhonesRepository();
            model.Items = repo.GetAll(filter, model.Pager.Page, model.Pager.ItemsPerPage);
            model.Pager.PagesCount = (int)Math.Ceiling(repo.Count(filter) / (double)(model.Pager.ItemsPerPage));

            ContactsRepository contactsRepo = new ContactsRepository();
            model.Contact = contactsRepo.GetById(model.ContactId);

            return View(model);
        }

        [HttpGet]
        public ActionResult Edit(int? id, int? contactId)
        {
            Phone item = null;

            PhonesRepository repo = new PhonesRepository();
            
            item = id == null ? new Phone() : repo.GetById(id.Value);

            EditVM model = item == null ? new EditVM() : new EditVM(item);

            if (model.Id <= 0)
            {
                model.ContactId = contactId.Value;
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

            PhonesRepository repo = new PhonesRepository();
            Phone item = new Phone();
            model.PopulateEntity(item);

            repo.Save(item);

            return RedirectToAction("Index", "Phones", new { ContactId = item.ContactId });
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            PhonesRepository repo = new PhonesRepository();
            Phone item = repo.GetById(id);

            repo.Delete(item);
            
            return RedirectToAction("Index", "Phones", new { ContactId = item.ContactId });
        }
    }
}