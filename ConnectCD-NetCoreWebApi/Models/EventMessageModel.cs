using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConnectCD.NetCoreWebApi.Models
{
    public class EventMessageModel
    {
        
        public string Token { get; set; }

        public string Team_Id { get; set; }

        public string Api_App_Id { get; set; }

        public EventTypeInfo Event { get; set; }
              
        public string Type { get; set; }
            

        public string Event_Id { get; set; }
        
        public int Event_Time { get; set; }

        public string[] Authed_Users { get; set; }
        
    }
    

    public class EventTypeInfo
    {
        
        public string Type { get; set; }
 
        public string User { get; set; }

        public string Text { get; set; }

        public string Ts { get; set; }

        public string Channel { get; set; }

        public string Event_Ts { get; set; }


    }




    public class ItemType
    {
        public string Type { get; set; }

        public string Channel { get; set; }

        public string TS { get; set; }

    }

}
