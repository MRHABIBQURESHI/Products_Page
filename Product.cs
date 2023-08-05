using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;

namespace PetShop
{
    public partial class Products : Form
    {
        public Products()
        {
            InitializeComponent();
            DisplayProducts();

        }
        SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-1D77MCM;Initial Catalog=PetShopDb;Persist Security Info=True;User ID=sa;Password=123");
        private void DisplayProducts()
        {
            try
            {
                conn.Open();
                string SelectSqlQuery = "select * from ProductsTbl";
                SqlDataAdapter Sda = new SqlDataAdapter(SelectSqlQuery, conn);
                SqlCommandBuilder CmdBuilder = new SqlCommandBuilder(Sda);
                var Ds = new DataSet();
                Sda.Fill(Ds);
                ProGV.DataSource = Ds.Tables[0];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }

        }
        private void ClearTb()
        {
            ProNameTb.Text = "";
            ProQuabtityTb.Text = "";
            ProPriceTb.Text = "";
            ProCategorieTb.Text = "";

        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {
            Employees EmpObj = new Employees();
            EmpObj.Show();
            this.Hide();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void bunifuThinButton23_Click(object sender, EventArgs e)
        {
            if (ProNameTb.Text == "" || ProQuabtityTb.Text == "" || ProPriceTb.Text == "" || ProCategorieTb.Text == "")
            {
                MessageBox.Show("Misssing Information");
            }
            else
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("insert into ProductsTbl(product_name,product_quntity,product_price,product_cat) values(@PN,@PQ,@PP,@PC)", conn);
                    cmd.Parameters.AddWithValue("@PN", ProNameTb.Text);
                    cmd.Parameters.AddWithValue("@PQ", ProQuabtityTb.Text);
                    cmd.Parameters.AddWithValue("@PP", ProPriceTb.Text);
                    cmd.Parameters.AddWithValue("@PC", ProCategorieTb.Text);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Empolyee Added");
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
                finally
                {
                    conn.Close();

                    DisplayProducts();

                    ClearTb();
                }

            }

        }

 

    private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            if (ProNameTb.Text == "" || ProQuabtityTb.Text == "" || ProPriceTb.Text == "")
            {
                MessageBox.Show("Misssing Information");
            }
            else
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("update ProductsTbl set product_name = @PN,product_quntity = @PQ,product_price = @PP ,product_cat = @PC where Product_id = @PKey", conn);
                    cmd.Parameters.AddWithValue("@PN", ProNameTb.Text);
                    cmd.Parameters.AddWithValue("@PQ", ProQuabtityTb.Text);
                    cmd.Parameters.AddWithValue("@PP", ProPriceTb.Text);
                    cmd.Parameters.AddWithValue("@PC", ProCategorieTb.Text);
                    cmd.Parameters.AddWithValue("@PKey", key);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Employee updated Successfully where id = " + key.ToString());
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
                finally
                {
                    conn.Close();
                    DisplayProducts();
                    ClearTb();
                }

            }
        }


        int key = 0;
    private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            ProNameTb.Text = ProGV.SelectedRows[0].Cells[1].Value.ToString();
            ProQuabtityTb.Text = ProGV.SelectedRows[0].Cells[2].Value.ToString();
            ProPriceTb.Text = ProGV.SelectedRows[0].Cells[3].Value.ToString();
            ProCategorieTb.Text = ProGV.SelectedRows[0].Cells[4].Value.ToString();
            if (ProNameTb.Text != "")
            {
                key = Convert.ToInt32(ProGV.SelectedRows[0].Cells[0].Value.ToString());
                // MessageBox.Show("Employee EmpNum " + key.ToString() + " Selected");
            }
            else
            {
                key = 0;
            }



        }

        private void ProDeleteTb_Click(object sender, EventArgs e)
        {
            if (key == 0)
            {
                MessageBox.Show("Select An Customer");
            }
            else
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("delete from Products Tbl where product_id = @Pkey", conn);
                    cmd.Parameters.AddWithValue("@Pkey", key);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Products Deleted!!!");
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
                finally
                {
                    conn.Close();
                    DisplayProducts();
                    ClearTb();
                }
            }
        }
    }

    }


