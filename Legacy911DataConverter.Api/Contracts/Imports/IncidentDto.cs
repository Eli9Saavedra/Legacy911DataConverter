namespace Legacy911DataConverter.Api.Contracts.Imports
{
    public class IncidentDto
    {
        public int Id { get; set; }
        public string IncidentNumber { get; set; }
        public string CallType { get; set; }
        public DateTime OccurredAtUtc { get; set; }
        public string Status { get; set; }
        public string Location { get; set; }
        public string Priority { get; set; }
        public Guid BatchId { get; set; }
    }
}
