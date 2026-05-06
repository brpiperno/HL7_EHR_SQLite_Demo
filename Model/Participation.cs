namespace HL7_EHR_SQLite_Demo.DataModel
{
    //Represents the participation of an entity in an act. For this purpose, participation can include the involvement of a patient in an encounter, the involvement of a provider in a procedure, and the involvement of a medication in a substance administration.
    public class Participation
    {

        public required int Id { get; set; }
        public required int ActId { get; set; } // Foreign key for Act
        public required Act Act { get; set; } //the act for which this participation is being recorded
        public required int RoleId { get; set; } // Foreign key for Role
        public required Role Role { get; set; } //the role that the entity is playing in the act

        public enum ETypeCode
        {
            Performer, //the entity is performing the act
            Author, //the entity is authoring the act
            Location, //the entity is the location where the act is taking place
            Subject, //the entity is the subject of the act
        }

        public required ETypeCode TypeCode { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }


    }
}
