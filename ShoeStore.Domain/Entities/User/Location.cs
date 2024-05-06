using ShoeStore.Domain.Common;

namespace ShoeStore.Domain.Entities.User
{
    public class Location : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; } 
        public string FhoneNumber { get; set; }

        public string Address { get; set; }

        public string City { get; set; }

        public string Region { get; set; }

        public string PostalCode { get; set; }

        public string Province { get; set; }

        public int UserId { get; set; }

        #region Navigations

        public User User { get; set; }

        #endregion

    }
}
