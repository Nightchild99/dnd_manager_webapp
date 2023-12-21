using dnd_manager_webapp.Data;
using dnd_manager_webapp.Models;
using Microsoft.AspNetCore.Mvc;

namespace dnd_manager_webapp.Controllers
{
    public class PartyController : Controller
    {
        IPartyRepository _repo;

        public PartyController(IPartyRepository repo)
        {
            this._repo = repo;
        }

        public IActionResult Index()
        {
            return View(this._repo.Read());
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Character character, IFormFile picturedata)
        {
            using (var stream = picturedata.OpenReadStream())
            {
                byte[] buffer = new byte[picturedata.Length];
                stream.Read(buffer, 0, (int)picturedata.Length);
                string filename = character.Id + "." + picturedata.FileName.Split('.')[1];
                character.ImageFileName = filename;
                System.IO.File.WriteAllBytes(Path.Combine("wwwroot", "images", filename), buffer);
                character.Data = buffer;
                character.ContentType = picturedata.ContentType;
            }

            character.Description = $"{character.Name} is a level {character.Level} {character.Race} {character.Class}.";
            var errors = ModelState.Values.SelectMany(v => v.Errors);

            if (!ModelState.IsValid)
            {
                return View(character);
            }
            _repo.Create(character);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Update(string name)
        {
            var character = _repo.Read(name);
            return View(character);
        }

        [HttpPost]
        public IActionResult Update(Character character)
        {
            if (!ModelState.IsValid)
            {
                return View(character);
            }
            _repo.Update(character);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Delete(string name)
        {
            _repo.Delete(name);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult GetImage(string id)
        {
            var character = _repo.ReadFromId(id);
            if (character.ContentType.Length > 3)
            {
                return new FileContentResult(character.Data, character.ContentType);
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
