using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity_Framework
{
    public class Member
    {
        public int MemberID { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public DateTime JoinDate {  get; set; }
        public bool IsActive { get; set; }
        public MembershipCard MembershipCard { get; set; }
        public ICollection<BookLoan> BookLoans { get; set; } = new List<BookLoan>();
            
    }
}
