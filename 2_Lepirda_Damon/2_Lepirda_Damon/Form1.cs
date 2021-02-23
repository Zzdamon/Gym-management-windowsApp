using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using _2_Lepirda_Damon.entities;

namespace _2_Lepirda_Damon
{
    public partial class Form1 : Form
    {
        public Gym gym= new Gym();
        private string ConnectionString = "Data Source=gym.db";
        public Form1()
        {   
            
            InitializeComponent();
        }

        private void lvGym_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnSecondForm_Click(object sender, EventArgs e)
        {
            Membership membership = new Membership();
            AddForm form = new AddForm(membership);
            if (form.ShowDialog() == DialogResult.OK)
            {
                gym.Memberships.Add(membership);
                DisplayMemberships();
            }
        }

        private void DisplayMemberships()
        {
            lvGym.Items.Clear();
            gym.Memberships.Sort();

            foreach (Membership membership in gym.Memberships)
            {
                var listViewItem = new ListViewItem(membership.Name);
                listViewItem.SubItems.Add(membership.Type);
                listViewItem.SubItems.Add(membership.Price.ToString());
                

                listViewItem.Tag = membership;

                lvGym.Items.Add(listViewItem);
            }
        }

        private void eDITToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (lvGym.SelectedItems.Count == 1)
            {
                AddForm form = new AddForm((Membership)lvGym.SelectedItems[0].Tag);
                form.ShowDialog();
                DisplayMemberships();
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream s = File.Create("gym.bin"))
                formatter.Serialize(s, gym);

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                BinaryFormatter formatter = new BinaryFormatter();
                using (FileStream s = File.OpenRead("gym.bin"))
                {
                    gym = ((Gym)formatter.Deserialize(s));
                    DisplayMemberships();
                }
            }
            catch { }

        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            foreach (Membership membership in gym.Memberships)
            {
                try {
                    var queryString = "insert into memberships(name, type, price)" +
                                        " values(@name,@type,@price);";

                    using (SQLiteConnection connection = new SQLiteConnection(ConnectionString))
                    {
                        connection.Open();

                        //1. Add the new participant to the database
                        var command = new SQLiteCommand(queryString, connection);
                        command.Parameters.AddWithValue("@name", membership.Name);
                        command.Parameters.AddWithValue("@type", membership.Type);
                        command.Parameters.AddWithValue("@price", membership.Price);

                        command.ExecuteNonQuery();
                    }
                    } catch { }
                }
            }

        
    }
}
