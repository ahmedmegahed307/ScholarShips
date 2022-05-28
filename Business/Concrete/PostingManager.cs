using System.Collections.Generic;
using AutoMapper;
using Business.Abstract;
using Business.Constants;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.InterjectionDTO;


namespace Business.Concrete
{
    public class PostingManager : IPostingService
    {
        readonly IMapper _mapper;
        private readonly IPostingDal _postingDal;
        private readonly ICVDal _cvDal;
        private readonly IImageDal _ımageDal;
        private readonly IApplyDal _applyDal;
        private readonly IUserDal _userDal;

        public PostingManager(IMapper mapper, IPostingDal postingDal, IImageDal ımageDal, ICVDal cVDal, IApplyDal applyDal , IUserDal userDal)
        {
            _mapper = mapper;
            _postingDal = postingDal;
            _ımageDal = ımageDal;
            _cvDal = cVDal;
            _applyDal = applyDal;
            _userDal = userDal;
        }

        public ResultDTO<PostingDTO> CreatePosting(PostingDTO model)
        {
            var postingcount = _postingDal.GetAll(x => x.UserId == model.UserId && x.IsActive==true);
            var user = _userDal.Get(x=>x.Id==model.UserId);
            if (postingcount.Count <= 1 && user.EmailConfirmed==false )      // bir kişinin belli bir sayıdan fazla ilan açmasını engelliyorum
            {
                model.CreateDate = System.DateTime.Now;
                model.CreateUser = model.UserId; 
                model.IsActive = true;                                                  //postingdetaile kayıt attıgımyer
                var mapper = _mapper.Map<Posting>(model);
                _postingDal.Add(mapper);
                model.Id = mapper.Id;

                return new ResultDTO<PostingDTO> { Data = model, Message = Messages.PostingCreated, Success = true };
            }
            else if (user.EmailConfirmed==true)         // emaili onaylanmıssa istedigi kadar ilan açabilir     
            {
                model.CreateDate = System.DateTime.Now;
                model.CreateUser = model.UserId;
                model.IsActive = true;                                                  
                var mapper = _mapper.Map<Posting>(model);
                _postingDal.Add(mapper);
                model.Id = mapper.Id;
                return new ResultDTO<PostingDTO> { Data = model, Message = Messages.PostingCreated, Success = true };

            }
            else
            {                                   // belli bir sayıda ilanı varsa daha fazla açmasını engelliyorum
                return new ResultDTO<PostingDTO> { Data = model, Message = Messages.PostingUnCreated, Success = true };
            }

        }


        public void DeletePosting(int Id)
        {
            var deletepostingdetail = _postingDal.Get(q => q.Id == Id && q.IsActive == true);  
            deletepostingdetail.IsActive = false;
            _postingDal.Update(deletepostingdetail);

            //return ;
            //return new ResultDTO<PostingDTO> { Data = deletepostingdto, Message = Messages.PostingDeleted, Success = true };

        }


        public ResultDTO<PostingDTO> GetPosting(int Id)     // sadece belirtilen id li ilan bilgilerini getirir   
        {

            var model = _postingDal.GetPosting(Id);


           

            return new ResultDTO<PostingDTO> { Data = model, Message = Messages.PostingListed, Success = true };
        }

        public ResultDTO<CustomPostingDTO> GetUserPostingAll(int Id, int skip)       // userin açtıgı bütün ilanları getirir  
        {
            CustomPostingDTO model = new();
            var data1 = _postingDal.GetListAll(Id,skip);
            model.PostingDTOItems = data1;
            var data2 = _postingDal.GetListFalseAll(Id);
            model.PostingDTOFalseItems = data2;
            model.TotalPages = _postingDal.GetAll(i => i.UserId == Id && i.IsActive == true).Count;
            model.PageNumber = skip;
            model.PageIndex = 2;
            model.PageSize = 2;
            return new ResultDTO<CustomPostingDTO> { Data = model, Message = Messages.PostingListed, Success = true };

        }
        public ResultDTO<CustomPostingDTO> GetApplicantsPosting(int Id, int skip)
        {
            CustomPostingDTO model = new();
            var postingcvlist = _applyDal.GetListAll(Id, skip);
            model.ApplicantsPostingDTOItems = postingcvlist;
            model.TotalPages = _applyDal.GetAll(i => i.PostingId == Id).Count;
            model.PageNumber = skip;
            model.PageIndex = 1;
            model.PageSize = 1; 
            return new ResultDTO<CustomPostingDTO> { Data = model, Message = Messages.PostingListed, Success = true };
        }

        public ResultDTO<CustomPostingDTO> GetPostingAll(int Id)       // bütün ilanları listeler    
        {                                                               // ilanları listelerken sayfada gezinecek kişinin cv bilgilerini
            var postingDTOs = _postingDal.GetListAll();                       // cagırmak için metoda  id degeri gönderiyoruz 

            var postingcvlist = _cvDal.GetAll(x => x.UserId == Id);

            for (int i = 0; i < postingDTOs.Count; i++)
            {
                postingDTOs[i].ApplyCount = _applyDal.GetAll(x => x.PostingId == postingDTOs[i].Id).Count;
            }
            CustomPostingDTO model = new();
            model.CVDTOItems = _mapper.Map<List<CVDTO>>(postingcvlist);
            model.PostingDTOItems = postingDTOs;

            return new ResultDTO<CustomPostingDTO> { Data = model, Message = Messages.PostingListed, Success = true };

        }


        public ResultDTO<PostingDTO> UpdatePosting(PostingDTO model)
        {
            var update = _postingDal.Get(q => q.Id == model.Id);  // deger varmı yokmu kontrolünü yapıyorum.
            model.Id = update.Id;
            model.IsActive = true;
            var map = _mapper.Map<Posting>(model);
            _postingDal.Update(map);


            return new ResultDTO<PostingDTO> { Data = model, Message = Messages.PostingUpdated, Success = true };

        }


        public ResultDTO<CVDTO> UpdateCv(CVDTO model)           // cv kayıt alanı
        {
            var map = _mapper.Map<CV>(model);
            _cvDal.Add(map);

            return new ResultDTO<CVDTO> { Data = model, Message = Messages.SavedCV, Success = true };
        }

        public ResultDTO<CustomPostingDTO> GetList(CustomPostingDTO p)
        {
            var spPosting = _postingDal.GetSPPostingList(p.UserDTOItems.Id); // store procedure çıktısı burda oluyor ama returne vermedik, 
            var mapper2 = _mapper.Map<List<PostingDTO>>(spPosting);          // individualda degişiklikler olursa tüm proje patlamasın diye.

            var values = _postingDal.GetListAll();
            var mapper = _mapper.Map<List<PostingDTO>>(values);
            p.PostingDTOItems = mapper;
            var postingcvlist = _cvDal.GetAll(x => x.UserId == p.UserDTOItems.Id);
            p.CVDTOItems = _mapper.Map<List<CVDTO>>(postingcvlist);
            return new ResultDTO<CustomPostingDTO> { Data = p, Message = Messages.PostingListed, Success = true };

        }

        public ResultDTO<CustomPostingDTO> GetFilteredList(CustomPostingDTO p)
        {
            
            var values = _postingDal.GetFilteredList(p);
            var mapper = _mapper.Map<List<PostingDTO>>(values);
            var postingcvlist = _cvDal.GetAll(x => x.UserId == p.UserDTOItems.Id);
            p.PostingDTOItems = mapper;
            p.CVDTOItems = _mapper.Map<List<CVDTO>>(postingcvlist);
            return new ResultDTO<CustomPostingDTO> { Data = p, Message = Messages.PostingListed, Success = true };
        }
    }
}
