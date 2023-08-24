using Automarket.Domain.Account.Errors;
using Automarket.Domain.Account.ValueObjects;
using Automarket.Domain.AccountAd.Entities;
using Automarket.Domain.AccountAd.ValueObjects;
using Automarket.Shared.Abstractions.ResultObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automarket.Domain.Account.Entities
{
    public class Account : Entity
    {
        public Login Login { get; set; }
        public AccountFullName FullName { get; set; }
        public Password Password { get; set; }
        public string Email { get; set; }
        public List<Ad> Ads { get; set; }

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

            return Result.Success();
        }

        public Result AddAds(IEnumerable<Ad> ads)
        {
            foreach (var ad in ads)
            {
                PlaceAccountAd(ad);
            }


            return Result.Success();
        }

        public Result<Ad> GetAdById(Guid adId)
        {
            var ad = Ads.FirstOrDefault(a => a.Id == adId);

            if (ad is null)
            {
                return Result.Fail<Ad>(DomainErrors.Account.FindAd);
            }

            return Result.Success(ad);
        }

        public Result<Ad> RemoveAd(Guid adId)
        {
            var ad = Ads.FirstOrDefault(a => a.Id == adId);
            if (ad is null)
            {
                return Result.Fail<Ad>(DomainErrors.Account.RemoveAd);
            }
            Ads.Remove(ad);

            this.AddDomainEvent()

            return ad;
        }
    }
}