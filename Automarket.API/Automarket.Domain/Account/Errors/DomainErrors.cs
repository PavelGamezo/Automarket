using Automarket.Shared.Abstractions.ResultObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automarket.Domain.Account.Errors
{
    public static class DomainErrors
    {
        public static class Account
        {
            public static readonly Error FindAd = new Error(
                "Domain.AddNewAd", 
                "Can't find ad for account");

            public static readonly Error CreateAd = new Error(
                "Domain.PlaceAd",
                "Can't send ad to ad creation");
            
            public static readonly Error RemoveAd = new Error(
                "Domain.RemoveAd",
                "Can't remove ad from ads list");
        }
    }
}
