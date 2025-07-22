using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pharmacy.Forms
{
    public interface UserMessage
    {
        Task<bool> Send(string message);
        Task<IEnumerable<ContactMessage>> GetAllMessagesAsync();
        Task<bool> MarkMessage(int messid);

    }
}
