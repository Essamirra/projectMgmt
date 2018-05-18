namespace projman_client
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
            this.stack_view = new projman_client.StackBaseView();
            this.SuspendLayout();
            // 
            // stack_view
            // 
            this.stack_view.Dock = System.Windows.Forms.DockStyle.Fill;
            this.stack_view.Location = new System.Drawing.Point(0, 0);
            this.stack_view.Name = "stack_view";
            this.stack_view.Size = new System.Drawing.Size(684, 361);
            this.stack_view.TabIndex = 0;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 361);
            this.Controls.Add(this.stack_view);
            this.MinimumSize = new System.Drawing.Size(700, 400);
            this.Name = "MainForm";
            this.Text = "Project Management";
            this.ResumeLayout(false);

        }

        #endregion

        private StackBaseView stack_view;
    }
}

