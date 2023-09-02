using Automarket.Domain.Account.Errors;
using Automarket.Domain.Account.ValueObjects;
using Automarket.Domain.AccountAd.Entities;
using Automarket.Domain.AccountAd.Events;
using Automarket.Domain.AccountAd.ValueObjects;
using Automarket.Domain.Common.Domain;
using Automarket.Shared.Abstractions.ResultObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automarket.Domain.Account.Entities
{
    public class Account : AggregateRoot
    {
        public Login Login { get; private set; }
        public AccountFullName FullName { get; private set; }
        public Password Password { get; private set; }
        public string Email { get; private set; }
        public List<Ad> Ads { get; private set; }

        public Account(Guid id, Login login, AccountFullName fullName, Password password, string email) : base(id)
        {
            Login = login;
            FullName = fullName;
            Password = password;
            Email = email;
        }

        public Result PlaceAccountAd(Ad ad)
        {
            var alreadyExist = Ads.Any(a => a.Id == ad.Id);

            if (alreadyExist)
            {
                return Result.Fail(DomainErrors.Account.CreateAd);
            }

            Ads.Add(ad);
            AddDomainEvent(new AdPlacedDomainEvent(ad));

            return Result.Success();
        }

        public Result<Ad> GetAdById(AdId adId)
        {
            var ad = Ads.FirstOrDefault(a => a.Id == adId);

            if (ad is null)
            {
                return Result.Fail<Ad>(DomainErrors.Account.FindAd);
            }

            return Result.Success(ad);
        }

        public Result ChangeAd(AdId adId, 
            CarBrand brand,
            CarModel model,
            CarBody carBody,
            CarYear year)
        {
            var ad = Ads.Single(a => a.Id == adId);
            if (ad is null)
            {
                return Result.Fail<Ad>(DomainErrors.Account.FindAd);
            }

            return ad.Change(brand, model, carBody, year);
        }

        public Result<Ad> RemoveAd(Guid adId)
        {
            var ad = Ads.FirstOrDefault(a => a.Id == adId);
            if (ad is null)
            {
                return Result.Fail<Ad>(DomainErrors.Account.RemoveAd);
            }
            Ads.Remove(ad);

            AddDomainEvent(new AdRemovedDomainEvent(ad));

            return ad;
        }
    }
}