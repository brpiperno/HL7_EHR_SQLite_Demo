namespace HL7_EHR_SQLite_Demo.DataModel
{
    //Represents the binding of one act to another, such as the relationship between an order to observe a vital sign and the observation of the vital sign itself.
    //For demo purposes, we will simply use this as a junction table to link two acts together,
    //but in a real implementation, this could be expanded to include additional information about the relationship between the two acts.
    public class ActRelationship
    {
        public required int Id { get; set; }

        public required int SourceId { get; set; }
        public required Act Source { get; set; }

        public required int TargetId { get; set; }
        public required Act Target { get; set; }
    }
}
