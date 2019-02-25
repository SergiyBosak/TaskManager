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
    public partial class MainForm : Form
    {
        DataSet ds;
        SqlDataAdapter adapter, adapterTasks, adapterEmployees;
        string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=TaskManager;Integrated Security=True";

        bool dontToggleSaveButton;

        public MainForm()
        {
            InitializeComponent();

            TableRefresh();

            formSetting();
        }

        private void btnNewTask_Click(object sender, EventArgs e)
        {
            CreateTaskForm newGreateTaskForm = new CreateTaskForm();
                      
            CreateTaskForm.Parameters parameters;

            newGreateTaskForm.ShowDialog();

            parameters = newGreateTaskForm.GetParameters();

            if (newGreateTaskForm.DialogResult == DialogResult.No)
            {
                TableRefresh();

                DataRow row = ds.Tables[0].NewRow();
                ds.Tables[0].Rows.Add(row);

                int rowIndex = ds.Tables[0].Rows.IndexOf(row);

                dataGridView1["Id", rowIndex].Value = parameters.TaskId;
                dataGridView1["Employee", rowIndex].Value = parameters.EmployeeId;
                dataGridView1["IsComplete", rowIndex].Value = parameters.IsComplete;
                dataGridView1["CreateDate", rowIndex].Value = parameters.CreateDate;
                dataGridView1["Title", rowIndex].Value = parameters.Title;
                dataGridView1["Difficult", rowIndex].Value = parameters.Difficult;
                dataGridView1["Body", rowIndex].Value = parameters.Body;
                dataGridView1["Comment", rowIndex].Value = parameters.Comment;
            }
        }        

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            TableRefresh();
        }      

        public void TableRefresh()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                ds = new DataSet();

                adapterTasks = new SqlDataAdapter(new SqlCommand("SELECT * FROM Tasks", connection));

                adapterEmployees = new SqlDataAdapter(new SqlCommand("SELECT * FROM Employees", connection));

                adapterTasks.Fill(ds, "Tasks");

                adapterEmployees.Fill(ds, "Employees");
                
                ds.Relations.Add(new DataRelation("Relation", ds.Tables["Employees"].Columns["Id"], ds.Tables["Tasks"].Columns["Employee"]));

                dontToggleSaveButton = true;

                dataGridView1.DataSource = ds.Tables["Tasks"];

                var column = dataGridView1.Columns["Работник"] as DataGridViewComboBoxColumn;
                if (column != null)
                {
                    column.DataSource = ds.Tables["Employees"];
                }

                dontToggleSaveButton = false;
            }

            setButtonSaveState(false);
        }

        public void TableRefreshNewEmployees()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                ds = new DataSet();

                adapterTasks = new SqlDataAdapter(new SqlCommand("SELECT * FROM Tasks", connection));

                adapterEmployees = new SqlDataAdapter(new SqlCommand("SELECT * FROM Employees", connection));

                adapterTasks.Fill(ds, "Tasks");

                adapterEmployees.Fill(ds, "Employees");

                ds.Relations.Add(new DataRelation("Relation", ds.Tables["Employees"].Columns["Id"], ds.Tables["Tasks"].Columns["Employee"]));

                dontToggleSaveButton = true; 

                dataGridView1.DataSource = ds.Tables["Tasks"];

                var column = dataGridView1.Columns["Работник"] as DataGridViewComboBoxColumn;
                if (column != null)
                {
                    column.DataSource = ds.Tables["Employees"];
                }               
               
                dontToggleSaveButton = false;
            }

            setButtonSaveState(false);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {           
            foreach (DataGridViewRow row in dataGridView1.SelectedRows)
            {
                dataGridView1.Rows.Remove(row);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveData();
        }

        public void SaveData()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                adapter = new SqlDataAdapter("SELECT * FROM Tasks", connection);

                var cmd = new SqlCommand("UPDATE [dbo].[Tasks]" +
                                            "SET[Employee] = @employee" +
                                                ",[CreateDate] = @createDate" +
                                                ",[Title] = @title" +
                                                ",[Difficult] = @difficult" +
                                                ",[Body] = @body" +
                                                ",[IsComplete] = @isComplete" +
                                                ",[Comment] = @comment " +
                                            "WHERE Id = @id", connection);

                cmd.Parameters.Add(new SqlParameter("@id", SqlDbType.Int, 0, "Id"));
                cmd.Parameters.Add(new SqlParameter("@employee", SqlDbType.Int, 0, "Employee"));
                cmd.Parameters.Add(new SqlParameter("@createDate", SqlDbType.DateTime, 0, "CreateDate"));
                cmd.Parameters.Add(new SqlParameter("@title", SqlDbType.VarChar, 200, "Title"));
                cmd.Parameters.Add(new SqlParameter("@difficult", SqlDbType.Int, 0, "Difficult"));
                cmd.Parameters.Add(new SqlParameter("@body", SqlDbType.VarChar, 0, "Body"));
                cmd.Parameters.Add(new SqlParameter("@isComplete", SqlDbType.Bit, 0, "IsComplete"));
                cmd.Parameters.Add(new SqlParameter("@comment", SqlDbType.VarChar, 4000, "Comment"));

                adapter.UpdateCommand = cmd;

                cmd = new SqlCommand("sp_InsertTasks", connection);

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter("@employee", SqlDbType.Int, 0, "Employee"));
                cmd.Parameters.Add(new SqlParameter("@createDate", SqlDbType.DateTime, 0, "CreateDate"));
                cmd.Parameters.Add(new SqlParameter("@title", SqlDbType.VarChar, 200, "Title"));
                cmd.Parameters.Add(new SqlParameter("@difficult", SqlDbType.Int, 0, "Difficult"));
                cmd.Parameters.Add(new SqlParameter("@body", SqlDbType.VarChar, 0, "Body"));
                cmd.Parameters.Add(new SqlParameter("@isComplete", SqlDbType.Bit, 0, "IsComplete"));
                cmd.Parameters.Add(new SqlParameter("@comment", SqlDbType.VarChar, 4000, "Comment"));

                adapter.InsertCommand = cmd;

                cmd = new SqlCommand("DELETE FROM [Tasks] WHERE [Id] = @id", connection);

                cmd.Parameters.Add(new SqlParameter("@id", SqlDbType.Int, 0, "Id"));

                adapter.DeleteCommand = cmd;

                adapter.Update(ds.Tables["Tasks"]);

                btnSave.Enabled = false;
            }
        }        

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs elementClickData)
        {
            int rowIndex = elementClickData.RowIndex;

            if (rowIndex < 0)
            {
                return;
            }

            CreateTaskForm TaskFormInfo = new CreateTaskForm();

            CreateTaskForm.Parameters parameters;

            parameters.TaskId = (int)(long)dataGridView1["Id", rowIndex].Value;
            parameters.EmployeeId = (int)dataGridView1["Employee", rowIndex].Value;           
            parameters.IsComplete = (bool)dataGridView1["IsComplete", rowIndex].Value;
            parameters.CreateDate = (DateTime)dataGridView1["CreateDate", rowIndex].Value;
            parameters.Title = (string)dataGridView1["Title", rowIndex].Value;
            parameters.Difficult = (int)(decimal)dataGridView1["Difficult", rowIndex].Value;
            parameters.Body = (string)dataGridView1["Body", rowIndex].Value;
            parameters.Comment = (string)dataGridView1["Comment", rowIndex].Value;

            TaskFormInfo.EditMode = true;

            TaskFormInfo.Fill(parameters);

            TaskFormInfo.ShowDialog();

            if (TaskFormInfo.DialogResult == DialogResult.OK)
            {
                parameters = TaskFormInfo.GetParameters();

                dataGridView1["Id", rowIndex].Value = parameters.TaskId;
                dataGridView1["Employee", rowIndex].Value = parameters.EmployeeId;
                dataGridView1["IsComplete", rowIndex].Value = parameters.IsComplete;
                dataGridView1["CreateDate", rowIndex].Value = parameters.CreateDate;
                dataGridView1["Title", rowIndex].Value = parameters.Title;
                dataGridView1["Difficult", rowIndex].Value = parameters.Difficult;
                dataGridView1["Body", rowIndex].Value = parameters.Body;
                dataGridView1["Comment", rowIndex].Value = parameters.Comment;
            }
        }

        private void TaskFormInfo_FormClosed(object sender, FormClosedEventArgs e)
        {
            TableRefresh();
        }

        private void setButtonSaveState(bool state)
        {
            if (!dontToggleSaveButton)
            {
                btnSave.Enabled = state;
            }
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            setButtonSaveState(true);
        }

        private void dataGridView1_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            setButtonSaveState(true);
        }

        private void dataGridView1_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            setButtonSaveState(true);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            btnSave.Enabled = false;

            new ToolTip().SetToolTip(btnNewTask, "Создать задание");

            new ToolTip().SetToolTip(BtnUpdate, "Обновить данные");

            new ToolTip().SetToolTip(btnDelete, "Удалить задание");

            new ToolTip().SetToolTip(btnSave, "Сохранить изменения");

            new ToolTip().SetToolTip(btnCopy, "Создать копию");

            new ToolTip().SetToolTip(btnEmployeeSetting, "Редактор работников");
        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            CreateTaskForm TaskFormInfo = new CreateTaskForm();

            CreateTaskForm.Parameters parameters;

            foreach (DataGridViewRow rows in dataGridView1.SelectedRows)
            {
                int rowIndex = dataGridView1.Rows.IndexOf(rows);

                if (rowIndex < 0)
                {
                    return;
                }
                
                TaskFormInfo.EmploueeOld = (int)dataGridView1["Employee", rowIndex].Value;

                parameters.TaskId = (int)(long)dataGridView1["Id", rowIndex].Value;
                parameters.EmployeeId = 1;//(int)dataGridView1["Employee", rowIndex].Value;
                parameters.IsComplete = (bool)dataGridView1["IsComplete", rowIndex].Value;
                parameters.CreateDate = (DateTime)dataGridView1["CreateDate", rowIndex].Value;
                parameters.Title = (string)dataGridView1["Title", rowIndex].Value;
                parameters.Difficult = (int)(decimal)dataGridView1["Difficult", rowIndex].Value;
                parameters.Body = (string)dataGridView1["Body", rowIndex].Value;
                parameters.Comment = (string)dataGridView1["Comment", rowIndex].Value;

                TaskFormInfo.Fill(parameters);

                TaskFormInfo.ShowDialog();

                parameters = TaskFormInfo.GetParameters();

                if (TaskFormInfo.DialogResult == DialogResult.No)
                {
                    TableRefresh();

                    DataRow row = ds.Tables[0].NewRow();
                    ds.Tables[0].Rows.Add(row);

                    rowIndex = ds.Tables[0].Rows.IndexOf(row);

                    dataGridView1["Id", rowIndex].Value = parameters.TaskId;
                    dataGridView1["Employee", rowIndex].Value = parameters.EmployeeId;
                    dataGridView1["IsComplete", rowIndex].Value = parameters.IsComplete;
                    dataGridView1["CreateDate", rowIndex].Value = parameters.CreateDate;
                    dataGridView1["Title", rowIndex].Value = parameters.Title;
                    dataGridView1["Difficult", rowIndex].Value = parameters.Difficult;
                    dataGridView1["Body", rowIndex].Value = parameters.Body;
                    dataGridView1["Comment", rowIndex].Value = parameters.Comment;
                }
            }
        }

        private void btmEmployeeSetting_Click(object sender, EventArgs e)
        {
            EmployeeSettingForm employeeSettingForm = new EmployeeSettingForm();

            employeeSettingForm.ShowDialog();

            TableRefresh();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        public void formSetting()
        {
            dataGridView1.Columns["Id"].Visible = false;

            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.AllowUserToAddRows = false;

            DataGridViewComboBoxColumn column = new DataGridViewComboBoxColumn();

            dataGridView1.Columns["Employee"].Visible = false;
        
            column.Name = "Работник";

            column.DataSource = ds.Tables["Employees"];

            column.DisplayMember = "Name";
            column.ValueMember = "Id";

            column.DataPropertyName = "Employee";

            dataGridView1.Columns.Insert(0, column);

            //dataGridView1.Columns["Body"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView1.Columns["Body"].HeaderText = "Текст задания";
            dataGridView1.Columns["Body"].ReadOnly = true;
            dataGridView1.Columns["Body"].Width = 230;

            dataGridView1.Columns["Difficult"].HeaderText = "Сложность";
            dataGridView1.Columns["Difficult"].Width = 80;
            dataGridView1.Columns["Difficult"].ReadOnly = true;

            dataGridView1.Columns["IsComplete"].HeaderText = "Статус выполнения";
            dataGridView1.Columns["IsComplete"].Width = 80;

            //dataGridView1.Columns["Работник"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            //dataGridView1.Columns["CreateDate"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView1.Columns["CreateDate"].HeaderText = "Дата создания";
            dataGridView1.Columns["CreateDate"].ReadOnly = true;

            //dataGridView1.Columns["Title"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView1.Columns["Title"].HeaderText = "Заголовок задания";
            dataGridView1.Columns["Title"].ReadOnly = true;
            dataGridView1.Columns["Title"].Width = 120;

            //dataGridView1.Columns["Comment"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView1.Columns["Comment"].HeaderText = "Комментарии";
            dataGridView1.Columns["Comment"].Width = 120;

            dataGridView1.Columns["FillColumn"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            dataGridView1.Columns["FillColumn"].ReadOnly = true;

            //dataGridView1.Columns["FillColumn"].Visible = false;

            dataGridView1.Columns["FillColumn"].HeaderText = string.Empty;

            dataGridView1.Columns["FillColumn"].SortMode = DataGridViewColumnSortMode.NotSortable;

            dataGridView1.Columns[6].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dataGridView1.Columns[4].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dataGridView1.Columns[8].DefaultCellStyle.WrapMode = DataGridViewTriState.True;

            dataGridView1.ReadOnly = true;
        }
    }
}