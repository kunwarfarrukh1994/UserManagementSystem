using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace UserManagement.Models
{
    public class LogApiError

    {
        [Key]
        public int Id { get; set; }
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public string RequestMethod { get; set; }
        public string RequestUri { get; set; }

        public string QueryParams { get; set; }
    public DateTime TimeUtc { get; set; }

    public string UserName { get; set; }
    }
}
