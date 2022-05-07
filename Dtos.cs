using System;
using System.ComponentModel.DataAnnotations;

namespace TutoFast.TutorCatalog.Service.Dtos
{
    public record TutorDto(Guid Id, string Name, string Description, decimal FeePerHour, DateTimeOffset CreatedDate);
    public record CreateTutorDto([Required] string Name, string Description, [Range(0, 1000)] decimal FeePerHour);
    public record UpdateTutorDto([Required] string Name, string Description, [Range(0, 1000)] decimal FeePerHour);
}