using dnd_manager_webapp.Models;

namespace dnd_manager_webapp.Data
{
    public interface IPartyRepository
    {
        void Create(Character character);
        void Delete(string name);
        void LevelUp(string name);
        IEnumerable<Character> Read();
        Character? Read(string name);
        Character? ReadFromId(string id);
        void Update(Character character);
    }
}