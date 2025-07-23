using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pharmacy.Models
{
    public class UserActivityLog
    {
       int LogID {  get; set; }
       int UserID {  get; set; }
       string Username {  get; set; }
       string ActionType {  get; set; }
	   string ActionDetails {  get; set; }
    }
}
