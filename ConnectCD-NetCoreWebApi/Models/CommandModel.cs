
namespace ConnectCD.NetCoreWebApi.Models
{
    public class CommandModel
    {
        /// <summary>
        ///  Authentication 
        /// </summary>
        public string Challenge { get; set; }

        public string Token { get; set; }

        public string Command { get; set; }
        ///public string Token { get; set; }

        public string Team_Id { get; set; }

        public string Api_App_Id { get; set; }

        public EventTypeInfo Event { get; set; }
              
        public string Type { get; set; }
            
        public string Event_Id { get; set; }
        
        public int Event_Time { get; set; }

        public string[] Authed_Users { get; set; }
        
    } 
    

    
}
