namespace projman_client
{
    partial class EditUserView
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
            this.property_grid = new System.Windows.Forms.PropertyGrid();
            this._saveButton = new System.Windows.Forms.Button();
            this._cancelButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.property_grid, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this._saveButton, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this._cancelButton, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(398, 328);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // property_grid
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.property_grid, 2);
            this.property_grid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.property_grid.HelpVisible = false;
            this.property_grid.Location = new System.Drawing.Point(3, 53);
            this.property_grid.Name = "property_grid";
            this.property_grid.PropertySort = System.Windows.Forms.PropertySort.NoSort;
            this.property_grid.SelectedItemWithFocusBackColor = System.Drawing.SystemColors.Control;
            this.property_grid.SelectedItemWithFocusForeColor = System.Drawing.SystemColors.ControlText;
            this.property_grid.Size = new System.Drawing.Size(392, 222);
            this.property_grid.TabIndex = 4;
            this.property_grid.ToolbarVisible = false;
            // 
            // _saveButton
            // 
            this._saveButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this._saveButton.Location = new System.Drawing.Point(3, 281);
            this._saveButton.Name = "_saveButton";
            this._saveButton.Size = new System.Drawing.Size(193, 44);
            this._saveButton.TabIndex = 0;
            this._saveButton.Text = "Сохранить";
            this._saveButton.UseVisualStyleBackColor = true;
            this._saveButton.Click += new System.EventHandler(this._saveButton_Click);
            // 
            // _cancelButton
            // 
            this._cancelButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this._cancelButton.Location = new System.Drawing.Point(202, 281);
            this._cancelButton.Name = "_cancelButton";
            this._cancelButton.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._cancelButton.Size = new System.Drawing.Size(193, 44);
            this._cancelButton.TabIndex = 1;
            this._cancelButton.Text = "Отменить";
            this._cancelButton.UseVisualStyleBackColor = true;
            this._cancelButton.Click += new System.EventHandler(this._cancelButton_Click);
            // 
            // label1
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.label1, 2);
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Monotype Corsiva", 20.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(392, 50);
            this.label1.TabIndex = 3;
            this.label1.Text = "Редактирование пользователя\r\n";
            // 
            // EditUserView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "EditUserView";
            this.Size = new System.Drawing.Size(398, 328);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button _saveButton;
        private System.Windows.Forms.Button _cancelButton;
        private System.Windows.Forms.PropertyGrid property_grid;
        private System.Windows.Forms.Label label1;
    }
}
