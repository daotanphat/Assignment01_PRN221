using BusinessObject;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class MemberDAO
    {
        private static MemberDAO instance = null;
        private static readonly object instanceLock = new object();
        private MemberDAO() { }
        public static MemberDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new MemberDAO();
                    }
                    return instance;
                }
            }
        }

        public IEnumerable<Member> GetMembers()
        {
            List<Member> members = new List<Member>();
            var myStoreDB = new FStoreContext();
            try
            {
                members = myStoreDB.Members.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return members;
        }

        public Member GetMemberById(int id)
        {
            Member member = new Member();
            var myStoreDB = new FStoreContext();
            try
            {
                member = myStoreDB.Members.SingleOrDefault(m => m.MemberId == id);
                if (member == null)
                {
                    throw new Exception("Member not found!");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return member;
        }

        public void addMember(Member member)
        {
            var myStoreDB = new FStoreContext();
            try
            {
                Member member1 = myStoreDB.Members.SingleOrDefault(m => m.Email == member.Email);
                if (member1 != null)
                {
                    throw new Exception("Member with email is already exist");
                }
                myStoreDB.Members.Add(member);
                myStoreDB.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void UpdateMember(Member member)
        {
            var myStoreDB = new FStoreContext();
            try
            {
                Member member1 = GetMemberById(member.MemberId);
                if (member1 == null)
                {
                    throw new Exception("Member not exist");
                }
                myStoreDB.Entry<Member>(member).State = EntityState.Modified;
                myStoreDB.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void deleteMember(int id)
        {
            try
            {
                var myStoreDB = new FStoreContext();
                Member member1 = GetMemberById(id);
                if (member1 == null)
                {
                    throw new Exception("Member is not exist");
                }
                myStoreDB.Members.Remove(member1);
                myStoreDB.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool isAdmin(Member member)
        {
            try
            {
                var config = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                    .Build();

                var adminEmail = config["AdminAccount:email"];
                var adminPassword = config["AdminAccount:password"];

                if (member.Email.Equals(adminEmail) && member.Password.Equals(adminPassword)) return true;
                return false;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Member verifyMember(Member member)
        {
            Member member1;
            try
            {
                var myStoreDB = new FStoreContext();
                member1 = myStoreDB.Members.SingleOrDefault(m => m.Email.Equals(member.Email) && m.Password.Equals(member.Password));
                if (member1 == null)
                {
                    throw new Exception("Email or password is not correct!");
                }
                return member1;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
