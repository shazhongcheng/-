using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Test4
{
    public partial class Par : Form
    {
        public Par()
        {
            InitializeComponent();
        }

        private void Par_Load(object sender, EventArgs e)
        {
            UpdateData();
        }
        /// <summary>
        /// 更新表中数据
        /// </summary>
        private void UpdateData()
        {

            DataTable table = initTable();

            using (SQLiteDataReader reader = SqlHelper.ExecuteReader("select * from Part;"))
            {
                while (reader.Read())
                {
                    DataRow dr = table.NewRow();
                    dr[0] = reader.GetInt32(0).ToString().Trim();
                    dr[1] = reader.GetInt32(1).ToString().Trim();
                    dr[2] = reader.GetValue(2).ToString().Trim();
                    table.Rows.Add(dr);
                }
            }
            dataGridView1.DataSource = table;
        }

        private DataTable initTable()
        {
            DataTable table = new DataTable();

            table.Columns.Add("客户ID", typeof(String));

            table.Columns.Add("商品ID", typeof(String));

            table.Columns.Add("特殊单价", typeof(String));


            return table;
        }

        private void btn_Update_Click(object sender, EventArgs e)
        {
            UpdateData();
        }
    }
}
