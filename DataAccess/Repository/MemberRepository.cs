using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class MemberRepository : IMemberRepository
    {
        public void AddMember(Member member)
        {
            MemberDAO.Instance.addMember(member);
        }

        public void deleteMember(int memberId)
        {
            MemberDAO.Instance.deleteMember(memberId);
        }

        public Member GetMemberById(int id)
        {
            return MemberDAO.Instance.GetMemberById(id);
        }

        public IEnumerable<Member> GetMembers()
        {
            return MemberDAO.Instance.GetMembers();
        }

        public bool isAdmin(Member member)
        {
            return MemberDAO.Instance.isAdmin(member);
        }

        public void UpdateMember(Member member)
        {
            MemberDAO.Instance.UpdateMember(member);
        }

        public Member verifyMember(Member member)
        {
            return MemberDAO.Instance.verifyMember(member);
        }
    }
}
