using Code.DataAccess.Data;
using Code.DataAccess.Repository.IRepository;
using Code.Models;
using Microsoft.AspNetCore.Mvc;


namespace Code_Facts_Fun.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class MovieController : Controller
    {
        private readonly IUnitOfWork _unitofwork;
        public MovieController(IUnitOfWork unitofwork)
        {
            _unitofwork = unitofwork;
        }

        public IActionResult Index()
        {
            List<Clips> objClipsList = _unitofwork.clips.GetAll().ToList();
            return View(objClipsList);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Clips clips)
        {
            clips.Id = 0;
            if (ModelState.IsValid)
            {
                Console.WriteLine($"Title: {clips.Id}, Description: {clips.Description}");
                if (string.IsNullOrEmpty(clips.Description))
                {
                    clips.Description = "No description provided";
                }
                _unitofwork.clips.Add(clips);
                _unitofwork.Save();
                TempData["success"] = "Movie added successfully";
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id == null|| id == 0)
            {
                return NotFound();
            }

            Clips? clip = _unitofwork.clips.Get(x => x.Id == id);
            if (clip == null)
            {
                return NotFound();
            }

            return View(clip);
        }

        [HttpPost]
        public IActionResult Edit(Clips clip)
        {
            Console.WriteLine($"clip ID {clip.Id} and this is the clip Name {clip.Name}");
            if (ModelState.IsValid)
            {
                _unitofwork.clips.Update(clip);
                _unitofwork.Save();
                TempData["update"] = "Movie was updated successfully";
                return RedirectToAction("Index");
            }
            return View();
        }


        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            Clips? clip = _unitofwork.clips.Get(x => x.Id == id);
            if (clip == null)
            {
                return NotFound();
            }

            return View(clip);
        }

        [HttpPost, ActionName("Delete")]
        [HttpPost]
        public IActionResult DeletePost(int? id)
        {
            Clips? clip = _unitofwork.clips.Get(x => x.Id == id);
            if(clip == null)
            {
                return NotFound();
            }
            _unitofwork.clips.Delete(clip);
            _unitofwork.Save();
            TempData["delete"] = "Movie was deleted succefully";
            return RedirectToAction("Index");
        }

        public IActionResult GetAll()
        {
            List<Clips> clips = _unitofwork.clips.GetAll().ToList();
            return View(clips);
        }
    }
}
