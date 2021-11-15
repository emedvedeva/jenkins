using System.Collections.Generic;
using System.Linq;

namespace TestProject1.Models
{
    public class UserListModel
    {
        private List<User> _users;

        public UserListModel(List<User> users)
        {
            _users = users;
        }

        public User GetUserById(int id)
        {
            return _users.First(user => user.Id == id);
        }

        public static bool Equals(User user1, User user2)
        {
            //AqualityServices.LocalizedLogger.Info("Comparing users");
            bool isEqual = true;

            if (user1.Name != user2.Name) isEqual = false;
            if (user1.Id != user2.Id) isEqual = false;
            if (user1.UserName != user2.UserName) isEqual = false;
            if (user1.Email != user2.Email) isEqual = false;
            if (user1.Address.City != user2.Address.City) isEqual = false;
            if (user1.Address.Street != user2.Address.Street) isEqual = false;
            if (user1.Address.Suite != user2.Address.Suite) isEqual = false;
            if (user1.Address.Zipcode != user2.Address.Zipcode) isEqual = false;
            if (user1.Address.Geo.Lat != user2.Address.Geo.Lat) isEqual = false;
            if (user1.Address.Geo.Lng != user2.Address.Geo.Lng) isEqual = false;
            if (user1.Phone != user2.Phone) isEqual = false;
            if (user1.Website != user2.Website) isEqual = false;
            if (user1.Company.Name != user2.Company.Name) isEqual = false;
            if (user1.Company.CatchPhrase != user2.Company.CatchPhrase) isEqual = false;
            if (user1.Company.Bs != user2.Company.Bs) isEqual = false;

            return isEqual;
        }
    }
}
