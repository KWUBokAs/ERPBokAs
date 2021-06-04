using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp1.BACK;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json.Linq;
using System.Security.Cryptography;

namespace WindowsFormsApp1.MeetRoom
{  
    class SeatAct
    {
      
        public bool used ;
        
        private SeatAct(bool u)
        {
            used = u;
        }

    }
   
    
}
