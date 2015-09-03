using ElevenNote.Models.ViewModels;
using ElevenNote.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using ElevenNote.Models;

namespace ElevenNote.Web.Controllers
{

    /// <summary>
    /// The Authorize thing makes it so that you have to be logged in to see a note.
    /// </summary>
    [Authorize]
    public class NotesController : Controller
    {
        // GET: Notes
        public ActionResult Index()
        {
            if (TempData["Result"] != null)
            { ViewBag.Success = TempData["Result"];
            TempData.Remove("Result");
            }
            var noteService = new NoteService();
            var notes = noteService.GetAllForUser(Guid.Parse(User.Identity.GetUserId()));
            return View(notes);
        }

        // GET: Note
        [HttpGet]
        [ActionName("Create")]
        public ActionResult CreateGet()
        {
            return View();
        }

        // POST: Note
        [HttpPost]
        [ActionName("Create")]
        public ActionResult CreatePost(NoteEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                var noteService = new NoteService();
                var userId = Guid.Parse(User.Identity.GetUserId());
                var result = noteService.Create(model, userId);
                TempData.Add("Result", result ? "Note added." : "Note not added.");
                return RedirectToAction("Index");
            }
            return View(model);


        }
       
        [HttpGet]
        [ActionName("Edit")]
        public ActionResult EditGet(int id)
        {
            var noteService = new NoteService();
            var userId = Guid.Parse(User.Identity.GetUserId());
            return View(noteService.GetById(id, userId));
        }

        [HttpPost]
        [ActionName("Edit")]
        public ActionResult EditPost(NoteEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                var noteService = new NoteService();
                var userId = Guid.Parse(User.Identity.GetUserId());
                var result = noteService.Update(model, userId);
                TempData.Add("Result", result ? "Note updated." : "Note not updated.");
                return RedirectToAction("Index");
            }
            return View(model);


        }
        [HttpGet]
        [ActionName("Details")]
        public ActionResult DetailsGet(int id)
        {
            var noteService = new NoteService();
            var userId = Guid.Parse(User.Identity.GetUserId());
            return View(noteService.GetById(id, userId));
        }

        [HttpGet]
        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var noteService = new NoteService();
            var userId = Guid.Parse(User.Identity.GetUserId());
            return View(noteService.GetById(id, userId));
        }

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeletePost(int id)
        {
       
                var noteService = new NoteService();
                var userId = Guid.Parse(User.Identity.GetUserId());
                var result = noteService.Delete(id, userId);
                TempData.Add("Result", result ? "Note deleted." : "Note not deleted.");
                return RedirectToAction("Index");
            }
    }
}