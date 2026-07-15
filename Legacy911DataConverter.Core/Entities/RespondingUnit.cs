using System;

namespace Legacy911DataConverter.Core.Entities;

public class RespondingUnit
{
    public int Id { get; set; }
    public string UnitCode { get; set; }
    public string UnitType { get; set; }
    public string Agency { get; set; }
    public bool IsActive { get; set; }
    public Guid? BatchId { get; set; }
}
