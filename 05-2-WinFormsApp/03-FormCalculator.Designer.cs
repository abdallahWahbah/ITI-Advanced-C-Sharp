namespace _18_WinFormsApp
{
    partial class FormCalculator
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
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            button4 = new Button();
            button5 = new Button();
            button6 = new Button();
            button7 = new Button();
            button8 = new Button();
            button9 = new Button();
            button10 = new Button();
            button11 = new Button();
            button12 = new Button();
            button13 = new Button();
            txtCalc = new TextBox();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(12, 147);
            button1.Name = "button1";
            button1.Size = new Size(94, 29);
            button1.TabIndex = 0;
            button1.Text = "1";
            button1.UseVisualStyleBackColor = true;
            button1.Click += Number_clicked;
            // 
            // button2
            // 
            button2.Location = new Point(123, 147);
            button2.Name = "button2";
            button2.Size = new Size(94, 29);
            button2.TabIndex = 1;
            button2.Text = "2";
            button2.UseVisualStyleBackColor = true;
            button2.Click += Number_clicked;
            // 
            // button3
            // 
            button3.Location = new Point(236, 147);
            button3.Name = "button3";
            button3.Size = new Size(94, 29);
            button3.TabIndex = 2;
            button3.Text = "3";
            button3.UseVisualStyleBackColor = true;
            button3.Click += Number_clicked;
            // 
            // button4
            // 
            button4.Location = new Point(12, 195);
            button4.Name = "button4";
            button4.Size = new Size(94, 29);
            button4.TabIndex = 5;
            button4.Text = "4";
            button4.UseVisualStyleBackColor = true;
            button4.Click += Number_clicked;
            // 
            // button5
            // 
            button5.Location = new Point(123, 195);
            button5.Name = "button5";
            button5.RightToLeft = RightToLeft.No;
            button5.Size = new Size(94, 29);
            button5.TabIndex = 4;
            button5.Text = "5";
            button5.UseVisualStyleBackColor = true;
            button5.Click += Number_clicked;
            // 
            // button6
            // 
            button6.Location = new Point(236, 195);
            button6.Name = "button6";
            button6.Size = new Size(94, 29);
            button6.TabIndex = 3;
            button6.Text = "6";
            button6.UseVisualStyleBackColor = true;
            button6.Click += Number_clicked;
            // 
            // button7
            // 
            button7.Location = new Point(236, 248);
            button7.Name = "button7";
            button7.Size = new Size(94, 29);
            button7.TabIndex = 8;
            button7.Text = "9";
            button7.UseVisualStyleBackColor = true;
            button7.Click += Number_clicked;
            // 
            // button8
            // 
            button8.Location = new Point(123, 248);
            button8.Name = "button8";
            button8.Size = new Size(94, 29);
            button8.TabIndex = 7;
            button8.Text = "8";
            button8.UseVisualStyleBackColor = true;
            button8.Click += Number_clicked;
            // 
            // button9
            // 
            button9.Location = new Point(12, 248);
            button9.Name = "button9";
            button9.Size = new Size(94, 29);
            button9.TabIndex = 6;
            button9.Text = "7";
            button9.UseVisualStyleBackColor = true;
            button9.Click += Number_clicked;
            // 
            // button10
            // 
            button10.Location = new Point(123, 300);
            button10.Name = "button10";
            button10.Size = new Size(94, 29);
            button10.TabIndex = 9;
            button10.Text = "0";
            button10.UseVisualStyleBackColor = true;
            button10.Click += Number_clicked;
            // 
            // button11
            // 
            button11.Location = new Point(342, 248);
            button11.Name = "button11";
            button11.Size = new Size(94, 29);
            button11.TabIndex = 12;
            button11.Text = "=";
            button11.UseVisualStyleBackColor = true;
            button11.Click += button11_Click;
            // 
            // button12
            // 
            button12.Location = new Point(342, 195);
            button12.Name = "button12";
            button12.Size = new Size(94, 29);
            button12.TabIndex = 11;
            button12.Text = "-";
            button12.UseVisualStyleBackColor = true;
            button12.Click += Add_Sub_clicked;
            // 
            // button13
            // 
            button13.Location = new Point(342, 147);
            button13.Name = "button13";
            button13.Size = new Size(94, 29);
            button13.TabIndex = 10;
            button13.Text = "+";
            button13.UseVisualStyleBackColor = true;
            button13.Click += Add_Sub_clicked;
            // 
            // txtCalc
            // 
            txtCalc.Dock = DockStyle.Top;
            txtCalc.Location = new Point(0, 0);
            txtCalc.Name = "txtCalc";
            txtCalc.Size = new Size(454, 27);
            txtCalc.TabIndex = 13;
            // 
            // FormCalculator
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(454, 450);
            Controls.Add(txtCalc);
            Controls.Add(button11);
            Controls.Add(button12);
            Controls.Add(button13);
            Controls.Add(button10);
            Controls.Add(button7);
            Controls.Add(button8);
            Controls.Add(button9);
            Controls.Add(button4);
            Controls.Add(button5);
            Controls.Add(button6);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Name = "FormCalculator";
            Text = "FormCalculator";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private Button button2;
        private Button button3;
        private Button button4;
        private Button button5;
        private Button button6;
        private Button button7;
        private Button button8;
        private Button button9;
        private Button button10;
        private Button button11;
        private Button button12;
        private Button button13;
        private TextBox txtCalc;
    }
}