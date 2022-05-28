using Entities.InterjectionDTO;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Helper.Validation.FluentValidation
{
    public class CustomPostingDTOValidator : AbstractValidator<CustomPostingDTO>
    {
        public CustomPostingDTOValidator()
        {

            RuleFor(c => c.CvId).NotNull().WithMessage("Cv seçiniz");

        }
    }
}
