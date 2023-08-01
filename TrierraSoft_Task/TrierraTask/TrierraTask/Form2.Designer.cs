using System.ComponentModel;

namespace TrierraTask
{
    partial class Form2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

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
            ParentTextBox = new TextBox();
            ChildTextBox = new TextBox();
            label1 = new Label();
            label2 = new Label();
            button1 = new Button();
            SuspendLayout();
            // 
            // ParentTextBox
            // 
            ParentTextBox.Location = new Point(99, 137);
            ParentTextBox.Margin = new Padding(3, 4, 3, 4);
            ParentTextBox.Name = "ParentTextBox";
            ParentTextBox.Size = new Size(293, 27);
            ParentTextBox.TabIndex = 0;
            ParentTextBox.Validating += ParentTextBox_Validating;
            // 
            // ChildTextBox
            // 
            ChildTextBox.Location = new Point(99, 249);
            ChildTextBox.Margin = new Padding(3, 4, 3, 4);
            ChildTextBox.Name = "ChildTextBox";
            ChildTextBox.Size = new Size(293, 27);
            ChildTextBox.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(99, 95);
            label1.Name = "label1";
            label1.Size = new Size(94, 20);
            label1.TabIndex = 2;
            label1.Text = "Parent Name";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(106, 205);
            label2.Name = "label2";
            label2.Size = new Size(87, 20);
            label2.TabIndex = 3;
            label2.Text = "Child Name";
            // 
            // button1
            // 
            button1.Location = new Point(101, 368);
            button1.Margin = new Padding(3, 4, 3, 4);
            button1.Name = "button1";
            button1.Size = new Size(86, 31);
            button1.TabIndex = 4;
            button1.Text = "Save";
            button1.UseVisualStyleBackColor = true;
            button1.Click += SaveButton_Click;
            // 
            // Form2
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(914, 600);
            Controls.Add(button1);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(ChildTextBox);
            Controls.Add(ParentTextBox);
            Margin = new Padding(3, 4, 3, 4);
            Name = "Form2";
            Text = "Form2";
            ResumeLayout(false);
            PerformLayout();
        }


        #endregion

        private TextBox ParentTextBox;
        private TextBox ChildTextBox;
        private Label label1;
        private Label label2;
        private Button button1;
        private DataGridView dataGridView1;
    }
}