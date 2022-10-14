using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Api.Models
{
    public class BookWithReaderId
    {
        public string Header { get; set; }
        public bool IsFree { get; set; } = true;
        public DateTime LastDateForGiveBack { get; set; }
        public bool Overdue { get; set; } = false;
        public string UserName { get; set; }
    }
}
