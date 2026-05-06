namespace HL7_EHR_SQLite_Demo.DataModel
{
    //Represents physical objects that take part in health care. For this purpose, entity can include patients, providers, medications, devices, and buildings.
    //The entity class is the most general class in the RIM and is the parent of all other classes.
    public class Entity
    {
        public required int Id { get; set; }
        public int Quantity { get; set; } = 1;
        public required string Description { get; set; }

        // Navigation: Roles where this entity is a player or scoper
        public ICollection<Role> PlayingRoles { get; set; } = [];
        public ICollection<Role> ScopingRoles { get; set; } = [];
    }

    public class Person : Entity
    {
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public string Address { get; set; } = string.Empty;
        public required DateOnly DateOfBirth { get; set; }
    }

    //Material substances used in healthcare like medication and medical devices.
    public class Material : Entity 
    {
        public required string Name { get; set; }
        public required string Manufacturer { get; set; }
        public required string Model { get; set; }
        public required string LotNumber { get; set; }
    }

    public class Organization : Entity
    {
        public required string Name { get; set; }
        public required string Address { get; set; }
    }
}
