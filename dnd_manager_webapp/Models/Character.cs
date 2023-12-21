using System.ComponentModel.DataAnnotations;

namespace dnd_manager_webapp.Models
{
    public enum Races
    {
        dragonborn = 0,
        dwarf = 1,
        elf = 2,
        gnome = 3,
        halfling = 4,
        human = 5,
        orc = 6,
        tiefling = 7
    }

    public enum Classes
    {
        artificer = 0,
        barbarian = 1,
        bard = 2,
        cleric = 3,
        druid = 4,
        fighter = 5,
        monk = 6,
        paladin = 7,
        ranger = 8,
        rogue = 9,
        sorcerer = 10,
        warlock = 11,
        wizard = 12
    }

    public class Character
    {
        [Key]
        public string Id { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(50)]
        public string Name { get; set; }
        public string? Description { get; set; }

        [Required]
        public Races Race { get; set; }
        [Required]
        public Classes Class { get; set; }

        [Required]
        [Range(0,20)]
        public int Level { get; set; }

        [StringLength(200)]
        public string? ImageFileName { get; set; }

        public string? ContentType { get; set; }

        public byte[]? Data { get; set; }

        public Character()
        {
            Id = Guid.NewGuid().ToString();
        }
    }
}
