namespace Trackly.Domain.Entities
{
    public class User
    {
        public Guid Id { get; private set; }

        public string FirstName { get; private set; }

        public string LastName { get; private set; }

        public DateOnly BirthDate { get; private set; }

        public string Phone { get; private set; }

        public string PasswordHash { get; private set; }

        public string? RefreshToken { get; private set; }

        public DateTime? RefreshTokenExpiry { get; private set; }

        public DateTime CreatedDate { get; private set; } = DateTime.UtcNow;

        public User(string firstName, string lastName, DateOnly birthDate, string phone, string passwordHash)
        {
            Id = Guid.NewGuid();

            SetFirstName(firstName);
            SetLastName(lastName);
            SetBirthDate(birthDate);
            SetPhone(phone);

            PasswordHash = passwordHash;
        }

        public void SetFirstName(string firstName)
        {
            if (string.IsNullOrWhiteSpace(firstName))
                throw new Exception("FirstName bo‘sh bo‘lmasin");

            FirstName = firstName;
        }

        public void SetLastName(string lastName)
        {
            if (string.IsNullOrWhiteSpace(lastName))
                throw new Exception("LastName bo‘sh bo‘lmasin");

            LastName = lastName;
        }

        public void SetBirthDate(DateOnly birthDate)
        {
            if (birthDate > DateOnly.FromDateTime(DateTime.UtcNow))
                throw new Exception("Invalid birthdate");

            BirthDate = birthDate;
        }

        public void SetPhone(string phone)
        {
            if (phone.Length == 0)
                throw new Exception("Invalid phone");

            Phone = phone;
        }

        public void SetRefreshToken(string token, DateTime expiry)
        {
            RefreshToken = token;
            RefreshTokenExpiry = expiry;
        }

        public ICollection<Habit> Habits { get; set; } = new List<Habit>();
    }
}
