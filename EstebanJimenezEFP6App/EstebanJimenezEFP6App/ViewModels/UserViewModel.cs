using EstebanJimenezEFP6App.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EstebanJimenezEFP6App.ViewModels
{
    public class UserViewModel : BaseViewModel
    {
        public User MyUser { get; set; }

        public Ask MyAsk { get; set; }

        public AskStatus MyAskStatus { get; set; }


        public UserViewModel()
        {
            MyUser = new User();
            MyAsk = new Ask();
            MyAskStatus = new AskStatus();


        }

        public async Task<User> GetUserDataAsync()
        {
            if (IsBusy) return null;
            IsBusy = true;

            try
            {
                User user = new User();

                user = await MyUser.GetUser();

                if (user == null) return null;

                return user;

            }
            catch
            (Exception)
            {
                return null;
                throw;
            }
            finally { IsBusy = false; }
        }


        //funcion que carga los datos del objeto de usuario global 
        public async Task<Ask> GetAskDataAsync(string Pask)
        {
            if (IsBusy) return null;
            IsBusy = true;

            try
            {
                Ask ask = new Ask();

                ask = await MyAsk.GetAskInfo(Pask);

                if (ask == null) return null;

                return ask;

            }
            catch (Exception)
            {
                return null;
                throw;
            }
            finally { IsBusy = false; }


        }
        public async Task<List<AskStatus>> GetAskStatusAsync()
        {
            try
            {
                List<AskStatus> status = new List<AskStatus>();

                status = await MyAskStatus.GetAllAskStatusAsync();

                if (status == null)
                {
                    return null;
                }

                return status;

            }
            catch (Exception)
            {

                throw;
            }
        }
        //función de creación de  nuevo Ask
        public async Task<bool> AddAskAsync(DateTime pdate,
                                             string pask1,
                                             int puserId,
                                             string pUmagenUrl,
                                             string pAskDetail,
                                             int pAskStatusID)
        {
            if (IsBusy) return false;
            IsBusy = true;

            try
            {
                // MyUser = new User();

                MyAsk.Date = pdate;
                MyAsk.Ask1= pask1;
                MyAsk.UserId = puserId;
                MyAsk.ImageUrl = pUmagenUrl;
                MyAsk.AskDetail = pAskDetail;
                MyAsk.AskStatusId = pAskStatusID;

                bool R = await MyAsk.AddAskAsync();

                return R;

            }
            catch (Exception)
            {

                throw;

            }
            finally { IsBusy = false; }

        }

    }
}
