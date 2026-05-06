namespace HL7_EHR_SQLite_Demo.DataModel
{
    /// Represents the binding of one role to another, such as the relationship between a provider role and a patient role in an encounter.
    /// 
    public class RoleLink
    {
        public required int Id { get; set; }

        public enum RoleLinkType
        {
            //Relationship between a provider role and a patient role in an encounter.
            ProviderToPatient,
            //Relationship between a provider role and a device role in an encounter.
            ProviderToDevice,
            //Relationship between a patient role and a device role in an encounter.
            PatientToDevice,
            //Relationship between a provider role and another provider role, such as a supervising provider and a supervised provider.
            ProviderToSupervised
        }
        public required RoleLinkType LinkType { get; set; }
        public required int SourceId { get; set; }
        public required Role Source { get; set; }

        public required int TargetId { get; set; }
        public required Role Target {  get; set; }

        public DateTime EffectiveTime { get; set; }
    }
}
