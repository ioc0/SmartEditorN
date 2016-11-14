using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data;

namespace ARCSO
{
    public partial class Form1 : Form
    {
        private string[] ipaddr = { "СО","СО2" };
        private string login;
        private string pass;
        private string ip;//(Пока затычка и хардкод)
        
        public Form1()
        {
            InitializeComponent();
            button1.Enabled = true;
            cbServers.DataSource = ipaddr;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (cbServers.SelectedItem == ipaddr[0])
            {
                ip = "185.4.75.35";
            }
            else MessageBox.Show("Second server");

            MySql.Data.MySqlClient.MySqlConnection conn;
            
            
            string myConnStr = "server=185.4.75.35; uid=root;" + "pwd=Ex3a3aTrvb5;database=CO";
            //try
            //{
            //    conn = new MySql.Data.MySqlClient.MySqlConnection();
            //    conn.ConnectionString = myConnStr;
            //    conn.Open();
            //    MessageBox.Show("OK");
            //    conn.Close();
           // }
           // catch (MySql.Data.MySqlClient.MySqlException ex)
           // {
           //
             //   MessageBox.Show(ex.Message);
            //}


        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Settings set = new Settings();
            set.Show();
        }
    }
}
