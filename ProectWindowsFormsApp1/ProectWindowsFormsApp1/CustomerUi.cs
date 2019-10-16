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
using ProectWindowsFormsApp1.BLL;
using ProectWindowsFormsApp1.Model;
using ProectWindowsFormsApp1.Repository;

namespace ProectWindowsFormsApp1
{
    public partial class CustomerUi : Form
    {
        public CustomerUi()
        {
            InitializeComponent();
        }
        Customers customer = new Customers();
        CustomerManager _customerManager = new CustomerManager();
       

        //private int selectedID;




        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                
                    if (String.IsNullOrEmpty(customerCodeTextBox.Text))
                    {
                    MessageBox.Show("Please enter Code");
                        return;
                    }
                   

                    if (customerCodeTextBox.TextLength != 4)
                    {
                    MessageBox.Show(" Code Must be 4 Char");
                    return;
                    }
                   

                    if (!_customerManager.IsCodeUniqe(customerCodeTextBox.Text))
                    {
                    MessageBox.Show("Code Already Exist"); 
                        return;
                    }
                    

                    if (String.IsNullOrEmpty(customerNameTextBox.Text))
                    {
                    MessageBox.Show(" Please Enter a Name"); 
                        return;
                    }
                  

                    if (String.IsNullOrEmpty(customerContactTextBox.Text))
                    {
                    MessageBox.Show("Please Enter a Valid Mobile Number");
                        return;
                    }                               
                   

                    if (customerContactTextBox.TextLength != 11)
                    {
                    MessageBox.Show( "Enter Mobile No 11 digit");
                        return;
                    }
                   

                    if (!_customerManager.IsContactUniqe(customerContactTextBox.Text))
                    {
                         MessageBox.Show("Contact Number Already Exist");
                        return;
                    }

                if (String.IsNullOrEmpty(customerAddressTextBox.Text))
                {
                    MessageBox.Show("Please enter your Address");
                    return;
                }
                if (String.IsNullOrEmpty(customerEmailTextBox.Text))
                {
                    MessageBox.Show("Please enter your Email");
                    return;
                }

                Customers customer = new Customers();

                    //customer.ID = selectedID;
                    customer.Code = customerCodeTextBox.Text;
                    customer.Name = customerNameTextBox.Text;
                    customer.Contact = customerContactTextBox.Text;
                    customer.Address = customerAddressTextBox.Text;
                    customer.Email = customerEmailTextBox.Text;
                    customer.LoyaltyP = Convert.ToInt32(loyaltyPointTextBox.Text);

                    if (_customerManager.AddCustomer(customer))
                    {
                        MessageBox.Show("Data Saved Successfully..!!");
                    showDataGridView.DataSource = _customerManager.Display();
                }
                    else
                    {
                        MessageBox.Show("Not Saved..!!");
                    }
                                                                                                                        
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }




      
        private void showDataGridView_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            this.showDataGridView.Rows[e.RowIndex].Cells["SNo"].Value = (e.RowIndex+1).ToString();
        }

        private void Customer_Load_1(object sender, EventArgs e)
        {
            showDataGridView.DataSource = _customerManager.Display();
        }

        private void loyaltyPointTextBox_TextChanged(object sender, EventArgs e)
        {
            //int LoyaltyP = 0;
            //int  a = Convert.ToInt32(customerCodeTextBox.Text);
            //loyaltyPointTextBox.Text = (_customerManager.GetLoyaltiPointById()).ToString();


        }
    }
}
