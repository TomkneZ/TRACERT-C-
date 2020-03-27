namespace TRACEROUT
{
    partial class Form1
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
            this.richTextBox_route = new System.Windows.Forms.RichTextBox();
            this.textBox_dest = new System.Windows.Forms.TextBox();
            this.button_tracert = new System.Windows.Forms.Button();
            this.button_clear = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // richTextBox_route
            // 
            this.richTextBox_route.Location = new System.Drawing.Point(12, 40);
            this.richTextBox_route.Name = "richTextBox_route";
            this.richTextBox_route.Size = new System.Drawing.Size(776, 368);
            this.richTextBox_route.TabIndex = 0;
            this.richTextBox_route.Text = "";
            this.richTextBox_route.TextChanged += new System.EventHandler(this.richTextBox1_TextChanged);
            // 
            // textBox_dest
            // 
            this.textBox_dest.Location = new System.Drawing.Point(12, 12);
            this.textBox_dest.Name = "textBox_dest";
            this.textBox_dest.Size = new System.Drawing.Size(577, 22);
            this.textBox_dest.TabIndex = 1;
            // 
            // button_tracert
            // 
            this.button_tracert.Location = new System.Drawing.Point(595, 12);
            this.button_tracert.Name = "button_tracert";
            this.button_tracert.Size = new System.Drawing.Size(92, 23);
            this.button_tracert.TabIndex = 2;
            this.button_tracert.Text = "TRACERT";
            this.button_tracert.UseVisualStyleBackColor = true;
            this.button_tracert.Click += new System.EventHandler(this.button_tracert_Click);
            // 
            // button_clear
            // 
            this.button_clear.Location = new System.Drawing.Point(693, 11);
            this.button_clear.Name = "button_clear";
            this.button_clear.Size = new System.Drawing.Size(92, 23);
            this.button_clear.TabIndex = 3;
            this.button_clear.Text = "CLEAR";
            this.button_clear.UseVisualStyleBackColor = true;
            this.button_clear.Click += new System.EventHandler(this.button_clear_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button_clear);
            this.Controls.Add(this.button_tracert);
            this.Controls.Add(this.textBox_dest);
            this.Controls.Add(this.richTextBox_route);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox richTextBox_route;
        private System.Windows.Forms.TextBox textBox_dest;
        private System.Windows.Forms.Button button_tracert;
        private System.Windows.Forms.Button button_clear;
    }
}

