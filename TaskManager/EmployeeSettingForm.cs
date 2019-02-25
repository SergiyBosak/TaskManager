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

namespace TaskManager
{
    public partial class EmployeeSettingForm : Form
    {
        DataSet ds;
        SqlDataAdapter adapter;
        string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=TaskManager;Integrated Security=True";

        public EmployeeSettingForm()
        {
            InitializeComponent();

            TableRefresh();

            dataGridViewEmployee.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewEmployee.AllowUserToAddRows = false;

            dataGridViewEmployee.Columns["Id"].Visible = false;

            dataGridViewEmployee.ReadOnly = true;

            dataGridViewEmployee.Columns.Add("Fill", "Fill");

            dataGridViewEmployee.ReadOnly = true;

            dataGridViewEmployee.Columns["Fill"].HeaderText = string.Empty;

            dataGridViewEmployee.Columns["Fill"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            dataGridViewEmployee.Columns["Fill"].SortMode = DataGridViewColumnSortMode.NotSortable;

            dataGridViewEmployee.Columns["Name"].HeaderText = "Работник";

            btnSave.Enabled = false;
        }

        public void TableRefresh()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                ds = new DataSet();

                adapter = new SqlDataAdapter(new SqlCommand("SELECT * FROM Employees WHERE Id > 1", connection));

                adapter.Fill(ds, "Employees");

                dataGridViewEmployee.DataSource = ds.Tables["Employees"];
            }
        }

        public void TableSave()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                adapter = new SqlDataAdapter("SELECT * FROM Employees", connection);

                var cmd = new SqlCommand("UPDATE [dbo].[Employees] " +
                                            "SET [Name] = @name " +                                                
                                            "WHERE Id = @id", connection);

                cmd.Parameters.Add(new SqlParameter("@id", SqlDbType.Int, 0, "Id"));
                cmd.Parameters.Add(new SqlParameter("@name", SqlDbType.VarChar, 50, "Name"));

                adapter.UpdateCommand = cmd;

                cmd = new SqlCommand("INSERT INTO Employees(Name) Values(@name)", connection);

                cmd.Parameters.Add(new SqlParameter("@name", SqlDbType.VarChar, 50, "Name"));

                adapter.InsertCommand = cmd;

                cmd = new SqlCommand("DELETE FROM [Employees] WHERE [Id] = @id", connection);

                cmd.Parameters.Add(new SqlParameter("@id", SqlDbType.Int, 0, "Id"));

                adapter.DeleteCommand = cmd;

                adapter.Update(ds.Tables["Employees"]);
            }

            TableRefresh();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            TableSave();

            btnSave.Enabled = false;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            dataGridViewEmployee.ReadOnly = false;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            TableRefresh();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridViewEmployee.SelectedRows)
            {
                List<object> employeeList = employeeInTasks();
 
                if (employeeList.Contains(row.Cells["Id"].Value))
                {
                    MessageBox.Show("Работника невозможно удалить, так как к нему прикрепленно задание", "Операцию невозможно выполнить", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    dataGridViewEmployee.Rows.Remove(row);
                }  
            }

            btnSave.Enabled = true;
        }

        private List<object> employeeInTasks()
        {
            List<object> employeeId = new List<object>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SELECT Employee FROM Tasks", connection);
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        object employee = reader.GetValue(0);
                        employeeId.Add(employee);
                    }
                }
                return employeeId;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (tBNewEmployee.Text == string.Empty)
            {
                MessageBox.Show("Введите имя нового работника", "Не заполнены данные", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
                
            TableRefresh();

            DataRow row = ds.Tables[0].NewRow();
            ds.Tables[0].Rows.Add(row);

            int rowIndex = ds.Tables[0].Rows.IndexOf(row);

            dataGridViewEmployee["Name", rowIndex].Value = tBNewEmployee.Text;

            tBNewEmployee.Clear();

            btnSave.Enabled = true;
        }

        private void EmployeeSettingForm_Load(object sender, EventArgs e)
        {
            new ToolTip().SetToolTip(btnUpdate, "Обновить данные");

            new ToolTip().SetToolTip(btnSave, "Сохранить изменения");

            new ToolTip().SetToolTip(btnDelete, "Удалить");

            new ToolTip().SetToolTip(btnAdd, "Добавить работника");
        }
    }
}
