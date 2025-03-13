namespace AdolBankWinforms.Forms
{
    partial class TransferForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label4 = new Label();
            textBox3 = new TextBox();
            button1 = new Button();
            textBox2 = new TextBox();
            textBox1 = new TextBox();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            SuspendLayout();
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.LightCyan;
            label4.Font = new Font("Comic Sans MS", 11.25F);
            label4.ForeColor = Color.DarkGreen;
            label4.Location = new Point(104, 155);
            label4.Margin = new Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new Size(261, 20);
            label4.TabIndex = 27;
            label4.Text = "Enter Destination Account Number: ";
            // 
            // textBox3
            // 
            textBox3.BackColor = Color.LightCyan;
            textBox3.Font = new Font("Comic Sans MS", 11.25F);
            textBox3.ForeColor = Color.DarkGreen;
            textBox3.Location = new Point(370, 185);
            textBox3.Margin = new Padding(4, 3, 4, 3);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(116, 28);
            textBox3.TabIndex = 26;
            // 
            // button1
            // 
            button1.BackColor = Color.LightCyan;
            button1.Font = new Font("Comic Sans MS", 11.25F);
            button1.ForeColor = Color.DarkGreen;
            button1.Location = new Point(384, 239);
            button1.Margin = new Padding(4, 3, 4, 3);
            button1.Name = "button1";
            button1.Size = new Size(88, 27);
            button1.TabIndex = 25;
            button1.Text = "Enter";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click_1;
            // 
            // textBox2
            // 
            textBox2.BackColor = Color.LightCyan;
            textBox2.Font = new Font("Comic Sans MS", 11.25F);
            textBox2.ForeColor = Color.DarkGreen;
            textBox2.Location = new Point(370, 151);
            textBox2.Margin = new Padding(4, 3, 4, 3);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(116, 28);
            textBox2.TabIndex = 24;
            // 
            // textBox1
            // 
            textBox1.BackColor = Color.LightCyan;
            textBox1.Font = new Font("Comic Sans MS", 11.25F);
            textBox1.ForeColor = Color.DarkGreen;
            textBox1.Location = new Point(370, 117);
            textBox1.Margin = new Padding(4, 3, 4, 3);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(116, 28);
            textBox1.TabIndex = 23;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.LightCyan;
            label3.Font = new Font("Comic Sans MS", 11.25F);
            label3.ForeColor = Color.DarkGreen;
            label3.Location = new Point(125, 55);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(88, 20);
            label3.TabIndex = 22;
            label3.Text = "TRANSFER";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.LightCyan;
            label2.Font = new Font("Comic Sans MS", 11.25F);
            label2.ForeColor = Color.DarkGreen;
            label2.Location = new Point(104, 199);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(113, 20);
            label2.TabIndex = 21;
            label2.Text = "Enter Amount: ";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.LightCyan;
            label1.Font = new Font("Comic Sans MS", 11.25F);
            label1.ForeColor = Color.DarkGreen;
            label1.Location = new Point(102, 120);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(230, 20);
            label1.TabIndex = 20;
            label1.Text = "Enter Source Account Number: ";
            // 
            // TransferForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LightCyan;
            ClientSize = new Size(800, 450);
            Controls.Add(label4);
            Controls.Add(textBox3);
            Controls.Add(button1);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "TransferForm";
            Text = "TransferForm";
            Load += TransferForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label4;
        private TextBox textBox3;
        private Button button1;
        private TextBox textBox2;
        private TextBox textBox1;
        private Label label3;
        private Label label2;
        private Label label1;
    }
}