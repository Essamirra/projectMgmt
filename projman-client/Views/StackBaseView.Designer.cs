namespace projman_client
{
    partial class StackBaseView
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
            this.content_panel = new System.Windows.Forms.Panel();
            this.back_button = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // content_panel
            // 
            this.content_panel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.content_panel.Location = new System.Drawing.Point(3, 3);
            this.content_panel.Name = "content_panel";
            this.content_panel.Size = new System.Drawing.Size(594, 365);
            this.content_panel.TabIndex = 0;
            // 
            // back_button
            // 
            this.back_button.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.back_button.Location = new System.Drawing.Point(260, 374);
            this.back_button.Name = "back_button";
            this.back_button.Size = new System.Drawing.Size(80, 23);
            this.back_button.TabIndex = 1;
            this.back_button.Text = "Назад";
            this.back_button.UseVisualStyleBackColor = true;
            this.back_button.Click += new System.EventHandler(this.back_button_Click);
            // 
            // StackBaseView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.back_button);
            this.Controls.Add(this.content_panel);
            this.Name = "StackBaseView";
            this.Size = new System.Drawing.Size(600, 400);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel content_panel;
        private System.Windows.Forms.Button back_button;
    }
}
