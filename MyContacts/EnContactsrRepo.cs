using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace MyContacts
{
    internal class EnContactsrRepo : IMyContacts
    {
        public bool delete(int contactid)
        {
            try
            {
                using (ContatsDBEntities db = new ContatsDBEntities())
                {
                    contantsTable contantsTable = db.contantsTables.Where(n => n.ContantsID == contactid).SingleOrDefault();
                    db.contantsTables.Remove(contantsTable);
                    db.SaveChanges();
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Insert(string name, string family, string mobile, string address, int age, string email)
        {
            try
            {
                using (ContatsDBEntities db = new ContatsDBEntities())
                {
                    contantsTable contant = new contantsTable()
                    {
                        Name = name,
                        Family = family,
                        Mobile = mobile,
                        Address = address,
                        Age = age,
                        Email = email
                    };
                    db.contantsTables.Add(contant);
                    db.SaveChanges();
                }
                
                return true;
            }
            catch
            {
                return false;
            }
        }

        private DataTable Convertdatatotable(List<contantsTable> contants)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("ContantsID");
            dt.Columns.Add("Name");
            dt.Columns.Add("Family");
            dt.Columns.Add("Age");
            dt.Columns.Add("Mobile");
            dt.Columns.Add("Address");
            dt.Columns.Add("Email");
            foreach (contantsTable contant in contants)
            {
                
                DataRow _row = dt.NewRow();
                _row[0] = contant.ContantsID;
                _row[1] = contant.Name;
                _row[2] = contant.Family;
                _row[3] = contant.Age;
                _row[4] = contant.Mobile;
                _row[5] = contant.Address;
                _row[6] = contant.Email;
                dt.Rows.Add(_row);
            }
            return dt;
        }

        public DataTable Search(string parameters)
        {
            using (ContatsDBEntities db = new ContatsDBEntities())
            {
                var contants = db.contantsTables.Where(n => n.Name.ToLower().Contains(parameters) || n.Family.ToLower().Contains(parameters)).ToList();
                return this.Convertdatatotable(contants);
            }
        }

        public DataTable SelectAll()
        {
            using (ContatsDBEntities db = new ContatsDBEntities())
            {
                var contants = db.contantsTables.ToList();
                return this.Convertdatatotable(contants);
            }
        }

        public DataTable SelectRow(int contactid)
        {
            using (ContatsDBEntities db = new ContatsDBEntities())
            {
                var contants = db.contantsTables.Where(n => n.ContantsID == contactid).ToList();
                return this.Convertdatatotable(contants);
            }



        }

        public bool update(int contactid, string name, string family, string mobile, string address, int age, string email)
        {
            using (ContatsDBEntities db = new ContatsDBEntities())
            {
                var contants = db.contantsTables.Where(n => n.ContantsID == contactid).SingleOrDefault();
                contants.Name = name;
                contants.Family = family;
                contants.Address = address;
                contants.Age = age;
                contants.Email = email;
                contants.Mobile = mobile;
                db.SaveChanges();

            }
            return true;


        }
    }
}
