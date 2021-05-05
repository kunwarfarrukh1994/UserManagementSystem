using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UserManagement.Models;

namespace UserManagement.Interfaces
{
    public interface IDbLogger
    {
        void ROLLBACK_Transaction();
        Task LogToDB(LogApiError error);
    }
}
