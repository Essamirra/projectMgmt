namespace projman_client
{
    partial class DashboardView
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
            this.users_button = new System.Windows.Forms.Button();
            this.projects_button = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // users_button
            // 
            this.users_button.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.users_button.Font = new System.Drawing.Font("Monotype Corsiva", 20.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.users_button.Location = new System.Drawing.Point(75, 210);
            this.users_button.Name = "users_button";
            this.users_button.Size = new System.Drawing.Size(250, 40);
            this.users_button.TabIndex = 1;
            this.users_button.Text = "Пользователи";
            this.users_button.UseVisualStyleBackColor = true;
            this.users_button.Click += new System.EventHandler(this.users_button_Click);
            // 
            // projects_button
            // 
            this.projects_button.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.projects_button.Font = new System.Drawing.Font("Monotype Corsiva", 20.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.projects_button.Location = new System.Drawing.Point(75, 150);
            this.projects_button.Name = "projects_button";
            this.projects_button.Size = new System.Drawing.Size(250, 40);
            this.projects_button.TabIndex = 0;
            this.projects_button.Text = "Проекты";
            this.projects_button.UseVisualStyleBackColor = true;
            this.projects_button.Click += new System.EventHandler(this.projects_button_Click);
            // 
            // DashboardView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.Controls.Add(this.users_button);
            this.Controls.Add(this.projects_button);
            this.Name = "DashboardView";
            this.Size = new System.Drawing.Size(400, 400);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button projects_button;
        private System.Windows.Forms.Button users_button;
    }
}
