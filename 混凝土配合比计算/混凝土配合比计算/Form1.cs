using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace 混凝土配合比计算
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection myconn = new SqlConnection(@"Data Source=LAPTOP-N4PSASL1\SQLEXPRESS;Initial Catalog=混凝土配合比计算;Integrated Security=True");
        public static string qd,cok,cek,stk,mik,mia,env,dhz,tld,std,jsl,ced,shad,shid,mid;//用户输入、选择的参数
        public static double sjb, bzsjb;

        public static string i;//用来记录计算的时间
        private void button3_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
            panel2.Visible = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            panel2.Visible = false;
            panel1.Visible = true;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            comboBox5.Items.Clear();
            panel2.Visible = false;
            panel3.Visible = true;
            if (radioButton1.Checked == true)
            {
                stk = radioButton1.Text;
            }
            if (radioButton2.Checked == true)
            {
                stk = radioButton2.Text;
            }
            if (radioButton3.Checked == true)
            {
                textBox11.Text = radioButton3.Text;
            }
            if (radioButton4.Checked == true)
            {
                textBox11.Text = radioButton4.Text;
            }
            SqlCommand cmd_load5 = new SqlCommand("select 石的最大粒径 from 混凝土砂率选用表 where 石的种类='" + stk + "' group by 石的最大粒径", myconn);
            myconn.Open();
            {
                SqlDataReader myreader5 = cmd_load5.ExecuteReader();
                if (myreader5.HasRows)
                    while (myreader5.Read())
                    {
                        comboBox5.Items.Add(myreader5["石的最大粒径"].ToString());
                    }
            }
            myconn.Close();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            panel3.Visible = false;
            panel2.Visible = true;
        }


        private void button15_Click(object sender, EventArgs e)
        {
            panel4.Visible = false;
            panel3.Visible = true;
        }

        private void button12_Click(object sender, EventArgs e)
        {
            panel4.Visible = false;
            panel5.Visible = true;
            textBox18.Text = "水泥：" + textBox9.Text + "kg\r\n" + textBox11.Text + "：" + textBox10.Text + "kg\r\n水：" + textBox8.Text + "kg\r\n砂：" + textBox16.Text + "kg\r\n石：" + textBox17.Text+"kg";
        }

        private void button16_Click(object sender, EventArgs e)
        {
            panel5.Visible = false;
            panel4.Visible = true;
        }

        private void button17_Click(object sender, EventArgs e)
        {
            i=DateTime.Now.ToString();
            string str1 = "insert into 结果储存 values('"+i+"','"+ qd + "','" + cok + "','" + cek + "','" + env + "','" + mik + "','" + mia + "','" + dhz + "','" + tld + "','" + std + "','" + stk + "','" + bzsjb + "','" + ced + "','" + shad + "','" + shid + "','" + mid + "','" + jsl + "','" + textBox16.Text + "','" + textBox17.Text + "','" + textBox10.Text + "','" + textBox9.Text + "','" + textBox8.Text+"')";
            SqlCommand mycmd1 = new SqlCommand(str1, myconn);
            myconn.Open();
            {
                try
                {
                    mycmd1.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }

            }
            myconn.Close();
            MessageBox.Show("更新成功，请在历史记录中查看数据");

            textBox1.Clear(); textBox2.Clear(); textBox5.Clear();
            textBox7.Clear(); textBox8.Clear(); textBox9.Clear(); textBox10.Clear(); textBox11.Clear(); textBox12.Clear();
            textBox13.Clear(); textBox14.Clear(); textBox15.Clear(); textBox16.Clear(); textBox17.Clear();
            radioButton1.Checked = false; radioButton2.Checked = false; radioButton3.Checked = false; radioButton4.Checked = false;
            radioButton5.Checked = false; radioButton6.Checked = false; radioButton7.Checked = false; radioButton8.Checked = false;
            comboBox1.Text = ""; comboBox2.Text = ""; comboBox3.Text = ""; comboBox4.Text = ""; comboBox5.Text = "";

            panel5.Visible = false;
            panel1.Visible = true;
            string str = "TRUNCATE TABLE 砂石质量表 TRUNCATE TABLE 计算水胶比表 TRUNCATE TABLE 配置强度表 TRUNCATE TABLE 水的质量表 TRUNCATE TABLE 胶凝材料质量表";
            SqlCommand mycmd = new SqlCommand(str, myconn);
            myconn.Open();
            {
                try
                {
                    mycmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
            myconn.Close();
            string st = "select * from 结果储存";

            SqlDataAdapter myadapter = new SqlDataAdapter(st, myconn);
            DataSet mydataset = new DataSet();
            myadapter.Fill(mydataset, "历史记录");
            dataGridView1.DataSource = mydataset.Tables["历史记录"];
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Clear(); textBox2.Clear();
        }

        private void radioButton8_CheckedChanged(object sender, EventArgs e)
        {
            button7.Enabled = false;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            radioButton1.Checked = false; radioButton2.Checked = false; radioButton3.Checked = false; radioButton4.Checked = false; radioButton5.Checked = false; radioButton6.Checked = false; radioButton7.Checked = false; radioButton8.Checked = false;
            textBox5.Clear();
            comboBox1.Text = ""; comboBox2.Text = ""; comboBox3.Text = "";
            comboBox4.Text = ""; comboBox5.Text = "";
        }

        private void button8_Click_1(object sender, EventArgs e)
        {
            panel3.Visible = false;
            panel4.Visible = true;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            textBox7.Clear(); textBox8.Clear(); textBox9.Clear(); textBox10.Clear(); textBox11.Clear();
            comboBox4.Text = ""; comboBox5.Text = "";
        }

        private void button13_Click(object sender, EventArgs e)
        {
            textBox12.Clear(); textBox13.Clear(); textBox14.Clear(); textBox15.Clear(); textBox16.Clear(); textBox17.Clear();
        }

        private void tabPage4_Click(object sender, EventArgs e)
        {

        }

        private void 放弃当前计算ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.Clear(); textBox2.Clear(); textBox5.Clear();
            textBox7.Clear(); textBox8.Clear(); textBox9.Clear(); textBox10.Clear(); textBox11.Clear(); textBox12.Clear();
            textBox13.Clear(); textBox14.Clear(); textBox15.Clear(); textBox16.Clear(); textBox17.Clear();
            radioButton1.Checked = false; radioButton2.Checked = false; radioButton3.Checked = false; radioButton4.Checked = false;
            radioButton5.Checked = false; radioButton6.Checked = false; radioButton7.Checked = false; radioButton8.Checked = false;
            comboBox1.Text = ""; comboBox2.Text = ""; comboBox3.Text = ""; comboBox4.Text = ""; comboBox5.Text = "";
            string str = "TRUNCATE TABLE 砂石质量表 TRUNCATE TABLE 计算水胶比表 TRUNCATE TABLE 配置强度表 TRUNCATE TABLE 水的质量表 TRUNCATE TABLE 胶凝材料质量表";
            SqlCommand mycmd = new SqlCommand(str, myconn);
            myconn.Open();
            {
                try
                {
                    mycmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
            myconn.Close();
            panel1.Visible = true; panel2.Visible = false; panel3.Visible = false; panel4.Visible = false; panel5.Visible = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string str = "select * from 结果储存";

            SqlDataAdapter myadapter = new SqlDataAdapter(str, myconn);
            DataSet mydataset = new DataSet();
            myadapter.Fill(mydataset, "历史记录");
            dataGridView1.DataSource = mydataset.Tables["历史记录"];
            SqlCommand cmd_load1 = new SqlCommand("select 掺合料掺量 from 粉煤灰和矿渣粉影响系数取值 group by 掺合料掺量", myconn);
            SqlCommand cmd_load2 = new SqlCommand("select 环境条件 from 混凝土最大水胶比和最小胶凝材料用量限值 group by 环境条件", myconn);
            SqlCommand cmd_load3 = new SqlCommand("select 水泥强度等缓值 from 水泥强度等级富余系数", myconn);
            SqlCommand cmd_load4 = new SqlCommand("select 坍落度范围 from 混凝土单位用水量选用表 group by 坍落度范围", myconn);

            myconn.Open();
            {
                SqlDataReader myreader1 = cmd_load1.ExecuteReader();
                if (myreader1.HasRows)
                    while (myreader1.Read())
                    {
                        comboBox3.Items.Add(myreader1["掺合料掺量"].ToString());
                    }

            }
            myconn.Close();
            myconn.Open();
            {
                SqlDataReader myreader2 = cmd_load2.ExecuteReader();
                if (myreader2.HasRows)
                    while (myreader2.Read())
                    {
                        comboBox1.Items.Add(myreader2["环境条件"].ToString());
                    }

            }
            myconn.Close();
            myconn.Open();
            {
                SqlDataReader myreader3 = cmd_load3.ExecuteReader();
                if (myreader3.HasRows)
                    while (myreader3.Read())
                    {
                        comboBox2.Items.Add(myreader3["水泥强度等缓值"].ToString());
                    }

            }
            myconn.Close();
            myconn.Open();
            {
                SqlDataReader myreader4 = cmd_load4.ExecuteReader();
                if (myreader4.HasRows)
                    while (myreader4.Read())
                    {
                        comboBox4.Items.Add(myreader4["坍落度范围"].ToString());
                    }

            }
            myconn.Close();
        }//combobox加载

        private void label41_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(@"https://tieba.baidu.com/f?ie=utf-8&kw=%E6%B7%B7%E5%87%9D%E5%9C%9F%E9%85%8D%E5%90%88%E6%AF%94%E8%AE%A1%E7%AE%97%E5%8F%8D%E9%A6%88&fr=search");
        }//意见反馈链接

        private void label41_MouseHover(object sender, EventArgs e)
        {
            Font s = new Font(label41.Font.FontFamily, this.label41.Font.Size, FontStyle.Underline);
            this.label41.Font = s;
        }

        private void label41_MouseLeave(object sender, EventArgs e)
        {
            Font s = new Font(this.label41.Font.FontFamily, this.label41.Font.Size, FontStyle.Regular);
            this.label41.Font = s;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim() == "")
            {
                MessageBox.Show("未完整填写");
                return;
            }
            string str1 = "TRUNCATE TABLE 配置强度表";
            SqlCommand mycmd1 = new SqlCommand(str1, myconn);
            myconn.Open();
            {
                try
                {
                    mycmd1.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            myconn.Close();
            qd = textBox1.Text;
            string str2 = "insert into 配置强度表 values('" + textBox1.Text + "',null)";
            SqlCommand mycmd2 = new SqlCommand(str2, myconn);
            myconn.Open();
            {
                try
                {
                    mycmd2.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            myconn.Close();
            string str3 = "update 配置强度表 set 配置强度=(select dbo.计算配置强度(混凝土强度等级)) ";
            SqlCommand mycmd3 = new SqlCommand(str3, myconn);
            myconn.Open();
            {
                try
                {
                    mycmd3.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            myconn.Close();
            string str4 = "select 配置强度 from 配置强度表 where 混凝土强度等级=" + qd;
            SqlCommand mycmd4 = new SqlCommand(str4, myconn);
            myconn.Open();
            {
                SqlDataReader myreader4 = mycmd4.ExecuteReader();
                if (myreader4.HasRows)
                    if (myreader4.Read())
                    {
                        textBox2.Text = (myreader4["配置强度"].ToString());
                    }
            }
            myconn.Close();
            button3.Enabled = true;
        }//第一步计算！！！！！！！！！！！！
        private void button5_Click(object sender, EventArgs e)
        {
            if ((radioButton1.Checked == false && radioButton2.Checked == false) || (radioButton7.Checked == false && radioButton8.Checked == false) || (radioButton5.Checked == false && radioButton6.Checked == false) || (radioButton3.Checked == false && radioButton4.Checked == false))
            {
                MessageBox.Show("未完整填写");
                return;
            }
            if ((comboBox1.Text.Trim() == "" || comboBox2.Text.Trim() == "" || comboBox3.Text.Trim() == ""))
            {
                MessageBox.Show("未完整填写");
                return;
            }
            string str1 = "TRUNCATE TABLE 计算水胶比表";
            SqlCommand mycmd1 = new SqlCommand(str1, myconn);
            myconn.Open();
            {
                try
                {
                    mycmd1.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            myconn.Close();
            if (radioButton8.Checked == true) //混凝土种类
            {
                cok = radioButton8.Text;
            }
            if (radioButton7.Checked == true)
            {
                cok = radioButton7.Text;
            }
            if (radioButton5.Checked == true)//水泥种类
            {
                cek = radioButton5.Text;
            }
            if (radioButton6.Checked == true)
            {
                cek = radioButton6.Text;
            }
    
            if (radioButton1.Checked == true)//石的种类
            {
                stk = radioButton1.Text;
            }
            if (radioButton2.Checked == true)
            {
                stk = radioButton2.Text;
            }
            if (radioButton3.Checked == true)//矿物掺合料种类
            {
                mik = radioButton3.Text;
            }
            if (radioButton4.Checked == true)
            {
                mik = radioButton4.Text;
            }
            mia=comboBox3.Text;env=comboBox1.Text;dhz=comboBox2.Text;
            string str2 = "insert into 计算水胶比表 values('" + qd + "','" + stk + "','" + mik + "','" + mia + "','" + cok + "','" + cek + "','" + env + "','" + dhz + "',null)";
            SqlCommand mycmd2 = new SqlCommand(str2, myconn);
            myconn.Open();
            {
                try
                {
                    mycmd2.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
               
            }
            myconn.Close();
            string str3 = "update 计算水胶比表 set 计算水胶比=(select dbo.确定水胶比()) ";
            SqlCommand mycmd3 = new SqlCommand(str3, myconn);
            myconn.Open();
            {
                try
                {
                    mycmd3.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            myconn.Close();
            string str4 = "select 计算水胶比 from 计算水胶比表 where 混凝土强度等级=" + qd;
            SqlCommand mycmd4 = new SqlCommand(str4, myconn);
            myconn.Open();
            {
                SqlDataReader myreader4 = mycmd4.ExecuteReader();
                if (myreader4.HasRows)
                    if (myreader4.Read())
                    {
                        textBox5.Text = (myreader4["计算水胶比"].ToString());
                    }
            }
            myconn.Close();
            sjb = Convert.ToSingle(textBox5.Text);
            bzsjb = Math.Round(sjb, 1);
            button7.Enabled = true;
        }//第二步计算！！！！！！！！！！！！！！！！！

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            button3.Enabled = false;
        }

        private void radioButton7_CheckedChanged(object sender, EventArgs e)
        {
            button7.Enabled = false;
        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            button7.Enabled = false;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            button7.Enabled = false;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            button7.Enabled = false;
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            button7.Enabled = false;
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            button7.Enabled = false;
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            button7.Enabled = false;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            button7.Enabled = false;
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            button7.Enabled = false;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (textBox7.Text.Trim() == "" || comboBox4.Text.Trim() == "" || comboBox5.Text.Trim() == "")
            {
                MessageBox.Show("未完整填写");
                return;
            }
            string str1 = "TRUNCATE TABLE 水的质量表";
            SqlCommand mycmd1 = new SqlCommand(str1, myconn);
            myconn.Open();
            {
                try
                {
                    mycmd1.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            myconn.Close();
            string str2 = "TRUNCATE TABLE 胶凝材料质量表";
            SqlCommand mycmd2 = new SqlCommand(str2, myconn);
            myconn.Open();
            {
                try
                {
                    mycmd2.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            myconn.Close();
            tld = comboBox4.Text;
            std = comboBox5.Text;
            jsl = textBox7.Text;
            string str3 = "insert into 水的质量表 values('" + tld + "','" + stk + "','" + std + "','" + jsl + "',null)";
            //MessageBox.Show(str3);
            SqlCommand mycmd3 = new SqlCommand(str3, myconn);
            myconn.Open();
            {
                try
                {
                    mycmd3.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                   
                }
            }
            myconn.Close();
            string str4 = "insert into 胶凝材料质量表 values('" + qd + "','" + cok + "','" + cek + "','" + env + "','" + mik + "','" + mia + "','" + dhz + "','" + tld + "','" + stk + "','" + std + "','" + jsl + "',null,null)";
            //MessageBox.Show(str4);
            SqlCommand mycmd4 = new SqlCommand(str4, myconn);
            myconn.Open();
            {
                try
                {
                    mycmd4.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            myconn.Close();
            string str5 = "declare @水的质量_out int exec 单位用水量 @水的质量_out out update 水的质量表 set 水的质量=@水的质量_out";
            SqlCommand mycmd5 = new SqlCommand(str5, myconn);
            myconn.Open();
            {
                try
                {
                    mycmd5.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            myconn.Close();
            string str6 = "select 水的质量 from 水的质量表 where 坍落度范围='" + tld+"'";
            //MessageBox.Show(str6);
            SqlCommand mycmd6 = new SqlCommand(str6, myconn);
            myconn.Open();
            {
                SqlDataReader myreader6 = mycmd6.ExecuteReader();
                if (myreader6.HasRows)
                    if (myreader6.Read())
                    {
                        textBox8.Text = (myreader6["水的质量"].ToString());
                    }
            }
            myconn.Close();
            button8.Enabled = true;
            string str7 = "declare @水泥质量_out int,@矿物掺合料质量_out int exec 单位胶凝材料用量 @水泥质量_out out,@矿物掺合料质量_out out update 胶凝材料质量表 set 水泥质量=@水泥质量_out,掺合料质量=@矿物掺合料质量_out";
            SqlCommand mycmd7 = new SqlCommand(str7, myconn);
            myconn.Open();
            {
                try
                {
                    mycmd7.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            myconn.Close();
            string str8 = "select 水泥质量,掺合料质量 from 胶凝材料质量表 where 混凝土强度等级=" + qd;
            SqlCommand mycmd8 = new SqlCommand(str8, myconn);
            myconn.Open();
            {
                SqlDataReader myreader8 = mycmd8.ExecuteReader();
                if (myreader8.HasRows)
                    if (myreader8.Read())
                    {
                        textBox9.Text = (myreader8["水泥质量"].ToString());
                        textBox10.Text = (myreader8["掺合料质量"].ToString());
                    }
            }
            myconn.Close();
        }//第三步计算

        private void button14_Click(object sender, EventArgs e)//第四步计算（未完成)
        {
            if (textBox12.Text.Trim() == "" || textBox13.Text.Trim() == "" || textBox14.Text.Trim() == "" || textBox15.Text.Trim() == "")
            {
                MessageBox.Show("未完整填写");
                return;
            }
            ced = textBox12.Text;//水泥密度
            shad = textBox13.Text;//砂的密度
            shid = textBox14.Text;//石的密度
            mid = textBox15.Text;//矿物掺合料密度
            string str1 = "TRUNCATE TABLE 砂石质量表";
            SqlCommand mycmd1 = new SqlCommand(str1, myconn);//清空表
            myconn.Open();
            {
                try
                {
                    mycmd1.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            myconn.Close();
            string str2 = "insert into 砂石质量表 values('" + qd + "','" + cok + "','" + cek + "','" + env + "','" + mik + "','" + mia + "','" + dhz + "','" + tld + "','" + std + "','" + stk + "','" + bzsjb + "','" + ced + "','" + shad + "','" + shid + "','" + mid + "','" + jsl + "',null,null)";
            SqlCommand mycmd2 = new SqlCommand(str2, myconn);//insert进去
            myconn.Open();
            {
                try
                {
                    mycmd2.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            myconn.Close();
            string str3 = "declare @砂的质量_out int,@石的质量_out int exec 砂石质量 @砂的质量_out out,@石的质量_out out update 砂石质量表 set 砂的质量=@砂的质量_out,石的质量=@石的质量_out";
            SqlCommand mycmd3 = new SqlCommand(str3, myconn);
            myconn.Open();
            {
                try
                {
                    mycmd3.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            myconn.Close();
            string str4 = "select 砂的质量,石的质量 from 砂石质量表 where 混凝土强度等级=" + qd;
            //MessageBox.Show(str4);
            SqlCommand mycmd4 = new SqlCommand(str4, myconn);
            myconn.Open();
            {
                SqlDataReader myreader4 = mycmd4.ExecuteReader();
                if (myreader4.HasRows)
                    if (myreader4.Read())
                    {
                        textBox16.Text = (myreader4["砂的质量"].ToString());
                        textBox17.Text = (myreader4["石的质量"].ToString());
                    }
            }
            myconn.Close();
            button12.Enabled = true;
        }

        private void textBox12_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != 8 && !Char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            } 
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != 8 && !Char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            } 
        }

        private void textBox12_TextChanged(object sender, EventArgs e)
        {
            button12.Enabled = false;
        }

        private void textBox7_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != 8 && !Char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            } 
        }

        private void textBox7_TextChanged_1(object sender, EventArgs e)
        {
            button8.Enabled = false;
        }

        private void textBox13_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != 8 && !Char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            } 
        }

        private void textBox14_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != 8 && !Char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            } 
        }

        private void textBox15_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != 8 && !Char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            } 
        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            button8.Enabled = false;
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            button8.Enabled = false;
        }

        private void textBox13_TextChanged(object sender, EventArgs e)
        {
            button12.Enabled = false;
        }

        private void textBox14_TextChanged(object sender, EventArgs e)
        {
            button12.Enabled = false;
        }

        private void textBox15_TextChanged(object sender, EventArgs e)
        {
            button12.Enabled = false;
        }

        private void button19_Click(object sender, EventArgs e)
        {
            string str = "TRUNCATE TABLE 结果储存";
            SqlCommand mycmd = new SqlCommand(str, myconn);
            myconn.Open();
            {
                try
                {
                    mycmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
            myconn.Close();
            string st = "select * from 结果储存";

            SqlDataAdapter myadapter = new SqlDataAdapter(st, myconn);
            DataSet mydataset = new DataSet();
            myadapter.Fill(mydataset, "历史记录");
            dataGridView1.DataSource = mydataset.Tables["历史记录"];
            
        }

        private void button18_Click(object sender, EventArgs e)
        {
            openFileDialog1.Multiselect = true;
            openFileDialog1.Title = "请选择文件夹";
            openFileDialog1.Filter = "所有文件(*.*)|*.*";
            string file;
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            {
                file = openFileDialog1.FileName.ToString();
                //MessageBox.Show(file);
                richTextBox1.LoadFile(file, RichTextBoxStreamType.PlainText);
            }
        }

        private void button20_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Title = "选择目录和输入文件名";
            saveFileDialog1.Filter = "所有文件(*.*)|*.*";
            string file;

            if (saveFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;

            file = saveFileDialog1.FileName.ToString();
            richTextBox1.SaveFile(file, RichTextBoxStreamType.PlainText); 
        }

        public static int pos = 0;
        private void button21_Click(object sender, EventArgs e)
        {
            string txt = textBox3.Text;
            pos = richTextBox1.Text.IndexOf(txt, pos);
            if (pos >= 0 && pos < richTextBox1.Text.Length)
            {
                richTextBox1.SelectionStart = pos;
                richTextBox1.SelectionLength = txt.Length;
                richTextBox1.Select();
                pos = pos + txt.Length;
            }
            else
            {
                MessageBox.Show("已到达文件尾");
            }
        }

        

       
           
        }

        }
    


       
    
            