using Legacy911DataConverter.Api.Contracts.Imports;
using Legacy911DataConverter.Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Legacy911DataConverter.Api.Controllers
{
    [Route("api/imports")]
    [ApiController]
    public class ImportsController : ControllerBase
    {
        private readonly Legacy911DataConverterDbContext _dbContext;

        public ImportsController(Legacy911DataConverterDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet("incidents")]
        public async Task<ActionResult<List<IncidentDto>>> GetIncidentsAsync()
        {
            var incidents = await _dbContext.Incidents.AsNoTracking().ToListAsync();

            var incidentDtos = incidents.Select(i => new IncidentDto
            {
                Id = i.Id,
                IncidentNumber = i.IncidentNumber,
                CallType = i.CallType,
                OccurredAtUtc = i.OccurredAtUtc,
                Status = i.Status,
                Location = i.Location,
                Priority = i.Priority,
                BatchId = i.BatchId
            }).ToList();

            return Ok(incidentDtos);
        }

        [HttpGet("errors")]
        public async Task<ActionResult<List<ConversionErrorDto>>> GetErrorsAsync()
        {
            var errors = await _dbContext.ConversionErrors.AsNoTracking().ToListAsync();

            var conversionErrorDtos = errors.Select(i => new ConversionErrorDto
            {
                Id = i.Id,
                RowNumber = i.RowNumber,
                IncidentNumber = i.IncidentNumber,
                Field = i.Field,
                Message = i.Message,
                BatchId = i.BatchId
            }).ToList();

            return Ok(conversionErrorDtos);
        }

        [HttpGet("batches")]
        public async Task<ActionResult<List<ConversionBatchDto>>> GetBatchesAsync()
        {
            var batches = await _dbContext.ConversionBatches.AsNoTracking().ToListAsync();

            var conversionBatchesDtos = batches.Select(i => new ConversionBatchDto
            {
                Id = i.Id,
                ImportedAtUtc = i.ImportedAtUtc,
                SourceType = i.SourceType,
                TotalRecords = i.TotalRecords,
                SuccessfulRecords = i.SuccessfulRecords,
                FailedRecords = i.FailedRecords
            }).ToList();

            return Ok(conversionBatchesDtos);
        }
    }
}
