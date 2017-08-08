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
    public partial class Client : Form
    {
        public Client()
        {
            InitializeComponent();
        }

        private void btn_Add_Click(object sender, EventArgs e)
        {
            //int id = Convert.ToInt32(txt_CId.Text.Trim());
            string Cname, CTel, CAdd;

            if (Confrim(out Cname, out CTel, out CAdd))
            {
                string str = String.Format("insert into Client([name] ,[telephone],[address]) values('{0}','{1}','{2}')", Cname, CTel, CAdd);

                SqlHelper.ExecuteNonQuery(str);
                UpdateData();
            }

        }

        private bool Confrim(out string cname, out string cTel, out string cAdd)
        {
            cname = txt_CName.Text.Trim();
            cTel = txt_Ctel.Text.Trim();
            cAdd = txt_Cadd.Text.Trim();

            if (cname == string.Empty)
            {

                if (MessageBox.Show("收货单位为空，是否确定？", "Confirm Message", MessageBoxButtons.OKCancel) != DialogResult.OK)
                {
                    return false;
                }

            }
            if (cTel == string.Empty)
            {

                if (MessageBox.Show("电话为空，是否确定？", "Confirm Message", MessageBoxButtons.OKCancel) != DialogResult.OK)
                {
                    return false;
                }

            }
            if (cAdd == string.Empty)
            {

                if (MessageBox.Show("地址为空，是否确定？", "Confirm Message", MessageBoxButtons.OKCancel) != DialogResult.OK)
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// 更新表中数据
        /// </summary>
        private void UpdateData()
        {

            DataTable table = initTable();

            using (SQLiteDataReader reader = SqlHelper.ExecuteReader("select * from Client;"))
            {
                while (reader.Read())
                {
                    DataRow dr = table.NewRow();
                    dr[0] = reader.GetInt32(0).ToString().Trim();
                    dr[1] = reader.GetString(1).Trim();
                    dr[2] = reader.GetString(2).Trim();
                    dr[3] = reader.GetString(3).Trim();
                    table.Rows.Add(dr);
                }
            }
            dataGridView1.DataSource = table;
        }

        private DataTable initTable()
        {
            DataTable table = new DataTable();

            table.Columns.Add("ID", typeof(String));

            table.Columns.Add("姓名", typeof(String));

            table.Columns.Add("电话", typeof(String));

            table.Columns.Add("地址", typeof(String));


            return table;
        }

        private void Client_Load(object sender, EventArgs e)
        {
            UpdateData();
        }

        private void 删除ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow.Index < 0)
            {
                return;
            }
            string id = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value.ToString();
            DialogResult dr = MessageBox.Show(String.Format("确认删除id为{0}的客户吗？", id), "提示", MessageBoxButtons.OKCancel);

            if (dataGridView1.CurrentRow.Index >= 0 && dr == DialogResult.OK)
            {
                string sql = String.Format("delete from Client where Id = {0}", id);
                int n = SqlHelper.ExecuteNonQuery(sql);
                if (n > 0)
                {
                    UpdateData();
                    MessageBox.Show("删除成功！");
                }
                else
                {
                    MessageBox.Show("删除失败！");
                }
            }
        }

        private void 修改ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow.Index < 0)
            {
                return;
            }
            string id = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value.ToString();

            string Cname, CTel, CAdd;

            if (Confrim(out Cname, out CTel, out CAdd))
            {
                string sql = String.Format("update Client set [name]='{0}' ,[telephone]='{1}',[address]='{2}' where id = {3}",Cname,CTel,CAdd,id);
                int n = SqlHelper.ExecuteNonQuery(sql);
                if (n > 0)
                {
                    UpdateData();
                    MessageBox.Show("修改成功！");
                }
                else
                {
                    MessageBox.Show("修改失败！");
                }
            }
        }

        private void btn_Del_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow.Index < 0)
            {
                return;
            }
            string id = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value.ToString();
            DialogResult dr = MessageBox.Show(String.Format("确认删除id为{0}的客户吗？", id), "提示", MessageBoxButtons.OKCancel);

            if (dataGridView1.CurrentRow.Index >= 0 && dr == DialogResult.OK)
            {
                string sql = String.Format("delete from Client where Id = {0}", id);
                int n = SqlHelper.ExecuteNonQuery(sql);
                if (n > 0)
                {
                    UpdateData();
                    MessageBox.Show("删除成功！");
                }
                else
                {
                    MessageBox.Show("删除失败！");
                }
            }
        }

        private void btn_Update_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow.Index < 0)
            {
                return;
            }
            string id = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value.ToString();

            string Cname, CTel, CAdd;

            if (Confrim(out Cname, out CTel, out CAdd))
            {
                string sql = String.Format("update Client set [name]='{0}' ,[telephone]='{1}',[address]='{2}' where id = {3}", Cname, CTel, CAdd, id);
                int n = SqlHelper.ExecuteNonQuery(sql);
                if (n > 0)
                {
                    UpdateData();
                    MessageBox.Show("修改成功！");
                }
                else
                {
                    MessageBox.Show("修改失败！");
                }
            }
        }

        private void btn_Find_Click(object sender, EventArgs e)
        {
            string cid = txt_CId.Text.Trim();
            string cname = txt_CName.Text.Trim();
            string cTel = txt_Ctel.Text.Trim();
            string cAdd = txt_Cadd.Text.Trim();

            string sql = String.Format("select * from Client where cast([Id] as CHAR(50)) like '%{0}%' and [name] like '%{1}%' and [telephone]like '%{2}%' and [address] like '%{3}%';", cid, cname, cTel, cAdd);

            SerachData(sql);

        }

        private void SerachData(string sql)
        {
            DataTable table = initTable();

            using (SQLiteDataReader reader = SqlHelper.ExecuteReader(sql))
            {
                while (reader.Read())
                {
                    DataRow dr = table.NewRow();
                    dr[0] = reader.GetInt32(0).ToString().Trim();
                    dr[1] = reader.GetString(1).Trim();
                    dr[2] = reader.GetString(2).Trim();
                    dr[3] = reader.GetString(3).Trim();
                    table.Rows.Add(dr);
                }
            }
            dataGridView1.DataSource = table;

        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow.Index < 0)
            {
                return;
            }
            int id = dataGridView1.CurrentRow.Index;

            txt_CId.Text = dataGridView1.Rows[id].Cells[0].Value.ToString();
            txt_CName.Text = dataGridView1.Rows[id].Cells[1].Value.ToString();
            txt_Ctel.Text = dataGridView1.Rows[id].Cells[2].Value.ToString();
            txt_Cadd.Text = dataGridView1.Rows[id].Cells[3].Value.ToString();

        }
    }
}
