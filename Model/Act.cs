namespace HL7_EHR_SQLite_Demo.DataModel
{
    //Represents actions that are performed in health care. For this purpose, act can include encounters, procedures, observations, and substance administrations.
    public class Act
    {
        public required int Id { get; set; } //unique identifier for the act

        public enum EClassCode
        {
            Encounter = 1,
            Procedure = 2,
            Observation = 3,
            SubstanceAdministration = 4
        }
        public required EClassCode ClassCode { get; set; }  //Subtype of act. For demo purposes, we will use an enum and basic description field
        public required string Description { get; set; }
        
        public enum EMood
        {
            Event = 1, //happened
            Intent = 2, //intended to happen
            Order = 3, //ordered to happen
        }
        public required EMood MoodCode { get; set; } //Intent of the act. For demo purposes, we will use an enum and basic description field as applicable.

        public required string Code { get; set; } //code representing the act, such as a CPT code for procedures or LOINC code for observations
        public required DateTime StartTime { get; set; } //start time of the act
        public DateTime EndTime { get; set; } //end time of the act

        // Navigation
        public List<Participation> Participations { get; set; } = [];
        public List<ActRelationship> SourceRelationships { get; set; } = [];
        public List<ActRelationship> TargetRelationships { get; set; } = [];
    }
}
