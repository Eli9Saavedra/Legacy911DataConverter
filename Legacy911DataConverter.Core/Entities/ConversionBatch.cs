using System;
using System.Collections.Generic;
using System.Text;

namespace Legacy911DataConverter.Core.Entities;
public class ConversionBatch
{
    public Guid Id { get; set; }
    public DateTime ImportedAtUtc { get; set; }
    public string? SourceType { get; set; }
    public int TotalRecords { get; set; }
    public int SuccessfulRecords { get; set; }
    public int FailedRecords { get; set; }
}
