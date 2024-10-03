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
    public partial class Form1 : Form
    {
        IMyContacts myContacts;

        public Form1()
        {
            InitializeComponent();
            myContacts = new EnContactsrRepo();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            bindGrid();
        }

        private void bindGrid()
        {
           
            dgcontacts.AutoGenerateColumns = false;
            dgcontacts.DataSource = myContacts.SelectAll();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            bindGrid();
        }

        private void btnAddContact_Click(object sender, EventArgs e)
        {
            FrmAddorEdit frm = new FrmAddorEdit(0);
            frm.ShowDialog();
            if (frm.DialogResult == DialogResult.OK)
            {
                bindGrid();
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {

        }

        private void btnupdate_Click(object sender, EventArgs e)
        {
            if (dgcontacts.CurrentRow != null)
            {
                int id = int.Parse(dgcontacts.CurrentRow.Cells["ContactID"].Value.ToString());
                FrmAddorEdit frm1 = new FrmAddorEdit(id);
                if (frm1.ShowDialog() == DialogResult.OK) {
                    bindGrid();
                }
            }
            else 
            {
                MessageBox.Show("لطفا سطر مورد نظر خود را انتخاب کنید.", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            if (dgcontacts.CurrentRow != null)
            {
                string name = dgcontacts.CurrentRow.Cells[1].Value.ToString();
                string family = dgcontacts.CurrentRow.Cells[2].Value.ToString();
                string fullname = name + " " + family;
                if (MessageBox.Show($"آیا از حذف فرد مورد نظر اطمینان دارید ؟ ", "توجه", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    int id = int.Parse(dgcontacts.CurrentRow.Cells["ContactID"].Value.ToString());
                    //MessageBox.Show(id.ToString());
                    if (myContacts.delete(id) == true)
                        bindGrid();
                    else
                        MessageBox.Show("مشکلی در انجام عملیات پیش امده مجدد تلاش کنید.", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            else
            {
                MessageBox.Show("لطفا سطر مورد نظر خود را انتخاب کنید.", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            dgcontacts.DataSource=myContacts.Search(textBox1.Text);


        }
    }
}
