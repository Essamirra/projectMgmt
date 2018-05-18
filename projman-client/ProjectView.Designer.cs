namespace projman_client
{
    partial class ProjectView
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

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label_name = new System.Windows.Forms.Label();
            this.label_title_description = new System.Windows.Forms.Label();
            this.label_description = new System.Windows.Forms.Label();
            this.label_title_start_date = new System.Windows.Forms.Label();
            this.label_title_end_date = new System.Windows.Forms.Label();
            this.label_start_date = new System.Windows.Forms.Label();
            this.label_end_date = new System.Windows.Forms.Label();
            this.tasks_list = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.title = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.createdDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.startDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.assignedDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.closeDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.duration = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.projectId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.createdByUserId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.assigneeUserId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label_tasks = new System.Windows.Forms.Label();
            this.edit_project_button = new System.Windows.Forms.Button();
            this.add_task_button = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.tasks_list)).BeginInit();
            this.SuspendLayout();
            // 
            // label_name
            // 
            this.label_name.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label_name.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_name.Location = new System.Drawing.Point(3, 0);
            this.label_name.Name = "label_name";
            this.label_name.Size = new System.Drawing.Size(594, 39);
            this.label_name.TabIndex = 0;
            this.label_name.Text = "Title";
            this.label_name.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_title_description
            // 
            this.label_title_description.AutoSize = true;
            this.label_title_description.Location = new System.Drawing.Point(44, 53);
            this.label_title_description.Name = "label_title_description";
            this.label_title_description.Size = new System.Drawing.Size(60, 13);
            this.label_title_description.TabIndex = 1;
            this.label_title_description.Text = "Описание:";
            // 
            // label_description
            // 
            this.label_description.AutoSize = true;
            this.label_description.Location = new System.Drawing.Point(110, 53);
            this.label_description.Name = "label_description";
            this.label_description.Size = new System.Drawing.Size(24, 13);
            this.label_description.TabIndex = 2;
            this.label_description.Text = "text";
            // 
            // label_title_start_date
            // 
            this.label_title_start_date.AutoSize = true;
            this.label_title_start_date.Location = new System.Drawing.Point(23, 75);
            this.label_title_start_date.Name = "label_title_start_date";
            this.label_title_start_date.Size = new System.Drawing.Size(81, 13);
            this.label_title_start_date.TabIndex = 3;
            this.label_title_start_date.Text = "Время начала:";
            // 
            // label_title_end_date
            // 
            this.label_title_end_date.AutoSize = true;
            this.label_title_end_date.Location = new System.Drawing.Point(28, 98);
            this.label_title_end_date.Name = "label_title_end_date";
            this.label_title_end_date.Size = new System.Drawing.Size(76, 13);
            this.label_title_end_date.TabIndex = 4;
            this.label_title_end_date.Text = "Время конца:";
            // 
            // label_start_date
            // 
            this.label_start_date.AutoSize = true;
            this.label_start_date.Location = new System.Drawing.Point(110, 75);
            this.label_start_date.Name = "label_start_date";
            this.label_start_date.Size = new System.Drawing.Size(24, 13);
            this.label_start_date.TabIndex = 5;
            this.label_start_date.Text = "text";
            // 
            // label_end_date
            // 
            this.label_end_date.AutoSize = true;
            this.label_end_date.Location = new System.Drawing.Point(110, 98);
            this.label_end_date.Name = "label_end_date";
            this.label_end_date.Size = new System.Drawing.Size(24, 13);
            this.label_end_date.TabIndex = 6;
            this.label_end_date.Text = "text";
            // 
            // tasks_list
            // 
            this.tasks_list.AllowUserToAddRows = false;
            this.tasks_list.AllowUserToDeleteRows = false;
            this.tasks_list.AllowUserToResizeColumns = false;
            this.tasks_list.AllowUserToResizeRows = false;
            this.tasks_list.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tasks_list.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.tasks_list.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.tasks_list.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tasks_list.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.title,
            this.description,
            this.createdDate,
            this.startDate,
            this.assignedDate,
            this.closeDate,
            this.duration,
            this.projectId,
            this.createdByUserId,
            this.assigneeUserId,
            this.status});
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.tasks_list.DefaultCellStyle = dataGridViewCellStyle6;
            this.tasks_list.Location = new System.Drawing.Point(0, 158);
            this.tasks_list.Margin = new System.Windows.Forms.Padding(3, 10, 3, 3);
            this.tasks_list.MultiSelect = false;
            this.tasks_list.Name = "tasks_list";
            this.tasks_list.ReadOnly = true;
            this.tasks_list.RowHeadersVisible = false;
            this.tasks_list.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.tasks_list.Size = new System.Drawing.Size(600, 242);
            this.tasks_list.TabIndex = 7;
            this.tasks_list.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.tasks_list_CellClick);
            this.tasks_list.SelectionChanged += new System.EventHandler(this.tasks_list_SelectionChanged);
            // 
            // id
            // 
            this.id.DataPropertyName = "id";
            this.id.HeaderText = "Id";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            // 
            // title
            // 
            this.title.DataPropertyName = "title";
            this.title.HeaderText = "Имя";
            this.title.Name = "title";
            this.title.ReadOnly = true;
            // 
            // description
            // 
            this.description.DataPropertyName = "description";
            this.description.HeaderText = "Описание";
            this.description.Name = "description";
            this.description.ReadOnly = true;
            // 
            // createdDate
            // 
            this.createdDate.DataPropertyName = "createdDate";
            this.createdDate.HeaderText = "Создана";
            this.createdDate.Name = "createdDate";
            this.createdDate.ReadOnly = true;
            // 
            // startDate
            // 
            this.startDate.DataPropertyName = "startDate";
            this.startDate.HeaderText = "Старт";
            this.startDate.Name = "startDate";
            this.startDate.ReadOnly = true;
            // 
            // assignedDate
            // 
            this.assignedDate.DataPropertyName = "assignedDate";
            this.assignedDate.HeaderText = "Принята";
            this.assignedDate.Name = "assignedDate";
            this.assignedDate.ReadOnly = true;
            // 
            // closeDate
            // 
            this.closeDate.DataPropertyName = "closeDate";
            this.closeDate.HeaderText = "Закрыта";
            this.closeDate.Name = "closeDate";
            this.closeDate.ReadOnly = true;
            // 
            // duration
            // 
            this.duration.DataPropertyName = "duration";
            this.duration.HeaderText = "Продолжительность";
            this.duration.Name = "duration";
            this.duration.ReadOnly = true;
            // 
            // projectId
            // 
            this.projectId.DataPropertyName = "projectId";
            this.projectId.HeaderText = "Id проекта";
            this.projectId.Name = "projectId";
            this.projectId.ReadOnly = true;
            // 
            // createdByUserId
            // 
            this.createdByUserId.DataPropertyName = "createdByUserId";
            this.createdByUserId.HeaderText = "Создатель";
            this.createdByUserId.Name = "createdByUserId";
            this.createdByUserId.ReadOnly = true;
            // 
            // assigneeUserId
            // 
            this.assigneeUserId.DataPropertyName = "assigneeUserId";
            this.assigneeUserId.HeaderText = "Приниматель";
            this.assigneeUserId.Name = "assigneeUserId";
            this.assigneeUserId.ReadOnly = true;
            // 
            // status
            // 
            this.status.DataPropertyName = "status";
            this.status.HeaderText = "Статус";
            this.status.Name = "status";
            this.status.ReadOnly = true;
            // 
            // label_tasks
            // 
            this.label_tasks.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label_tasks.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_tasks.Location = new System.Drawing.Point(143, 128);
            this.label_tasks.Name = "label_tasks";
            this.label_tasks.Size = new System.Drawing.Size(454, 23);
            this.label_tasks.TabIndex = 8;
            this.label_tasks.Text = "Список задач";
            this.label_tasks.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // edit_project_button
            // 
            this.edit_project_button.Location = new System.Drawing.Point(29, 11);
            this.edit_project_button.Name = "edit_project_button";
            this.edit_project_button.Size = new System.Drawing.Size(108, 23);
            this.edit_project_button.TabIndex = 9;
            this.edit_project_button.Text = "Редактировать";
            this.edit_project_button.UseVisualStyleBackColor = true;
            this.edit_project_button.Click += new System.EventHandler(this.edit_project_button_Click);
            // 
            // add_task_button
            // 
            this.add_task_button.Location = new System.Drawing.Point(29, 129);
            this.add_task_button.Name = "add_task_button";
            this.add_task_button.Size = new System.Drawing.Size(108, 23);
            this.add_task_button.TabIndex = 10;
            this.add_task_button.Text = "Добавить задачу";
            this.add_task_button.UseVisualStyleBackColor = true;
            this.add_task_button.Click += new System.EventHandler(this.add_task_button_Click);
            // 
            // ProjectView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.add_task_button);
            this.Controls.Add(this.edit_project_button);
            this.Controls.Add(this.label_tasks);
            this.Controls.Add(this.tasks_list);
            this.Controls.Add(this.label_end_date);
            this.Controls.Add(this.label_start_date);
            this.Controls.Add(this.label_title_end_date);
            this.Controls.Add(this.label_title_start_date);
            this.Controls.Add(this.label_description);
            this.Controls.Add(this.label_title_description);
            this.Controls.Add(this.label_name);
            this.Name = "ProjectView";
            this.Size = new System.Drawing.Size(600, 400);
            ((System.ComponentModel.ISupportInitialize)(this.tasks_list)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_name;
        private System.Windows.Forms.Label label_title_description;
        private System.Windows.Forms.Label label_description;
        private System.Windows.Forms.Label label_title_start_date;
        private System.Windows.Forms.Label label_title_end_date;
        private System.Windows.Forms.Label label_start_date;
        private System.Windows.Forms.Label label_end_date;
        private System.Windows.Forms.DataGridView tasks_list;
        private System.Windows.Forms.Label label_tasks;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn title;
        private System.Windows.Forms.DataGridViewTextBoxColumn description;
        private System.Windows.Forms.DataGridViewTextBoxColumn createdDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn startDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn assignedDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn closeDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn duration;
        private System.Windows.Forms.DataGridViewTextBoxColumn projectId;
        private System.Windows.Forms.DataGridViewTextBoxColumn createdByUserId;
        private System.Windows.Forms.DataGridViewTextBoxColumn assigneeUserId;
        private System.Windows.Forms.DataGridViewTextBoxColumn status;
        private System.Windows.Forms.Button edit_project_button;
        private System.Windows.Forms.Button add_task_button;
    }
}
