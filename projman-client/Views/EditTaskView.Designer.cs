namespace projman_client
{
    partial class EditTaskView
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this._editButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.propertyGrid1 = new System.Windows.Forms.PropertyGrid();
            this._discardButton = new System.Windows.Forms.Button();
            this._saveButton = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 47.98995F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 52.01005F));
            this.tableLayoutPanel1.Controls.Add(this._editButton, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label1, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.propertyGrid1, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this._discardButton, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this._saveButton, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.button1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.button2, 1, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 17.26384F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15.63518F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 67.10098F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(398, 328);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // _editButton
            // 
            this._editButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this._editButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this._editButton.Location = new System.Drawing.Point(10, 10);
            this._editButton.Margin = new System.Windows.Forms.Padding(10);
            this._editButton.Name = "_editButton";
            this._editButton.Size = new System.Drawing.Size(170, 33);
            this._editButton.TabIndex = 0;
            this._editButton.Text = "Редактирование";
            this._editButton.UseVisualStyleBackColor = true;
            this._editButton.Click += new System.EventHandler(this._editButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Monotype Corsiva", 20.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(195, 5);
            this.label1.Margin = new System.Windows.Forms.Padding(5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(198, 43);
            this.label1.TabIndex = 1;
            this.label1.Text = "Имя задачи";
            // 
            // propertyGrid1
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.propertyGrid1, 2);
            this.propertyGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.propertyGrid1.Location = new System.Drawing.Point(3, 104);
            this.propertyGrid1.Name = "propertyGrid1";
            this.propertyGrid1.Size = new System.Drawing.Size(392, 200);
            this.propertyGrid1.TabIndex = 2;
            // 
            // _discardButton
            // 
            this._discardButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this._discardButton.Location = new System.Drawing.Point(200, 317);
            this._discardButton.Margin = new System.Windows.Forms.Padding(10);
            this._discardButton.Name = "_discardButton";
            this._discardButton.Size = new System.Drawing.Size(188, 1);
            this._discardButton.TabIndex = 3;
            this._discardButton.Text = "Отменить";
            this._discardButton.UseVisualStyleBackColor = true;
            this._discardButton.Click += new System.EventHandler(this._discardButton_Click);
            // 
            // _saveButton
            // 
            this._saveButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this._saveButton.Location = new System.Drawing.Point(10, 317);
            this._saveButton.Margin = new System.Windows.Forms.Padding(10);
            this._saveButton.Name = "_saveButton";
            this._saveButton.Size = new System.Drawing.Size(170, 1);
            this._saveButton.TabIndex = 4;
            this._saveButton.Text = "Сохранить";
            this._saveButton.UseVisualStyleBackColor = true;
            this._saveButton.Click += new System.EventHandler(this._saveButton_Click);
            // 
            // button1
            // 
            this.button1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button1.Location = new System.Drawing.Point(10, 63);
            this.button1.Margin = new System.Windows.Forms.Padding(10);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(170, 28);
            this.button1.TabIndex = 5;
            this.button1.Text = "Назначить задачу";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button2.Location = new System.Drawing.Point(200, 63);
            this.button2.Margin = new System.Windows.Forms.Padding(10);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(188, 28);
            this.button2.TabIndex = 6;
            this.button2.Text = "Закрыть задачу";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // EditTaskView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "EditTaskView";
            this.Size = new System.Drawing.Size(398, 328);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button _editButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PropertyGrid propertyGrid1;
        private System.Windows.Forms.Button _discardButton;
        private System.Windows.Forms.Button _saveButton;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}
