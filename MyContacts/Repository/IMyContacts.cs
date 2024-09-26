using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
namespace MyContacts
{
    internal interface IMyContacts
    {
        bool Insert(string name,string family,string mobile,string address ,int age,string email);
        bool update(int contactid,string name,string family,string mobile,string address ,int age,string email);
        bool delete(int contactid);
        DataTable SelectAll();
        DataTable SelectRow(int contactid);

        DataTable Search(string parameters);
    }
}
