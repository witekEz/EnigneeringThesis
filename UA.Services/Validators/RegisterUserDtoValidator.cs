using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UA.DAL.EF;
using UA.Model.DTOs.Read;

namespace UA.Services.Validators
{
    public class RegisterUserDtoValidator:AbstractValidator<RegisterUserDTO>
    {
        public RegisterUserDtoValidator(ApplicationDbContext dbContext) 
        {
            RuleFor(e => e.Email)
                .MinimumLength(12)
                .EmailAddress();
            RuleFor(e => e.NickName)
                .MinimumLength(3);

            RuleFor(e => e.Password)
                .MinimumLength(8);


            RuleFor(e => e.ConfirmPassword)
                .Equal(e => e.Password);

            RuleFor(e => e.Email)
                .Custom((value, context) =>
                {
                    var emailInUse = dbContext.Users.Any(u => u.Email == value);
                    if (emailInUse)
                    {
                        context.AddFailure("Email", "that email is taken!");
                    }
                });
            RuleFor(e => e.NickName)
               .Custom((value, context) =>
               {
                   var nicknameInUse = dbContext.Users.Any(u => u.NickName == value);
                   if (nicknameInUse)
                   {
                       context.AddFailure("Nickname", "that nickname is taken!");
                   }
               });

        }
    }
}
