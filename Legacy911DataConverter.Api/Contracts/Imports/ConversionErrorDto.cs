namespace Legacy911DataConverter.Api.Contracts.Imports
{
    public class ConversionErrorDto
    {
        public int Id { get; set; }
        public Guid BatchId { get; set; }
        public int RowNumber { get; set; }
        public string? IncidentNumber { get; set; }
        public string Field { get; set; }
        public string Message { get; set; }
    }
}
