using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants
{
    public class Messages
    {
        //Apply
        public static string CreatedApply = "Başvuru gönderildi";
        public static string UpdatedCreatedApply = "Başvurunuz güncellendi";
        //Posting
        public static string PostingCreated = "İlan Oluşturuldu .";
        public static string PostingUnCreated = "Daha fazla ilan açmak için mailinizi onaylayınız.";
        public static string PostingUpdated = "İlan Güncellendi .";
        public static string PostingUnUpdated = "İlan güncellenemedi .";
        public static string PostingDeleted = "İlan Silindi .";
        public static string PostingListed = "İlanlar Listelendi .";

        //EmailConfirmedCode
        public static string EmailConfirmedCodeCreateTrue = "email dogrulama kodu oluşturuldu .";
        public static string EmailConfirmedCodeAlreadyHave = "email dogrulama kodu zaten gönderildi. tekrar kod istemek için 3 saat bekleyiniz";
        public static string EmailConfirmedCodeCreateFalse = "email dogrulama kodu oluşturulamadı .";
        public static string EmailConfirmedIsTrue = "emailiniz dogrulandı.";
        public static string EmailConfirmedAlreadyIsTrue = "emailiniz zaten dogrulandı.";
        public static string EmailCodeEnteredIncorrectly = "kod yanlış girildi";



        //Event
        public static string EventListed = "Etkinlikler Listelendi.";
       
        public static string EventDeleted = "Seçili etkinlik silindi";
        public static string EventCreated = "Yeni etkinlik eklendi.";
        public static string EventNotCreated = "Etkinlik eklenemedi!";
        public static string EventUpdated = "Etkinlik başarıyla güncellendi.";






        // Image
        public static string PostingİmageCreated = "İlan resimleri oluşturuldu .";
        public static string EventImageCreated = "Etkinlik resmi eklendi.";
        public static string EventImageUpdated = "Etkinlik resmi güncellendi";

        public static string PostingİmageUpdated = "İlan resimleri güncellendi .";



        //PostingType
        public static string PostingTypeListed = "İlan Tipleri getirildi .";


        //Country
        public static string CountryListed = "Ülkeler getirildi.";


        //City
        public static string CountryByCity = "Ülkelere göre iller getirildi.";

        //Role
        public static string RoleListed = "Roller getirildi.";

        //Discipline
        public static string DisciplineListed = "Disiplinler listelendi";

        //Title
        public static string TitleListed = "Başlıklar listelendi";

        // SavedPosting
        public static string SavedPosting = "İlan Kaydedildi";
        public static string SavedPostingDelete = "İlan Kaydedilenlerden Silindi";

        // Cv
        public static string SavedCV = "Cv Kaydedildi";

        //User
        public static string UserNotFound = "Kullanıcı bulunamadı";
        public static string UserAlreadyExist = "Kullanıcı zaten var";
        public static string UserUpdated = "Kullanıcı güncellendi.";
    }
}
