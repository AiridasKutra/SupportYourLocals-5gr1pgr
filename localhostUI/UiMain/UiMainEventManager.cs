using Common;
using localhostUI.Backend.DataManagement;
using localhostUI.Classes.EventClasses;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Forms.Design;

namespace localhostUI
{
    public partial class UiMain
    {
        private List<DataList> drafts = Program.DataPool.eventsDraft;
        private void SaveDraftFile(object sender, EventArgs e)
        {   
            AddDraftFileToList();
        }

        private void AddDraftFileToList()
        {
            EventFull eventFull = new EventFull
            {
                Name = nameBox.Text,
                Address = eventAdressBox.Text,
                StartDate = dateBox.Value,
                Price = (decimal)priceBox.Value,
                Description = descriptionBox.Text
            };
            eventFull.AddSport(sportBox.Text);

            DataList data = EventFull.ToDataList(eventFull);
            drafts.Add(data);
        }

        
    }
}
