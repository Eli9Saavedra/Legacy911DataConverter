namespace Legacy911DataConverter.Api.Contracts.Imports
{
    public class ConversionBatchDto
    {
        public Guid Id { get; set; }
        public DateTime ImportedAtUtc { get; set; }
        public string? SourceType { get; set; }
        public int TotalRecords { get; set; }
        public int SuccessfulRecords { get; set; }
        public int FailedRecords { get; set; }
    }
}
