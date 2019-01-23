namespace TaskManager
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.cBEmployee = new System.Windows.Forms.ComboBox();
            this.lEmployee = new System.Windows.Forms.Label();
            this.dTPGreateDate = new System.Windows.Forms.DateTimePicker();
            this.lGreateDate = new System.Windows.Forms.Label();
            this.cBDifficult = new System.Windows.Forms.ComboBox();
            this.lDifficult = new System.Windows.Forms.Label();
            this.lTitle = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.gBParam = new System.Windows.Forms.GroupBox();
            this.tBBody = new System.Windows.Forms.TextBox();
            this.lBody = new System.Windows.Forms.Label();
            this.lComment = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.gBParam.SuspendLayout();
            this.SuspendLayout();
            // 
            // cBEmployee
            // 
            this.cBEmployee.FormattingEnabled = true;
            this.cBEmployee.Location = new System.Drawing.Point(7, 39);
            this.cBEmployee.Name = "cBEmployee";
            this.cBEmployee.Size = new System.Drawing.Size(137, 21);
            this.cBEmployee.TabIndex = 0;
            // 
            // lEmployee
            // 
            this.lEmployee.AutoSize = true;
            this.lEmployee.Location = new System.Drawing.Point(12, 23);
            this.lEmployee.Name = "lEmployee";
            this.lEmployee.Size = new System.Drawing.Size(107, 13);
            this.lEmployee.TabIndex = 1;
            this.lEmployee.Text = "Выбрать работника";
            // 
            // dTPGreateDate
            // 
            this.dTPGreateDate.Location = new System.Drawing.Point(7, 84);
            this.dTPGreateDate.Name = "dTPGreateDate";
            this.dTPGreateDate.Size = new System.Drawing.Size(137, 20);
            this.dTPGreateDate.TabIndex = 2;
            // 
            // lGreateDate
            // 
            this.lGreateDate.AutoSize = true;
            this.lGreateDate.Location = new System.Drawing.Point(12, 68);
            this.lGreateDate.Name = "lGreateDate";
            this.lGreateDate.Size = new System.Drawing.Size(33, 13);
            this.lGreateDate.TabIndex = 3;
            this.lGreateDate.Text = "Дата";
            // 
            // cBDifficult
            // 
            this.cBDifficult.FormattingEnabled = true;
            this.cBDifficult.Location = new System.Drawing.Point(7, 131);
            this.cBDifficult.Name = "cBDifficult";
            this.cBDifficult.Size = new System.Drawing.Size(137, 21);
            this.cBDifficult.TabIndex = 4;
            // 
            // lDifficult
            // 
            this.lDifficult.AutoSize = true;
            this.lDifficult.Location = new System.Drawing.Point(12, 115);
            this.lDifficult.Name = "lDifficult";
            this.lDifficult.Size = new System.Drawing.Size(63, 13);
            this.lDifficult.TabIndex = 5;
            this.lDifficult.Text = "Сложность";
            // 
            // lTitle
            // 
            this.lTitle.AutoSize = true;
            this.lTitle.Location = new System.Drawing.Point(116, 16);
            this.lTitle.Name = "lTitle";
            this.lTitle.Size = new System.Drawing.Size(106, 13);
            this.lTitle.TabIndex = 6;
            this.lTitle.Text = "Заголовок задания";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(13, 32);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(325, 20);
            this.textBox1.TabIndex = 7;
            // 
            // gBParam
            // 
            this.gBParam.Controls.Add(this.lEmployee);
            this.gBParam.Controls.Add(this.cBEmployee);
            this.gBParam.Controls.Add(this.dTPGreateDate);
            this.gBParam.Controls.Add(this.lDifficult);
            this.gBParam.Controls.Add(this.lGreateDate);
            this.gBParam.Controls.Add(this.cBDifficult);
            this.gBParam.Location = new System.Drawing.Point(355, 18);
            this.gBParam.Name = "gBParam";
            this.gBParam.Size = new System.Drawing.Size(151, 162);
            this.gBParam.TabIndex = 8;
            this.gBParam.TabStop = false;
            this.gBParam.Text = "Параметры";
            // 
            // tBBody
            // 
            this.tBBody.Location = new System.Drawing.Point(13, 71);
            this.tBBody.Multiline = true;
            this.tBBody.Name = "tBBody";
            this.tBBody.Size = new System.Drawing.Size(325, 104);
            this.tBBody.TabIndex = 9;
            // 
            // lBody
            // 
            this.lBody.AutoSize = true;
            this.lBody.Location = new System.Drawing.Point(128, 55);
            this.lBody.Name = "lBody";
            this.lBody.Size = new System.Drawing.Size(82, 13);
            this.lBody.TabIndex = 10;
            this.lBody.Text = "Текст задания";
            // 
            // lComment
            // 
            this.lComment.AutoSize = true;
            this.lComment.Location = new System.Drawing.Point(133, 181);
            this.lComment.Name = "lComment";
            this.lComment.Size = new System.Drawing.Size(77, 13);
            this.lComment.TabIndex = 11;
            this.lComment.Text = "Комментарии";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(13, 197);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(325, 56);
            this.textBox2.TabIndex = 12;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(355, 197);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(151, 22);
            this.btnSave.TabIndex = 13;
            this.btnSave.Text = "Сохранить";
            this.btnSave.UseVisualStyleBackColor = true;
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(355, 228);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(151, 23);
            this.btnClear.TabIndex = 14;
            this.btnClear.Text = "Очистить всё";
            this.btnClear.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(514, 269);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.lComment);
            this.Controls.Add(this.lBody);
            this.Controls.Add(this.tBBody);
            this.Controls.Add(this.gBParam);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.lTitle);
            this.Name = "MainForm";
            this.Text = "TaskManager";
            this.gBParam.ResumeLayout(false);
            this.gBParam.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cBEmployee;
        private System.Windows.Forms.Label lEmployee;
        private System.Windows.Forms.DateTimePicker dTPGreateDate;
        private System.Windows.Forms.Label lGreateDate;
        private System.Windows.Forms.ComboBox cBDifficult;
        private System.Windows.Forms.Label lDifficult;
        private System.Windows.Forms.Label lTitle;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.GroupBox gBParam;
        private System.Windows.Forms.TextBox tBBody;
        private System.Windows.Forms.Label lBody;
        private System.Windows.Forms.Label lComment;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClear;
    }
}

