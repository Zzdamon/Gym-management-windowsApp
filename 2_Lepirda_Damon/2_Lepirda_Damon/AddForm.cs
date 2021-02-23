using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using _2_Lepirda_Damon.entities;

namespace _2_Lepirda_Damon
{
    public partial class AddForm : Form
    {
        public Membership membership;
        public AddForm(Membership membership)
        {
            this.membership = membership;
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void tbName_Validating(object sender, CancelEventArgs e)
        {
            if( string.IsNullOrEmpty( tbName.Text.Trim()) || string.IsNullOrWhiteSpace(tbName.Text.Trim()))
            {
                e.Cancel = true; 
                errorProvider1.SetError((Control)sender, "Name is empty!");

            }
        }

        private void tbName_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError((Control)sender, string.Empty);
        }

        private void tbType_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(tbType.Text.Trim()) || string.IsNullOrWhiteSpace(tbType.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError((Control)sender, "Type is empty!");

            }
        }

        private void tbType_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError((Control)sender, string.Empty);

        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (ValidateChildren())
            {
                membership.Name = tbName.Text.Trim();
                membership.Type = tbType.Text.Trim();
                membership.Price = (double)numPrice.Value;
            }
            else MessageBox.Show("Form contains errors  ");
            //gym.Memberships.Add(membership);
        }

        private void AddForm_Load(object sender, EventArgs e)
        {
            if (membership!= null)
            {
                tbName.Text = membership.Name;
                tbType.Text = membership.Type;
                numPrice.Value = (decimal)membership.Price;
            }
        }
    }
}
