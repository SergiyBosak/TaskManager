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
    public partial class CreateTaskForm : Form
    {
        public int EmploueeOld { get; set; }

        public struct Parameters
        {
            public int TaskId;
            public int EmployeeId;
            public bool IsComplete;
            public DateTime CreateDate;
            public int Difficult;
            public string Title;
            public string Body;
            public string Comment;

            public bool Validate()
            {
                string errors = null;
     
                if (Title == string.Empty)
                {
                    errors = "Введите заголовок задания \n";
                }
                if (Body == string.Empty)
                {
                    errors += "Введите текст задания \n";
                }
                if (EmployeeId < 2)
                {
                    errors += "Выберите работника \n";
                }
                if (Difficult < 1 || Difficult > 5)
                {
                    errors += "Выберите уровень сложности \n";
                }
                if (errors != null)
                {
                    MessageBox.Show(errors, "Не заполнены данные", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    return false;
                }
              
                return true;
            }
        }

        private int taskId;

        public bool EditMode;

        string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=TaskManager;Integrated Security=True";

        public CreateTaskForm()
        {
            InitializeComponent();

            initialize();
        }

        public void Fill(Parameters parameters)
        {           
            taskId = parameters.TaskId;
            cBEmployee.SelectedValue = parameters.EmployeeId;           
            dTPGreateDate.Value = parameters.CreateDate;           
            tBTitle.Text = parameters.Title;
            cBDifficult.SelectedIndex = parameters.Difficult;
            tBBody.Text = parameters.Body;
            tBComment.Text = parameters.Comment;

            if (parameters.IsComplete)
                rBComplete.Checked = true;
            else
                rBDevelop.Checked = true;            
        }

        public Parameters GetParameters()
        {
            Parameters parameters;
           
            parameters.TaskId = taskId;
            parameters.EmployeeId = (int)cBEmployee.SelectedValue;
            parameters.CreateDate = dTPGreateDate.Value;
            parameters.Title = tBTitle.Text;
            parameters.Difficult = cBDifficult.SelectedIndex;
            parameters.Body = tBBody.Text;
            parameters.Comment = tBComment.Text;

            if (rBComplete.Checked)
                parameters.IsComplete = true;
            else
                parameters.IsComplete = false;

            return parameters;
        }

        private void initialize()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                var adapter = new SqlDataAdapter("SELECT * FROM Employees", connection);

                var ds = new DataSet();

                adapter.Fill(ds, "Employees");

                cBEmployee.DataSource = ds.Tables["Employees"];
                
                cBEmployee.DisplayMember = "Name";
                cBEmployee.ValueMember = "Id";
            }

            cBDifficult.Items.AddRange(new string[] { "Не выбрано", "1", "2", "3", "4", "5" });

            cBDifficult.SelectedIndex = 0;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Parameters parameters = GetParameters();

            if (!parameters.Validate())
            {
                return;
            }

            if (this.EmploueeOld == parameters.EmployeeId)
            {
                MessageBox.Show("Задание для данного работника уже существует, выберете другого работника", "Не верно выбраны данные", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!EditMode)
            {
                this.DialogResult = DialogResult.No;                
            }
            else
            {               
                this.DialogResult = DialogResult.OK;

                Close();
            }           
        }

        private List<string> employeeList(string connectionString)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                List<string> nameList = new List<string>();
                connection.Open();
                SqlCommand command = new SqlCommand("sp_GetName", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    nameList.Add(reader.GetString(0));
                }

                return nameList;
            }
        }

        private void GreateTaskForm_Load(object sender, EventArgs e)
        {
            if (!EditMode)
            {
                rBDevelop.Checked = true;
                rBComplete.Enabled = false;
                rBDevelop.Enabled = false;
            }

            if (EditMode && rBComplete.Checked == true)
            {
                tBTitle.ReadOnly = true;
                tBBody.ReadOnly = true;
                dTPGreateDate.Enabled = false;
                rBComplete.Enabled = false;
                rBDevelop.Enabled = false;
                cBEmployee.Enabled = false;
                cBDifficult.Enabled = false;
                btnSave.Enabled = false;
            }

            if (EditMode)
            {
                cBEmployee.Enabled = false;
            }           
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }      
    }
}
