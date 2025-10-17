using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity_Framework
{
    public class MembershipCard
    {
        public int MembershipCardId { get; set; }
        public string CardNumber { get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime ExpiryDate { get; set; }
        public string Status { get; set; }
        public int MemberId { get; set; }
        public Member Member { get; set; }
    }
}
