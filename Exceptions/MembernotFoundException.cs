using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library_System.Classes;

namespace Library_System.Exceptions
{
    public class MembernotFoundException : Exception
    {
        public Member ToFindMember { get; private set; }
        public MembernotFoundException(string message, Member tofindmember) : base(message)
        {
            this.ToFindMember = tofindmember;
        }
    }
}
