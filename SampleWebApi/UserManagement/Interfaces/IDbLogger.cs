using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UserManagement.Models;

namespace UserManagement.Interfaces
{
    public interface IDbLogger
    {
        Task LogToDB(LogApiError error);
    }
}
