namespace TaskManager
{
    partial class CreateTaskForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CreateTaskForm));
            this.cBEmployee = new System.Windows.Forms.ComboBox();
            this.lEmployee = new System.Windows.Forms.Label();
            this.dTPGreateDate = new System.Windows.Forms.DateTimePicker();
            this.lGreateDate = new System.Windows.Forms.Label();
            this.cBDifficult = new System.Windows.Forms.ComboBox();
            this.lDifficult = new System.Windows.Forms.Label();
            this.lTitle = new System.Windows.Forms.Label();
            this.tBTitle = new System.Windows.Forms.TextBox();
            this.gBParam = new System.Windows.Forms.GroupBox();
            this.tBBody = new System.Windows.Forms.TextBox();
            this.lBody = new System.Windows.Forms.Label();
            this.lComment = new System.Windows.Forms.Label();
            this.tBComment = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.rBDevelop = new System.Windows.Forms.RadioButton();
            this.rBComplete = new System.Windows.Forms.RadioButton();
            this.gBIsComplete = new System.Windows.Forms.GroupBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.gBParam.SuspendLayout();
            this.gBIsComplete.SuspendLayout();
            this.SuspendLayout();
            // 
            // cBEmployee
            // 
            this.cBEmployee.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
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
            this.dTPGreateDate.Location = new System.Drawing.Point(7, 80);
            this.dTPGreateDate.Name = "dTPGreateDate";
            this.dTPGreateDate.Size = new System.Drawing.Size(137, 20);
            this.dTPGreateDate.TabIndex = 2;
            // 
            // lGreateDate
            // 
            this.lGreateDate.AutoSize = true;
            this.lGreateDate.Location = new System.Drawing.Point(12, 64);
            this.lGreateDate.Name = "lGreateDate";
            this.lGreateDate.Size = new System.Drawing.Size(33, 13);
            this.lGreateDate.TabIndex = 3;
            this.lGreateDate.Text = "Дата";
            // 
            // cBDifficult
            // 
            this.cBDifficult.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cBDifficult.FormattingEnabled = true;
            this.cBDifficult.Location = new System.Drawing.Point(7, 122);
            this.cBDifficult.Name = "cBDifficult";
            this.cBDifficult.Size = new System.Drawing.Size(137, 21);
            this.cBDifficult.TabIndex = 4;
            // 
            // lDifficult
            // 
            this.lDifficult.AutoSize = true;
            this.lDifficult.Location = new System.Drawing.Point(12, 106);
            this.lDifficult.Name = "lDifficult";
            this.lDifficult.Size = new System.Drawing.Size(63, 13);
            this.lDifficult.TabIndex = 5;
            this.lDifficult.Text = "Сложность";
            // 
            // lTitle
            // 
            this.lTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lTitle.AutoSize = true;
            this.lTitle.Location = new System.Drawing.Point(117, 16);
            this.lTitle.Name = "lTitle";
            this.lTitle.Size = new System.Drawing.Size(106, 13);
            this.lTitle.TabIndex = 0;
            this.lTitle.Text = "Заголовок задания";
            this.lTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // tBTitle
            // 
            this.tBTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tBTitle.Location = new System.Drawing.Point(13, 32);
            this.tBTitle.Name = "tBTitle";
            this.tBTitle.Size = new System.Drawing.Size(339, 20);
            this.tBTitle.TabIndex = 7;
            // 
            // gBParam
            // 
            this.gBParam.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.gBParam.Controls.Add(this.lEmployee);
            this.gBParam.Controls.Add(this.cBEmployee);
            this.gBParam.Controls.Add(this.dTPGreateDate);
            this.gBParam.Controls.Add(this.lDifficult);
            this.gBParam.Controls.Add(this.lGreateDate);
            this.gBParam.Controls.Add(this.cBDifficult);
            this.gBParam.Location = new System.Drawing.Point(369, 18);
            this.gBParam.Name = "gBParam";
            this.gBParam.Size = new System.Drawing.Size(151, 157);
            this.gBParam.TabIndex = 8;
            this.gBParam.TabStop = false;
            this.gBParam.Text = "Параметры";
            // 
            // tBBody
            // 
            this.tBBody.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tBBody.Location = new System.Drawing.Point(13, 72);
            this.tBBody.Multiline = true;
            this.tBBody.Name = "tBBody";
            this.tBBody.Size = new System.Drawing.Size(339, 180);
            this.tBBody.TabIndex = 9;
            // 
            // lBody
            // 
            this.lBody.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lBody.AutoSize = true;
            this.lBody.Location = new System.Drawing.Point(128, 56);
            this.lBody.Name = "lBody";
            this.lBody.Size = new System.Drawing.Size(82, 13);
            this.lBody.TabIndex = 4;
            this.lBody.Text = "Текст задания";
            this.lBody.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lComment
            // 
            this.lComment.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lComment.AutoSize = true;
            this.lComment.Location = new System.Drawing.Point(133, 255);
            this.lComment.Name = "lComment";
            this.lComment.Size = new System.Drawing.Size(77, 13);
            this.lComment.TabIndex = 11;
            this.lComment.Text = "Комментарии";
            this.lComment.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // tBComment
            // 
            this.tBComment.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tBComment.Location = new System.Drawing.Point(13, 271);
            this.tBComment.Multiline = true;
            this.tBComment.Name = "tBComment";
            this.tBComment.Size = new System.Drawing.Size(339, 47);
            this.tBComment.TabIndex = 12;
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(369, 251);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(151, 30);
            this.btnSave.TabIndex = 13;
            this.btnSave.Text = "Сохранить";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // rBDevelop
            // 
            this.rBDevelop.AutoSize = true;
            this.rBDevelop.Location = new System.Drawing.Point(6, 18);
            this.rBDevelop.Name = "rBDevelop";
            this.rBDevelop.Size = new System.Drawing.Size(94, 17);
            this.rBDevelop.TabIndex = 7;
            this.rBDevelop.TabStop = true;
            this.rBDevelop.Text = "В разработке";
            this.rBDevelop.UseVisualStyleBackColor = true;
            // 
            // rBComplete
            // 
            this.rBComplete.AutoSize = true;
            this.rBComplete.Location = new System.Drawing.Point(6, 38);
            this.rBComplete.Name = "rBComplete";
            this.rBComplete.Size = new System.Drawing.Size(82, 17);
            this.rBComplete.TabIndex = 8;
            this.rBComplete.TabStop = true;
            this.rBComplete.Text = "Завершено";
            this.rBComplete.UseVisualStyleBackColor = true;
            // 
            // gBIsComplete
            // 
            this.gBIsComplete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.gBIsComplete.Controls.Add(this.rBComplete);
            this.gBIsComplete.Controls.Add(this.rBDevelop);
            this.gBIsComplete.Location = new System.Drawing.Point(369, 181);
            this.gBIsComplete.Name = "gBIsComplete";
            this.gBIsComplete.Size = new System.Drawing.Size(151, 64);
            this.gBIsComplete.TabIndex = 14;
            this.gBIsComplete.TabStop = false;
            this.gBIsComplete.Text = "Статус выполнения";
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(369, 287);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(151, 30);
            this.btnClose.TabIndex = 15;
            this.btnClose.Text = "Отмена";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // CreateTaskForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(535, 326);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.gBIsComplete);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.tBComment);
            this.Controls.Add(this.lComment);
            this.Controls.Add(this.lBody);
            this.Controls.Add(this.tBBody);
            this.Controls.Add(this.gBParam);
            this.Controls.Add(this.tBTitle);
            this.Controls.Add(this.lTitle);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "CreateTaskForm";
            this.Text = "TaskManager";
            this.Load += new System.EventHandler(this.GreateTaskForm_Load);
            this.gBParam.ResumeLayout(false);
            this.gBParam.PerformLayout();
            this.gBIsComplete.ResumeLayout(false);
            this.gBIsComplete.PerformLayout();
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
        private System.Windows.Forms.TextBox tBTitle;
        private System.Windows.Forms.GroupBox gBParam;
        private System.Windows.Forms.TextBox tBBody;
        private System.Windows.Forms.Label lBody;
        private System.Windows.Forms.Label lComment;
        private System.Windows.Forms.TextBox tBComment;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.RadioButton rBDevelop;
        private System.Windows.Forms.RadioButton rBComplete;
        private System.Windows.Forms.GroupBox gBIsComplete;
        private System.Windows.Forms.Button btnClose;
    }
}

