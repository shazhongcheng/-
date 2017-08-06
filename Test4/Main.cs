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
        List<MData> list = new List<MData>();

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
            int rid;
            int cid;
            string price = string.Empty;
            if (txt_RId.Text.Trim().Length == 0)
            {
                setRIdIsR(RID_IS_NULL, Color.Red);
                return;
            }
            else if (Int32.TryParse(txt_RId.Text.Trim(), out rid))
            {
                cid = Convert.ToInt32(txt_CId.Text);
                string sql1 = String.Format("select * from Part where [ClientId] = {0} and [RelishId] = {1};", cid, rid);

                using (SQLiteDataReader reader = SqlHelper.ExecuteReader(sql1))
                {
                    if (reader.Read())
                    {
                        price = reader.GetValue(2).ToString();
                    }
                }

                string sql = String.Format("select * from Relish where [Id] = {0};", rid);

                using (SQLiteDataReader reader = SqlHelper.ExecuteReader(sql))
                {
                    if (reader.Read())
                    {
                        //txt_RId.Text = reader.GetInt32(0).ToString().Trim(); //ID
                        txt_SName.Text = reader.GetString(1).Trim();  //name
                        txt_Sunit.Text = reader.GetString(2).Trim(); //unit
                        txt_Sstand.Text = reader.GetString(3).Trim(); // standard
                        txt_SAllNum.Text = reader.GetInt32(4).ToString(); // number
                        double priceOne = 0;
                        if (price!=string.Empty)
                            priceOne = Convert.ToDouble(price.ToString());
                        else
                            priceOne = Convert.ToDouble(reader.GetValue(5).ToString());
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
            txt_CId.Enabled = false;
            txt_CName.Enabled = false;
            txt_Ctel.Enabled = false;
            txt_Cadd.Enabled = false;
        }

        private void txt_SSellNum_TextChanged(object sender, EventArgs e)
        {
            SSellNumChange();
        }

        private void SSellNumChange()
        {
            string price = new StringBuilder(txt_SAllPrice.Text).Remove(txt_SAllPrice.Text.Length - 1, 1).ToString();
            int num;
            if (Int32.TryParse(txt_SSellNum.Text, out num))
            {
                txt_SAllMoney.Text = Math.Round(Convert.ToDouble(price) * num, 2).ToString() + "元";
            }
        }

        private void btn_Clear_Click(object sender, EventArgs e)
        {
            table = initTable();
            list = new List<MData>();
            dataGridView1.DataSource = table;
            btn_Confrim.Enabled = true;
            txt_CId.Enabled = true;
            txt_CName.Enabled = true;
            txt_Ctel.Enabled = true;
            txt_Cadd.Enabled = true;
            lbl_name.Text = "空";
            lbl_tel.Text = "空";
            lbl_add.Text = "空";
        }

        

        private void btn_Add_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确定添加？", "确认", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                ConIsChange();

                MData data = GetData();
                DataRow dr = table.NewRow();
                list.Add(data);
                AddToRow(dr, data);
                table.Rows.Add(dr);
                dataGridView1.DataSource = table;
            }   
        }
        /// <summary>
        /// 检查价格是否变化了
        /// </summary>
        private void ConIsChange()
        {
            int Cid = Convert.ToInt32(txt_CId.Text);
            int Rid = Convert.ToInt32(txt_RId.Text);
            string price = new StringBuilder(txt_SPriOne.Text).Remove(txt_SPriOne.Text.Length-1,1).ToString();
            string Sprice = null; ;
            bool flag = false; ;
            string sql = String.Format("select * from Relish where [Id] = {0};", Cid);

            using (SQLiteDataReader reader = SqlHelper.ExecuteReader(sql))
            {
                if (reader.Read())
                {
                    Sprice = reader.GetValue(5).ToString(); //price one

                }
            }

            if(!price.Equals(Sprice))
            {
                sql = String.Format("select * from Part where [ClientId] = {0} and [RelishId] = {1};", Cid, Rid);
                using (SQLiteDataReader reader = SqlHelper.ExecuteReader(sql))
                {
                    if (reader.Read())
                    {
                        Sprice = reader.GetValue(2).ToString();
                        flag = true;
                     }
                    else
                    {
                        if (MessageBox.Show("发现价格发生变化，是否设定本单价为客户特殊价格？", "确认", MessageBoxButtons.OKCancel) == DialogResult.OK)
                        {
                            sql = String.Format("insert into Part([ClientId],[RelishId],[priceone]) values({0},{1},{2})", Cid, Rid, price);
                            int n = SqlHelper.ExecuteNonQuery(sql);
                            {
                                if (n > 0)
                                {
                                    MessageBox.Show("修改成功！");
                                }
                            }
                            return;
                        }
                        
                    }
                }
            }

            if (!price.Equals(Sprice) && flag == true)
            {
                if (MessageBox.Show("发现价格发生变化，是否修改本单价为客户特殊价格？", "确认", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    sql = String.Format("update Part set [priceone]={2} where [ClientId]={0} and [RelishId]={1};", Cid, Rid, price);
                    int n = SqlHelper.ExecuteNonQuery(sql);
                    {
                        if (n > 0)
                        {
                            MessageBox.Show("修改成功！");
                        }
                    }
                }
            }

        }

        private MData GetData()
        {
            int id = Convert.ToInt32(txt_RId.Text);
            string name = txt_SName.Text;
            string unit = txt_Sunit.Text;
            string stand = txt_Sstand.Text;
            string sAllNum = txt_SAllNum.Text;
            string SellNum = txt_SSellNum.Text;
            string PriOne = txt_SPriOne.Text;
            string AllPrice = txt_SAllPrice.Text;
            string AllMoney = txt_SAllMoney.Text;
            string Note = txt_SNote.Text;

            return new MData(id,name, unit, stand, sAllNum, SellNum, PriOne, AllPrice, AllMoney, Note);  
        }

        /// <summary>
        /// 将左边的数据填充到row中
        /// </summary>
        /// <param name="dr"></param>
        private void AddToRow(DataRow dr, MData data)
        {
            dr[1] = data.Name;
            dr[2] = data.Unit;
            dr[3] = data.Stand;
            dr[4] = data.SellNum;
            dr[5] = data.PriOne;
            dr[6] = data.AllPrice;
            dr[7] = data.AllMoney;
            dr[8] = data.Name;
        }

        private void btn_Del_Click(object sender, EventArgs e)
        {
            DelData();

        }

        private void DelData()
        {
            if (dataGridView1.CurrentRow == null)
            {
                return;
            }

            if (dataGridView1.CurrentRow.Index < 0)
            {
                return;
            }
            int id = Convert.ToInt32(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value.ToString());

            list.RemoveAt(id - 1);

            AddListToTable();
        }

        private void AddListToTable()
        {
            table = initTable();
            foreach (var item in list)
            {
                DataRow dr = table.NewRow();
                AddToRow(dr, item);
                table.Rows.Add(dr);
            }
            dataGridView1.DataSource = table;
        }

        private void btn_Update_Click(object sender, EventArgs e)
        {
            UpdateDate();
        }

        private void UpdateDate()
        {
            if (dataGridView1.CurrentRow == null)
            {
                return;
            }

            if (dataGridView1.CurrentRow.Index < 0)
            {
                return;
            }
            int id = Convert.ToInt32(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value.ToString());

            list.RemoveAt(id - 1);
            list.Insert(id - 1, GetData());

            AddListToTable();
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow.Index < 0)
            {
                return;
            }
            int id = dataGridView1.CurrentRow.Index;

            MData md = list[id];

            ShowData(md);
    
        }

        private void ShowData(MData md)
        {
            txt_RId.Text = md.Id.ToString();
            txt_SName.Text = md.Name.ToString();
            txt_Sunit.Text = md.Unit.ToString();
            txt_Sstand.Text = md.Stand.ToString();
            txt_SAllNum.Text = md.SAllNum.ToString();
            txt_SSellNum.Text = md.SellNum.ToString();
            txt_SPriOne.Text = md.PriOne.ToString();
            txt_SAllPrice.Text = md.AllPrice.ToString();
            txt_SAllMoney.Text = md.AllMoney.ToString();
            txt_SNote.Text = md.Note.ToString();
        }

        private void 删除ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DelData();
        }

        private void 修改ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UpdateDate();
        }

        private void showPri_Click(object sender, EventArgs e)
        {
            new Par().Show();
        }

        private void txt_SPriOne_TextChanged(object sender, EventArgs e)
        {
            if (txt_SPriOne.Text == null)
            {
                return;
            }
            string pO=new StringBuilder(txt_SPriOne.Text).Remove(txt_SPriOne.Text.Length-1,1).ToString(), num = txt_SAllNum.Text;

            double priceOne = Convert.ToDouble(pO.ToString());
            double priceAll = Convert.ToDouble(priceOne) * Convert.ToInt32(num);
            txt_SAllPrice.Text = Math.Round(priceAll, 2).ToString() + "元"; //priceall

            SSellNumChange();
        }
    }
}
