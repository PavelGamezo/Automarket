using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Automarket.Entities.Enums
{
    public enum CarType
    {
        [Display(Name = "Внедорожник")]
        SUV,
        [Display(Name = "Кабриолет")]
        Cabriolet,
        [Display(Name = "Купе")]
        Coupe,
        [Display(Name = "Лимузин")]
        Limousine,
        [Display(Name = "Лифтбэк")]
        Liftback,
        [Display(Name = "Минивэн")]
        Minivan,
        [Display(Name = "Пикап")]
        Pickup,
        [Display(Name = "Седан")]
        Sedan,
        [Display(Name = "Хэтчбэк")]
        Hatchback,
        [Display(Name = "Микроавтобус")]
        Minibus
    }
}
