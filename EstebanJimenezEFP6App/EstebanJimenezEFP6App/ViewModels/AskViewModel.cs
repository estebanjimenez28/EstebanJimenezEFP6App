using EstebanJimenezEFP6App.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace EstebanJimenezEFP6App.ViewModels
{
    public class AskViewModel :BaseViewModel
    {
        public Ask MyAsk { get; set; }

        public AskViewModel()
        {
            MyAsk = new Ask();
        }
        //funciones del vm
        public async Task<ObservableCollection<Ask>> GetAsksAsync(int pUserID)
        {
            if (IsBusy) return null;
            IsBusy = true;

            try
            {
                ObservableCollection<Ask> asks = new ObservableCollection<Ask>();

                MyAsk.UserId = pUserID;

                asks = await MyAsk.GetAskListByUserID();

                if (asks == null)
                {
                    return null;
                }
                return asks;

            }
            catch (Exception)
            {
                return null;
                throw;
            }

        }



    }
}
