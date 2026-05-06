namespace HL7_EHR_SQLite_Demo.DataModel
{
    //Represents the role that an entity plays in an act.
    public class Role
    {
        public required int Id { get; set; }
        public enum ERoleClass
        {
            patient = 1,
            author = 2,
            licensed_entity = 3,
            manufactured_product = 4,
        }

        public required ERoleClass RoleClass { get; set; }

        //Foreign keys
        public required int PlayingEntityID { get; set; }
        public required int ScopingEntityID { get; set; }

        // Navigation: Participations
        public List<Participation> Participations { get; set; } = [];

        // Navigation: RoleLinks
        public ICollection<RoleLink> SourceRoleLinks { get; set; } = [];
        public ICollection<RoleLink> TargetRoleLinks { get; set; } = [];

        // Navigation: Many-to-one with Entity (players and scopers)
        public required Entity PlayingEntity { get; set; }
        public required Entity ScopingEntity { get; set; }
    }
}
