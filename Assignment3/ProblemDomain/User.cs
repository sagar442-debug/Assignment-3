using System;

namespace Assignment3
{
    [Serializable]
    public class User : IEquatable<User>
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }

        public User(int id, string name, string email, string password)
        {
            Id = id;
            Name = name;
            Email = email;
            Password = password;
        }

        public bool IsCorrectPassword(string input)
        {
            return string.IsNullOrEmpty(Password) || Password.Equals(input);
        }

        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is User))
                return false;

            User other = (User)obj;
            return Id == other.Id && Name.Equals(other.Name) && Email.Equals(other.Email);
        }

        public bool Equals(User other)
        {
            return !(other == null) && Id == other.Id && Name == other.Name && Email == other.Email;
        }

        public override int GetHashCode()
        {
            int hashCode = 825453597;
            hashCode = hashCode * -1521134295 + Id.GetHashCode();
            hashCode = hashCode * -1521134295 + (Name != null ? Name.GetHashCode() : 0);
            hashCode = hashCode * -1521134295 + (Email != null ? Email.GetHashCode() : 0);
            hashCode = hashCode * -1521134295 + (Password != null ? Password.GetHashCode() : 0);
            return hashCode;
        }
    }
}
