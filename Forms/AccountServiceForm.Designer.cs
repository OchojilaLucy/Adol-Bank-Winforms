namespace AdolBankWinforms.Forms
{
    partial class AccountServiceForm
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
            button8 = new Button();
            button7 = new Button();
            button6 = new Button();
            button5 = new Button();
            button4 = new Button();
            button3 = new Button();
            button2 = new Button();
            button1 = new Button();
            hScrollBar1 = new HScrollBar();
            vScrollBar1 = new VScrollBar();
            SuspendLayout();
            // 
            // button8
            // 
            button8.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            button8.BackColor = Color.NavajoWhite;
            button8.Font = new Font("Comic Sans MS", 9.75F, FontStyle.Bold);
            button8.ForeColor = Color.Brown;
            button8.Location = new Point(-48, 397);
            button8.Margin = new Padding(4, 3, 4, 3);
            button8.Name = "button8";
            button8.Size = new Size(905, 35);
            button8.TabIndex = 15;
            button8.Text = "LOGOUT";
            button8.UseVisualStyleBackColor = false;
            button8.Click += button8_Click;
            // 
            // button7
            // 
            button7.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            button7.BackColor = Color.NavajoWhite;
            button7.Font = new Font("Comic Sans MS", 9.75F, FontStyle.Bold);
            button7.ForeColor = Color.Brown;
            button7.Location = new Point(-57, 286);
            button7.Margin = new Padding(4, 3, 4, 3);
            button7.Name = "button7";
            button7.Size = new Size(905, 48);
            button7.TabIndex = 14;
            button7.Text = "VIEW ACCOUNT STATEMENT";
            button7.UseVisualStyleBackColor = false;
            button7.Click += button7_Click;
            // 
            // button6
            // 
            button6.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            button6.BackColor = Color.NavajoWhite;
            button6.Font = new Font("Comic Sans MS", 9.75F, FontStyle.Bold);
            button6.ForeColor = Color.Brown;
            button6.Location = new Point(-57, 341);
            button6.Margin = new Padding(4, 3, 4, 3);
            button6.Name = "button6";
            button6.Size = new Size(905, 48);
            button6.TabIndex = 13;
            button6.Text = "CHECK BALANCE";
            button6.UseVisualStyleBackColor = false;
            button6.Click += button6_Click;
            // 
            // button5
            // 
            button5.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            button5.BackColor = Color.NavajoWhite;
            button5.Font = new Font("Comic Sans MS", 9.75F, FontStyle.Bold);
            button5.ForeColor = Color.Brown;
            button5.Location = new Point(-57, 230);
            button5.Margin = new Padding(4, 3, 4, 3);
            button5.Name = "button5";
            button5.Size = new Size(905, 48);
            button5.TabIndex = 12;
            button5.Text = "TRANSFER";
            button5.UseVisualStyleBackColor = false;
            button5.Click += button5_Click_1;
            // 
            // button4
            // 
            button4.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            button4.BackColor = Color.NavajoWhite;
            button4.Font = new Font("Comic Sans MS", 9.75F, FontStyle.Bold);
            button4.ForeColor = Color.Brown;
            button4.Location = new Point(-48, 175);
            button4.Margin = new Padding(4, 3, 4, 3);
            button4.Name = "button4";
            button4.Size = new Size(905, 48);
            button4.TabIndex = 11;
            button4.Text = "WITHDRAW";
            button4.UseVisualStyleBackColor = false;
            button4.Click += button4_Click_1;
            // 
            // button3
            // 
            button3.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            button3.BackColor = Color.NavajoWhite;
            button3.Font = new Font("Comic Sans MS", 9.75F, FontStyle.Bold);
            button3.ForeColor = Color.Brown;
            button3.Location = new Point(-48, 121);
            button3.Margin = new Padding(4, 3, 4, 3);
            button3.Name = "button3";
            button3.Size = new Size(905, 47);
            button3.TabIndex = 10;
            button3.Text = "DEPOSIT";
            button3.UseVisualStyleBackColor = false;
            button3.Click += button3_Click;
            // 
            // button2
            // 
            button2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            button2.BackColor = Color.NavajoWhite;
            button2.Font = new Font("Comic Sans MS", 9.75F, FontStyle.Bold);
            button2.ForeColor = Color.Brown;
            button2.Location = new Point(-48, 69);
            button2.Margin = new Padding(4, 3, 4, 3);
            button2.Name = "button2";
            button2.Size = new Size(905, 45);
            button2.TabIndex = 9;
            button2.Text = "VIEW ACCOUNT DETAILS";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // button1
            // 
            button1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            button1.BackColor = Color.NavajoWhite;
            button1.Font = new Font("Comic Sans MS", 9.75F, FontStyle.Bold);
            button1.ForeColor = Color.Brown;
            button1.Location = new Point(-48, 18);
            button1.Margin = new Padding(4, 3, 4, 3);
            button1.Name = "button1";
            button1.Size = new Size(905, 44);
            button1.TabIndex = 8;
            button1.Text = "CREATE ACCOUNT";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click_1;
            // 
            // hScrollBar1
            // 
            hScrollBar1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            hScrollBar1.Location = new Point(-4, 435);
            hScrollBar1.Name = "hScrollBar1";
            hScrollBar1.Size = new Size(808, 17);
            hScrollBar1.TabIndex = 16;
            // 
            // vScrollBar1
            // 
            vScrollBar1.Location = new Point(787, 1);
            vScrollBar1.Name = "vScrollBar1";
            vScrollBar1.Size = new Size(17, 434);
            vScrollBar1.TabIndex = 17;
            // 
            // AccountServiceForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(vScrollBar1);
            Controls.Add(hScrollBar1);
            Controls.Add(button8);
            Controls.Add(button7);
            Controls.Add(button6);
            Controls.Add(button5);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Name = "AccountServiceForm";
            Text = "AccountServiceForm";
            Load += AccountServiceForm_Load;
            ResumeLayout(false);
        }

        #endregion

        private Button button8;
        private Button button7;
        private Button button6;
        private Button button5;
        private Button button4;
        private Button button3;
        private Button button2;
        private Button button1;
        private HScrollBar hScrollBar1;
        private VScrollBar vScrollBar1;
    }
}