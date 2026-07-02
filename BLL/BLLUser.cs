using BE;
using DAL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class BLLUser
    {
        public string Encode(string pass)
        {
            byte[] encData_byte = new byte[pass.Length];
            encData_byte = System.Text.Encoding.UTF8.GetBytes(pass);
            string encodeddata = Convert.ToBase64String(encData_byte);
            return encodeddata;

        }
        public string Decode(string Encodepass)
        {
            System.Text.UTF8Encoding encoder = new System.Text.UTF8Encoding();
            System.Text.Decoder dec = encoder.GetDecoder();
            byte[] todecode = Convert.FromBase64String(Encodepass);
            int charcount = dec.GetCharCount(todecode, 0, todecode.Length);
            char[] decode_char = new char[charcount];
            dec.GetChars(todecode, 0, todecode.Length, decode_char, 0);
            string resault = new string(decode_char);
            return resault;
        }
        DALUsers dal = new DALUsers();
        public string Create(Users U, Usergroup UG)
        {
            U.password = Encode(U.password);
            return dal.Create(U, UG);
        }
        public bool IsRegistered()
        {
            return dal.IsRegistered();
        }
        public bool Read(Users U)
        {
            return dal.Read(U);
        }
        public DataTable Read()
        {
            return dal.Read();
        }
        public DataTable Read(string u, int index)
        {
            return dal.Read(u, index);
        }
        public Users Read(int id)
        {
            return dal.Read(id);
        }
        public Users ReadU(string s)
        {
            return dal.ReadU(s);
        }
        public List<string> ReadUserName()
        {
            return dal.ReadUserName();
        }
        public string Update(int id, Users U)
        {
            U.password = Encode(U.password);
            return dal.Update(id, U);
        }
        public string Delete(int id)
        {
            return dal.Delete(id);
        }
        public List<Users> ActivityRegistered()
        {
            return dal.ActivityRegistered();
        }
        public Users Login(string username, string Pass)
        {
            return dal.Login(username, Encode(Pass));
        }
        public bool AccessTo(Users U, string S, int A)
        {
            return dal.AccessTo(U, S, A);
        }
        public string Usercount()
        {
            return dal.Usercount();
        }
        public string ReadUsername()
        {
            return dal.ReadUsername();
        }
        public string Readname()
        {
            return dal.Readname();
        }

        public string UpdateIsActive(int LoggedUserId)
        {
            return dal.UpdateIsActive(LoggedUserId);
        }
    }
}
