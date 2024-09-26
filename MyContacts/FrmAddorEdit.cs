using MyContacts.services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyContacts
{
    public partial class FrmAddorEdit : Form
    {
        IMyContacts myContacts;
        private int contactId = 0;
        public FrmAddorEdit(int contactid)
        {
            InitializeComponent();
            this.contactId = contactid;
            myContacts = new ContactsRepo();
        }

        private void FrmAddorEdit_Load(object sender, EventArgs e)
        {
            if (this.contactId == 0)
            {
                this.Text = "افزودن شخض جدید";
                btnsubmit.Text = "ثبت";
            }
            else
            {
                this.Text = "ویرایش شخص";
                btnsubmit.Text = "ویرایش";
                DataTable dt = myContacts.SelectRow(contactId);
                txtName.Text = dt.Rows[0][1].ToString();
                txtFamily.Text = dt.Rows[0][2].ToString();
                txtMobile.Text = dt.Rows[0][4].ToString();
                txtAddres.Text = dt.Rows[0][5].ToString();
                txtAge.Text = dt.Rows[0][3].ToString();
                txtEmail.Text = dt.Rows[0][6].ToString();

            }




        }

        bool Verify_Incomes()
        {
            bool isok = true;

            if (txtName.Text == "")
            {
                MessageBox.Show("لطفا نام را وارد کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (txtFamily.Text == "")
            {
                MessageBox.Show("لطفا نام خانودگی را وارد کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (txtMobile.Text == "")
            {
                MessageBox.Show("لطفا شماره موبایل را وارد کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (txtAge.Value == 0)
            {
                MessageBox.Show("لطفا سن را وارد کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (txtEmail.Text == "")
            {
                MessageBox.Show("لطفا ایمیل را وارد کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return isok;
        }
        private void btnsubmit_Click(object sender, EventArgs e)
        {
            if (Verify_Incomes())
            {
                bool is_successful = true;
                if (contactId == 0)
                {
                     is_successful = myContacts.Insert(txtName.Text, txtFamily.Text, txtMobile.Text, txtAddres.Text, (int)txtAge.Value, txtEmail.Text);
                }
                else
                {
                    is_successful = myContacts.update(contactId, txtName.Text, txtFamily.Text, txtMobile.Text, txtAddres.Text, (int)txtAge.Value, txtEmail.Text);
                }

                if (is_successful)
                {
                    MessageBox.Show("عملیات باموفقیت انجام شد.", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DialogResult = DialogResult.OK;
                }
                else
                {
                    MessageBox.Show("مشکلی در انجام عملیات پیش آمد.", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    DialogResult = DialogResult.Cancel;
                }


            }

        }
    }
}
