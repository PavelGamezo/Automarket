namespace Automarket.Domain.Account.ValueObjects
{
    public record AccountFullName(string Name, string Surname)
    {
        public static AccountFullName Create(string value)
        {
            var splitFullName = value.Split(' ');

            return new(splitFullName.First(), splitFullName.Last());
        }

        public override string ToString()
        {
            return $"{Name} {Surname}";
        }

        public static implicit operator AccountFullName(string accountFullName)
        {
            return Create(accountFullName);
        }
    }
}
