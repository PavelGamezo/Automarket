using Automarket.Domain.AccountAd.Events;
using Automarket.Domain.AccountAd.ValueObjects;
using Automarket.Shared.Abstractions.ResultObjects;

namespace Automarket.Domain.AccountAd.Entities
{
    public sealed class Ad : Entity
    {
        private bool _done;

        public CarBrand Brand { get; set; }
        public CarModel Model { get; set; }
        public CarBody CarBody { get; set; }
        public CarYear Year { get; set; }

        public Guid AccountId { get; set; }
        public Account.Entities.Account Account { get; set; }

        public bool Done
        {
            get => _done;
            set
            {
                if (value && !_done)
                {
                    AddDomainEvent(new AdCompletedEvent(this));
                }
            }
        }

        public Ad(Guid id, CarBrand brand, CarModel model, CarBody carBody, CarYear year, Account.Entities.Account account) : base(id)
        {
            Brand = brand;
            Model = model;
            CarBody = carBody;
            Year = year;
            Account = account;
            AccountId = account.Id;
        }

        public Ad(Guid id, CarBrand brand, CarModel model, CarBody carBody, CarYear year) : base(id)
        {
            Brand = brand;
            Model = model;
            CarBody = carBody;
            Year = year;
        }

        public static Result<Ad> CreateAd(
            Account.Entities.Account account,
            Guid id,
            CarBrand brand,
            CarModel model,
            CarBody carBody,
            CarYear year)
        {
            return Result.Success(new Ad(id, brand, model, carBody, year, account));
        }
    }
}
