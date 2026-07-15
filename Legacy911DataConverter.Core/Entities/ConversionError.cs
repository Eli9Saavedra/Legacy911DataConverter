using System;
using System.Collections.Generic;
using System.Text;

namespace Legacy911DataConverter.Core.Entities
{
    public class ConversionError
    {
        public int Id { get; set; }
        public Guid BatchId { get; set; }
        public int RowNumber { get; set; }
        public string? IncidentNumber { get; set; }
        public string Field { get; set; }
        public string Message { get; set; }
    }
}
