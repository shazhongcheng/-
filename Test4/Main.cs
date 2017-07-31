using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Test4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            SqlHelper.CreateDB();
            SqlHelper.CreateClientTable();
            SqlHelper.CreateRelishTable();
            SqlHelper.CreatePartTable();
        }

        private void btn_OpenC_Click(object sender, EventArgs e)
        {
            Client client = new Client();
            client.Show();
        }
    }
}
