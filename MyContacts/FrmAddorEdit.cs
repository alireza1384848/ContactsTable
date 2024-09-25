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
        public FrmAddorEdit()
        {
            InitializeComponent();
            myContacts = new ContactsRepo();
        }

        private void FrmAddorEdit_Load(object sender, EventArgs e)
        {

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
                bool is_successful = myContacts.Insert(txtName.Text, txtFamily.Text, txtMobile.Text, txtAddres.Text, (int)txtAge.Value, txtEmail.Text);
                if (is_successful)
                {
                    MessageBox.Show("عملیات باموفقیت انجام شد.", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DialogResult = DialogResult.OK;
                }
                else
                {
                    MessageBox.Show("مشکلی در انجام عملیات پیش آمد.", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    DialogResult= DialogResult.Cancel;
                }


            }
        }
    }
}
