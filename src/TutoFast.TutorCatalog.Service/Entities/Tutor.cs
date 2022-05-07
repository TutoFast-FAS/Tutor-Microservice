using System;

namespace TutoFast.TutorCatalog.Service.Entities
{
    public class Tutor
    {
        public Guid Id
        {
            get; set;

        }
        public string Name
        {
            get; set;

        }
        public string Description
        {
            get; set;

        }
        public decimal FeePerHour
        {
            get; set;

        }
        public DateTimeOffset CreatedDate
        {
            get; set;

        }
    }
}