using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MySql.Data.MySqlClient;
using System.Windows;

namespace Reception_Management_System
{
    class BL_AddNewReceptionist
    {

        //information
        private String name = "";
        private String gender = "";
        private String designation = "";
        private String address = "";
        private String email = "";
        private int contact_num = 0;
        private int salary = 0;

        //login
        private String username = "";
        private int employee_id = 0;
        private String password = "";


        public void setname(String inputName)
        {
            name = inputName;
        }

        public void setgender(String inputGender)
        {
            gender = inputGender;
        }

        public void setdesignation(String inputdesignation)
        {
            designation = inputdesignation;
        }

        public void setaddress(String inputaddress)
        {
            address = inputaddress;
        }

        public void setEmail(String inputEmail)
        {
            email = inputEmail;
        }

        public void setcontactnum(string inputcontactnum)
        {
            if(inputcontactnum.Equals(""))
            {
                contact_num = 0;
            }
            else
            {
                try
                {
                    contact_num = Int32.Parse(inputcontactnum);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, this.ToString() + " OnlyNumbersAreAllowed", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        public void setsalary(string inputsalary)
        {
            if(inputsalary.Equals(""))
            {
                salary = 0;
            }
            else
            {
                try
                {
                    salary = Int32.Parse(inputsalary);
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message, this.ToString() + " OnlyNumbersAreAllowed", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }



        public void setusername(String inputusername)
        {
            username = inputusername;
        }

        public void setpassword(String inputpassword)
        {
            password = inputpassword;
        }



        public bool emptyfields()
        {
            if (name.Equals("") || gender.Equals("") || address.Equals("") || email.Equals("") || contact_num.Equals(0) || salary.Equals(0) || username.Equals(""))

            {
                return true;
            }

            else
            {
                return false;
            }
        }



        public int InsertDataForEmployee()
        {
            DataAccessLayer.Instance.createDatabaseConnection();
            String query = "INSERT INTO employee (name, gender, designation, address, email_id, contact_number, salary) values ('" + name + "','" + gender + "','" + designation + "','" + address + "','" + email + "','" + contact_num + "','" + salary + "');";

            try
            {
                using (MySqlCommand mySqlCommand = new MySqlCommand(query, DataAccessLayer.Instance.Connection))
                {

                    return mySqlCommand.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, this.ToString() + " InsertDataForEmployee Exception", MessageBoxButton.OK, MessageBoxImage.Error);
                return 0;
            }
        }



        public int InsertDataForLogin()
        {
            DataAccessLayer.Instance.createDatabaseConnection();
            String query = "INSERT INTO login (username, employee_id, password) values ('" + username + "', '" + employee_id + "','" + password + "');";
            try
            {
                using (MySqlCommand mySqlCommand = new MySqlCommand(query, DataAccessLayer.Instance.Connection))
                {
                    return mySqlCommand.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, this.ToString() + " InsertDataForLogin Exception" + employee_id, MessageBoxButton.OK, MessageBoxImage.Error);
                return 0;
            }
        }



        public int FetchEmployeeID()
        {
            DataAccessLayer.Instance.createDatabaseConnection();
            String query = "SELECT id FROM employee WHERE email_id='" + email + "';";

            try
            {
                using (MySqlCommand mySqlCommand = new MySqlCommand(query, DataAccessLayer.Instance.Connection))
                {
                    MySqlDataReader reader = mySqlCommand.ExecuteReader();

                    if(reader.Read())
                    {
                        string empID = reader.GetString(0);
                        employee_id = Int32.Parse(empID);
                    }
                    return 1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, this.ToString() + " FetchEmployeeID Exception" + employee_id, MessageBoxButton.OK, MessageBoxImage.Error);
                return 0;
            }
        }


    }
}
