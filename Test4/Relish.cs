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
    public partial class Relish : Form
    {
        public Relish()
        {
            InitializeComponent();
        }

        private void Relish_Load(object sender, EventArgs e)
        {
            UpdateData();
        }

        private void UpdateData()
        {
            string sql = "select * from Relish;";
            ShowData(sql);   
        }

        private DataTable initTable()
        {
            DataTable table = new DataTable();

            table.Columns.Add("ID", typeof(String));

            table.Columns.Add("品名", typeof(String));

            table.Columns.Add("单位", typeof(String));

            table.Columns.Add("规格", typeof(String));

            table.Columns.Add("每箱数量", typeof(String));

            table.Columns.Add("单价(每袋)", typeof(String));

            table.Columns.Add("单价(每箱)", typeof(String));

            table.Columns.Add("备注", typeof(String));

            return table;
        }

        private void btn_Add_Click(object sender, EventArgs e)
        {
            //int id = Convert.ToInt32(txt_CId.Text.Trim());
            string Rname, RUnit, Rsta, Rnum, RPriceOne, RNote;

            if (Confrim(out Rname, out RUnit, out Rsta, out Rnum, out RPriceOne, out RNote))
            {
                string str = String.Format("insert into Relish([name],[unit],[standard],[number],[priceone],[note]) values('{0}','{1}','{2}',{3},{4},'{5}')", Rname, RUnit, Rsta, Rnum, RPriceOne, RNote);

                SqlHelper.ExecuteNonQuery(str);
                UpdateData();
            }
        }

        private bool Confrim(out string rname, out string rUnit, out string rsta, out string rnum, out string rPriceOne, out string rNote)
        {
            rname = txt_RName.Text.Trim();
            rUnit = txt_RSet.Text.Trim();
            rsta = txt_RStan.Text.Trim();
            rnum = txt_RNum.Text.Trim();
            rPriceOne = txt_RPriceOne.Text.Trim();
            rNote = txt_RNote.Text.Trim();

            if (rname == string.Empty)
            {

                if (MessageBox.Show("品名为空，是否确定？", "Confirm Message", MessageBoxButtons.OKCancel) != DialogResult.OK)
                {
                    return false;
                }

            }
            if (rUnit == string.Empty)
            {

                if (MessageBox.Show("单位为空，是否确定？", "Confirm Message", MessageBoxButtons.OKCancel) != DialogResult.OK)
                {
                    return false;
                }

            }
            if (rsta == string.Empty)
            {

                if (MessageBox.Show("规格为空，是否确定？", "Confirm Message", MessageBoxButtons.OK) != DialogResult.OK)
                {
                    return false;
                }
            }
            if (rnum == string.Empty)
            {

                if (MessageBox.Show("每箱数量为空，是否确定？", "Confirm Message", MessageBoxButtons.OKCancel) != DialogResult.OK)
                {
                    return false;
                }

            }
            if (rPriceOne == string.Empty)
            {

                if (MessageBox.Show("单价为空，是否确定？", "Confirm Message", MessageBoxButtons.OKCancel) != DialogResult.OK)
                {
                    return false;
                }

            }
            //if (rNote == string.Empty)
            //{

            //    if (MessageBox.Show("地址为空，是否确定？", "Confirm Message", MessageBoxButtons.OKCancel) != DialogResult.OK)
            //    {
            //        return false;
            //    }
            //}
            return true;
        }

        private void 删除ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ActionDel();
        }

        private void ActionDel()
        {
            if (dataGridView1.CurrentRow.Index < 0)
            {
                return;
            }
            string id = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value.ToString();
            DialogResult dr = MessageBox.Show(String.Format("确认删除id为{0}的调味品吗？", id), "提示", MessageBoxButtons.OKCancel);

            if (dataGridView1.CurrentRow.Index >= 0 && dr == DialogResult.OK)
            {
                string sql = String.Format("delete from Relish where Id = {0}", id);
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
            ActionUpdata();
        }

        private void ActionUpdata()
        {
            if (dataGridView1.CurrentRow.Index < 0)
            {
                return;
            }
            string id = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value.ToString();

            string Rname, RUnit, Rsta, Rnum, RPriceOne, RNote;

            if (Confrim(out Rname, out RUnit, out Rsta, out Rnum, out RPriceOne, out RNote))
            {
                string sql = String.Format("update Relish set [name]='{0}' ,[unit]='{1}',[standard]='{2}',[number]='{3}' ,[priceone]='{4}',[note]='{5}' where id = {6}", Rname, RUnit, Rsta, Rnum, RPriceOne, RNote, id);

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
            ActionDel();
        }

        private void btn_Update_Click(object sender, EventArgs e)
        {
            ActionUpdata();
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {   

        }

        private void btn_Find_Click(object sender, EventArgs e)
        {
            string rid = txt_Rid.Text.Trim();
            string rname = txt_RName.Text.Trim();
            string rUnit = txt_RSet.Text.Trim();
            string rsta = txt_RStan.Text.Trim();
            string rnum = txt_RNum.Text.Trim();
            string rPriceOne = txt_RPriceOne.Text.Trim();
            string rNote = txt_RNote.Text.Trim();

            string sql = String.Format("select * from Relish where cast([Id] as CHAR(50)) like '%{0}%' and [name] like '%{1}%' and [unit] like '%{2}%' and [standard] like '%{3}%' and cast([number] as CHAR(50)) like '%{4}%' and cast([priceone] as CHAR(50)) like '%{5}%' and [note] like '%{6}%';", rid, rname, rUnit, rsta, rnum, rPriceOne, rNote);

            ShowData(sql);
        }

        private void ShowData(string sql)
        {
            DataTable table = initTable();

            using (SQLiteDataReader reader = SqlHelper.ExecuteReader(sql))
            {
                while (reader.Read())
                {
                    DataRow dr = table.NewRow();
                    dr[0] = reader.GetInt32(0).ToString().Trim(); //ID
                    dr[1] = reader.GetString(1).Trim();  //name
                    dr[2] = reader.GetString(2).Trim(); //unit
                    dr[3] = reader.GetString(3).Trim(); // standard
                    dr[4] = reader.GetInt32(4).ToString(); // number
                    double priceOne = Convert.ToDouble(reader.GetValue(5).ToString());
                    dr[5] = Math.Round(priceOne, 2).ToString() + "元"; //price one
                    double priceAll = Convert.ToDouble(Convert.ToDouble(reader.GetValue(5).ToString())) * Convert.ToInt32(dr[4]);
                    dr[6] = Math.Round(priceAll, 2).ToString() + "元"; //priceall
                    dr[7] = reader.GetString(6).Trim();//note
                    table.Rows.Add(dr);
                }
            }
            dataGridView1.DataSource = table;
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow.Index < 0 )
            {
                return;
            }
            txt_Rid.Text = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value.ToString();
            txt_RName.Text = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[1].Value.ToString();
            txt_RSet.Text = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[2].Value.ToString();
            txt_RStan.Text = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[3].Value.ToString();
            txt_RNum.Text = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[4].Value.ToString();
            StringBuilder sb = new StringBuilder(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[5].Value.ToString());
            txt_RPriceOne.Text = sb.Remove(sb.Length - 1, 1).ToString();
            txt_RNote.Text = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[7].Value.ToString();
        }
    }
}
