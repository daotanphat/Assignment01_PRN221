using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public interface IMemberRepository
    {
        IEnumerable<Member> GetMembers();
        void AddMember(Member member);
        Member GetMemberById(int id);
        void UpdateMember(Member member);
        void deleteMember(int memberId);

        bool isAdmin(Member member);
        Member verifyMember(Member member);
    }
}
