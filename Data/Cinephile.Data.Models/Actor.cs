namespace Cinephile.Data.Models
{
    using System;

    using Cinephile.Data.Common.Models;

    public class Actor : BaseDeletableModel<int>
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime Birthdate { get; set; }

        public string Biography { get; set; }

        public string ImageUrl { get; set; }
    }
}
