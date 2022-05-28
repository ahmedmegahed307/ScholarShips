using Entities.InterjectionDTO;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Helper.Validation.FluentValidation
{
    public class PostingDTOValidator : AbstractValidator<PostingDTO>
    {
        public PostingDTOValidator()
        {
            //RuleFor(c => c.Id).NotNull().WithMessage("Üniversite seçiniz");

            RuleFor(c => c.UniversityId).NotNull().WithMessage("Üniversite seçiniz");
            RuleFor(c => c.DisciplineId).NotNull().WithMessage("Katergori seçiniz");
            RuleFor(c => c.TitleId).NotNull().NotEmpty().WithMessage("Başlık seçiniz");
            RuleFor(c => c.PostingTypeId).NotNull().NotEmpty().WithMessage("Posttürünü seçiniz");
            RuleFor(c => c.Remark).NotNull().NotEmpty().WithMessage("Açıklama  ekleyiniz");
            RuleFor(c => c.StartTime).NotNull().NotEmpty().WithMessage("başlangıç tarihini  ekleyiniz");
            RuleFor(c => c.FinishTime).NotNull().NotEmpty().WithMessage("bitiş tarihini  ekleyiniz");



        }
    }
}
