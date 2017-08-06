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
    public partial class Form1 : Form
    {

        static string CID_IS_NULL = "客户编号为空！";
        static string RID_IS_NULL = "商品编号为空！";
        DataTable table;

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

            

            //lbl_date.Text = string.Format("{0}", DateTime.Now);
            lbl_date.Text = DateTime.Now.GetDateTimeFormats('D')[0].ToString();//2005年11月5日
            Initlbl();
            InitData();
        }

        private void InitData()
        {
            table = initTable();
            dataGridView1.DataSource = table;
        }

        private DataTable initTable()
        {
            DataTable table = new DataTable();

            DataColumn row = new DataColumn();
            row.DataType = System.Type.GetType("System.Int32");
            row.ColumnName = "ID";
            row.AutoIncrement = true;
            row.AutoIncrementSeed=1;
            table.Columns.Add(row);

            table.Columns.Add("品名", typeof(String));

            table.Columns.Add("单位", typeof(String));

            table.Columns.Add("规格", typeof(String));

            table.Columns.Add("数量", typeof(String));

            table.Columns.Add("单价(每袋)", typeof(String));

            table.Columns.Add("单价(每箱)", typeof(String));

            table.Columns.Add("金额", typeof(String));

            table.Columns.Add("备注", typeof(String));

            return table;
        }

        private void Initlbl()
        {
            lbl_name.Text = "空";
            lbl_tel.Text = "空";
            lbl_add.Text = "空";
            setCIdIsR(CID_IS_NULL, Color.Red);
            setRIdIsR(RID_IS_NULL, Color.Red);
            
        }



        private void btn_OpenC_Click(object sender, EventArgs e)
        {
            Client client = new Client();
            client.Show();
        }

        private void btn_OpenS_Click(object sender, EventArgs e)
        {
            Relish relish = new Relish();
            relish.Show();
        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void txt_CId_TextChanged(object sender, EventArgs e)
        {
            int id;
            if (txt_CId.Text.Trim().Length == 0)
            {
                setCIdIsR(CID_IS_NULL, Color.Red);
                return;
            }
            else if(Int32.TryParse(txt_CId.Text.Trim(),out id))
            {
                string sql = String.Format("select * from Client where [Id] = {0};", id);

                using (SQLiteDataReader reader = SqlHelper.ExecuteReader(sql))
                {
                    if(reader.Read())
                    {
                        txt_CId.Text = reader.GetInt32(0).ToString().Trim();
                        txt_CName.Text = reader.GetString(1).Trim();
                        txt_Ctel.Text = reader.GetString(2).Trim();
                        txt_Cadd.Text = reader.GetString(3).Trim();

                        setCIdIsR("客户编号正确！", Color.Green);
                    }
                    else
                    {
                        setCIdIsR("没有该客户编号！", Color.Red);
                    }
                }

            }
            else
            {
                setCIdIsR("客户编号格式不正确！", Color.Red);
            }
            
        }

        private void setCIdIsR(string s, Color c)
        {
            CidIsR.ForeColor = c;
            CidIsR.Text = s;
        }

        private void setRIdIsR(string s, Color c)
        {
            RidIsR.ForeColor = c;
            RidIsR.Text = s;
        }

        private void txt_RId_TextChanged(object sender, EventArgs e)
        {
            int id;
            if (txt_RId.Text.Trim().Length == 0)
            {
                setRIdIsR(RID_IS_NULL, Color.Red);
                return;
            }
            else if (Int32.TryParse(txt_RId.Text.Trim(), out id))
            {
                string sql = String.Format("select * from Relish where [Id] = {0};", id);

                using (SQLiteDataReader reader = SqlHelper.ExecuteReader(sql))
                {
                    if (reader.Read())
                    {
                        txt_RId.Text = reader.GetInt32(0).ToString().Trim(); //ID
                        txt_SName.Text = reader.GetString(1).Trim();  //name
                        txt_Sunit.Text = reader.GetString(2).Trim(); //unit
                        txt_Sstand.Text = reader.GetString(3).Trim(); // standard
                        txt_SAllNum.Text = reader.GetInt32(4).ToString(); // number
                        double priceOne = Convert.ToDouble(reader.GetValue(5).ToString());
                        txt_SPriOne.Text = Math.Round(priceOne, 2).ToString() + "元"; //price one
                        double priceAll = Convert.ToDouble(Convert.ToDouble(reader.GetValue(5).ToString())) * Convert.ToInt32(txt_SAllNum.Text);
                        txt_SAllPrice.Text = Math.Round(priceAll, 2).ToString() + "元"; //priceall
                        txt_SNote.Text = reader.GetString(6).Trim();//note

                        setRIdIsR("商品编号正确！", Color.Green);
                    }
                    else
                    {
                        setRIdIsR("没有该商品编号！", Color.Red);
                    }
                }

            }
            else
            {
                setRIdIsR("商品编号格式不正确！", Color.Red);
            }
        }

        private void btn_Confrim_Click(object sender, EventArgs e)
        {
            lbl_name.Text = txt_CName.Text;
            lbl_tel.Text = txt_Ctel.Text;
            lbl_add.Text = txt_Cadd.Text;

            btn_Confrim.Enabled = false;
        }

        private void txt_SSellNum_TextChanged(object sender, EventArgs e)
        {
            string price = new StringBuilder(txt_SAllPrice.Text).Remove(txt_SAllPrice.Text.Length - 1, 1).ToString();
            int num;
            if(Int32.TryParse(txt_SSellNum.Text,out num))
            {
                txt_SAllMoney.Text = Math.Round(Convert.ToDouble(price) * num,2).ToString()+"元";
            }
        }

        private void btn_Clear_Click(object sender, EventArgs e)
        {
            table = initTable();
            btn_Confrim.Enabled = true;
            lbl_name.Text = "空";
            lbl_tel.Text = "空";
            lbl_add.Text = "空";
        }

        private void btn_Add_Click(object sender, EventArgs e)
        {
            DataRow dr = table.NewRow();
            AddToRow(dr);
            table.Rows.Add(dr);
        }

        /// <summary>
        /// 将左边的数据填充到row中
        /// </summary>
        /// <param name="dr"></param>
        private void AddToRow(DataRow dr)
        {
            //throw new NotImplementedException();
        }

        private void btn_Del_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow.Index < 0)
            {
                return;
            }
            int id = Convert.ToInt32(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value.ToString());

            foreach (DataRow row in table.Rows)
            {
                if (Convert.ToInt32(row[0]) == id)
                {
                    row.Delete();
                    return;     
                }
            }

        }
    }
}
