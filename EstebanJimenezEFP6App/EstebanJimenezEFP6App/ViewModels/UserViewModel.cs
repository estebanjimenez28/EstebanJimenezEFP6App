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
        public UserDTO MyUserDTO { get; set; }

        public Ask MyAsk { get; set; }
        public AskDTO MyAskDTO { get; set; }


        public UserViewModel()
        {
            MyUser = new User();
            MyUserDTO = new UserDTO();
            MyAsk = new Ask();  
            MyAskDTO = new AskDTO();    

        }
        //funcion que carga los datos del objeto de usuario global 
        public async Task<UserDTO> GetUserDataAsync(string puserName)
        {
            if (IsBusy) return null;
            IsBusy = true;

            try
            {
                UserDTO userDTO = new UserDTO();

                userDTO = await MyUserDTO.GetUserInfo(puserName);

                if (userDTO == null) return null;

                return userDTO;

            }
            catch (Exception)
            {
                return null;
                throw;
            }
            finally { IsBusy = false; }


        }

        //funcion que carga los datos del objeto de ask global 
        public async Task<AskDTO> GetAskDataAsync(string pask)
        {
            if (IsBusy) return null;
            IsBusy = true;

            try
            {
                AskDTO askDTO = new AskDTO();

                askDTO = await MyAskDTO.GetAskInfo(pask);

                if (askDTO == null) return null;

                return askDTO;

            }
            catch (Exception)
            {
                return null;
                throw;
            }
            finally { IsBusy = false; }


        }
        public async Task<bool> UserAccessValidation(string puserName, string puserPassword)
        {
            //debemos poder controlar que no se ejecute la operación más de una vez 
            //en este caso hay una funcionalidad pensada para eso en BaseViewModel que 
            //fue heredada al definir esta clase. 
            //Se usará una propiedad llamada "IsBusy" para indicar que está en proceso de ejecución
            //mientras su valor sea verdadero 

            //control de bloqueo de funcionalidad 
            if (IsBusy) return false;
            IsBusy = true;

            try
            {
                MyUser.UserName = puserName;
                MyUser.UserPassword = puserPassword;

                bool R = await MyUser.ValidateUserLogin();

                return R;
            }
            catch (Exception ex)
            {
                string msg = ex.Message;

                return false;

                throw;
            }
            finally
            {
                IsBusy = false;
            }
        }
        //función de creación de nuena pregunta(ask)
        public async Task<bool> AddAskAsync(DateTime pdate,
                                             string pask1,
                                             int puserId,
                                             int pAskStatusId,
                                             string pUmageUrl,
                                             string pAskDetail)
                                             
        {
            if (IsBusy) return false;
            IsBusy = true;

            try
            {
                // MyUser = new User();

                MyAsk.Date = pdate;
                MyAsk.Ask1 = pask1;
                MyAsk.UserId = puserId;
                MyAsk.AskStatusId = pAskStatusId;
                MyAsk.ImageUrl = pUmageUrl;
                MyAsk.AskDetail = pAskDetail;
              

                bool R = await MyAsk.AddAskAsync();

                return R;

            }
            catch (Exception)
            {

                throw;

            }
            finally { IsBusy = false; }

        }

        internal Task<bool> AddAskAsync(string v1, string v2, string v3, string v4)
        {
            throw new NotImplementedException();
        }

        internal Task<bool> AddAskAsync(string v1, string v2, string v3, string v4, string v5)
        {
            throw new NotImplementedException();
        }
    }
}
