using TutoFast.TutorCatalog.Service.Dtos;
using TutoFast.TutorCatalog.Service.Entities;

namespace TutoFast.TutorCatalog.Service
{
    public static class Extensions
    {
        public static TutorDto AsDto(this Tutor tutor)
        {
            return new TutorDto(tutor.Id, tutor.Name, tutor.Description, tutor.FeePerHour, tutor.CreatedDate);
        }
    }
}