using dnd_manager_webapp.Models;
using System.Diagnostics;
using System.Security.Claims;
using System.Xml.Linq;

namespace dnd_manager_webapp.Data
{
    public class PartyRepository : IPartyRepository
    {
        PartyDbContext context;

        public PartyRepository(PartyDbContext context)
        {
            this.context = context;
        }

        public void Create(Character character)
        {
            context.Characters.Add(character);
            context.SaveChanges();
        }

        public IEnumerable<Character> Read()
        {
            return context.Characters;
        }

        public Character? Read(string name)
        {
            return context.Characters.FirstOrDefault(t => t.Name == name);
        }

        public Character? ReadFromId(string id)
        {
            return context.Characters.FirstOrDefault(t => t.Id == id);
        }

        public void LevelUp(string name)
        {
            var character = Read(name);
            character.Level++;
            character.Description = $"{character.Name} is a level {character.Level} {character.Race} {character.Class}.";
            context.SaveChanges();
        }

        public void Update(Character character)
        {
            var old = Read(character.Name);
            old.Name = character.Name;
            old.Level = character.Level;
            old.Race = character.Race;
            old.Class = character.Class;
            old.Description = $"{character.Name} is a level {character.Level} {character.Race} {character.Class}.";
        }

        public void Delete(string name)
        {
            var character = Read(name);
            context.Characters.Remove(character);
            context.SaveChanges();
        }
    }
}
