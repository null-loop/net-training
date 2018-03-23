using System;

namespace ClassStructures
{
    public class Person
    {
        private string _firstName;
        private string _lastName;
        private readonly DateTime _dateOfBirth;

        public Person(string firstName, string lastName, DateTime dateOfBirth)
        {
            _firstName = firstName;
            _lastName = lastName;
            _dateOfBirth = dateOfBirth;
        }

        public Person(string firstName, DateTime dateOfBirth)
        {
            _firstName = firstName;
            _dateOfBirth = dateOfBirth;
        }

        public TimeSpan CalculateAge()
        {
            return CalculateAge(DateTime.UtcNow);
        }

        public TimeSpan CalculateAge(DateTime when)
        {
            return when - _dateOfBirth;
        }

        public int CalculateAgeInYears()
        {
            return CalculateAgeInYears(DateTime.UtcNow);
        }

        public int CalculateAgeInYears(DateTime when)
        {
            return (int)(CalculateAge(when).TotalDays) / 365;
        }

        public void ChangeName(string newFirstName, string newLastName)
        {
            var oldFirstName = FirstName;
            var oldLastName = LastName;

            _firstName = newFirstName;
            _lastName = newLastName;

            OnNameChanged(oldFirstName, oldLastName);
            OnANameChanged(oldFirstName, oldLastName, _firstName, _lastName);
        }

        public void ChangeName(string newFirstName)
        {
            ChangeName(newFirstName, string.Empty);
        }

        public string FirstName
        {
            get
            {
                return _firstName;
            }
        }

        public string LastName
        {
            get
            {
                return _lastName;
            }
        }

        public string FullName
        {
            get
            {
                return FormatNames(FirstName, LastName);
            }
        }

        public static string FormatNames(string firstName, string lastName)
        {
            if (!string.IsNullOrEmpty(lastName))
            {
                return $"{firstName} {lastName}";
            }
            return firstName;
        }

        public event EventHandler<NameChangeEventArgs> NameChanged;
        public static event EventHandler<NameChangeEventArgs> ANameChanged;

        private static void OnANameChanged(string oldFirstName, string oldLastName, string newFirstName, string newLastName)
        {
            ANameChanged?.Invoke(null,
                new NameChangeEventArgs()
                {
                    OldFirstName = oldFirstName,
                    OldLastName = oldLastName,
                    NewFirstName = newFirstName,
                    NewLastName = newLastName
                });
        }

        protected virtual void OnNameChanged(string oldFirstName, string oldLastName)
        {
            NameChanged?.Invoke(this,
                new NameChangeEventArgs()
                {
                    OldFirstName = oldFirstName,
                    OldLastName = oldLastName,
                    NewFirstName = FirstName,
                    NewLastName = LastName
                });
        }

        public override string ToString()
        {
            return $"Hello my name is {FullName}, I was born on {_dateOfBirth:D} and I am currently {CalculateAgeInYears():#,###} years old";
        }
    }
}