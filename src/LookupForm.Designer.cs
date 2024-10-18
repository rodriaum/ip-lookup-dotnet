using IP_Address_Lookup.src.Buttons;
using IP_Address_Lookup.src.Controls;

namespace IP_Address_Lookup
{
    partial class LookupForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            addressCaptionLabel = new Label();
            titleLabel = new Label();
            backPictureBox = new PictureBox();
            resultCustomListBox = new CustomListBox();
            addressTextBox = new RoundedTextBox();
            ((System.ComponentModel.ISupportInitialize)backPictureBox).BeginInit();
            SuspendLayout();
            // 
            // addressCaptionLabel
            // 
            addressCaptionLabel.AutoSize = true;
            addressCaptionLabel.BackColor = Color.FromArgb(20, 21, 40);
            addressCaptionLabel.Font = new Font("Segoe UI Variable Display", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            addressCaptionLabel.ForeColor = SystemColors.ScrollBar;
            addressCaptionLabel.Location = new Point(210, 350);
            addressCaptionLabel.Name = "addressCaptionLabel";
            addressCaptionLabel.Size = new Size(166, 20);
            addressCaptionLabel.TabIndex = 0;
            addressCaptionLabel.Text = "Insira o seu endereço IP";
            // 
            // titleLabel
            // 
            titleLabel.AutoSize = true;
            titleLabel.Font = new Font("Segoe UI Variable Small Semibol", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            titleLabel.ForeColor = Color.White;
            titleLabel.Location = new Point(330, 28);
            titleLabel.Name = "titleLabel";
            titleLabel.Size = new Size(153, 36);
            titleLabel.TabIndex = 1;
            titleLabel.Text = "IP LOOKUP";
            // 
            // backPictureBox
            // 
            backPictureBox.BackColor = Color.FromArgb(15, 19, 32);
            backPictureBox.BorderStyle = BorderStyle.FixedSingle;
            backPictureBox.Location = new Point(12, 94);
            backPictureBox.Name = "backPictureBox";
            backPictureBox.Size = new Size(776, 200);
            backPictureBox.TabIndex = 2;
            backPictureBox.TabStop = false;
            // 
            // resultCustomListBox
            // 
            resultCustomListBox.BackColor = Color.FromArgb(15, 19, 32);
            resultCustomListBox.BorderStyle = BorderStyle.None;
            resultCustomListBox.Font = new Font("Segoe UI Symbol", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            resultCustomListBox.ForeColor = Color.White;
            resultCustomListBox.FormattingEnabled = true;
            resultCustomListBox.ItemHeight = 20;
            resultCustomListBox.Location = new Point(47, 124);
            resultCustomListBox.Name = "resultCustomListBox";
            resultCustomListBox.SelectionMode = SelectionMode.None;
            resultCustomListBox.Size = new Size(703, 140);
            resultCustomListBox.TabIndex = 3;
            // 
            // addressTextBox
            // 
            addressTextBox.BackColor = Color.FromArgb(15, 19, 32);
            addressTextBox.BorderStyle = BorderStyle.None;
            addressTextBox.Font = new Font("Segoe UI Variable Display", 15F, FontStyle.Regular, GraphicsUnit.Point, 0);
            addressTextBox.ForeColor = Color.White;
            addressTextBox.Location = new Point(200, 380);
            addressTextBox.Multiline = true;
            addressTextBox.Name = "addressTextBox";
            addressTextBox.Size = new Size(400, 35);
            addressTextBox.TabIndex = 4;
            addressTextBox.TextAlign = HorizontalAlignment.Center;
            addressTextBox.KeyDown += AddressTextBox_KeyDown;
            // 
            // LookupForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(20, 21, 40);
            ClientSize = new Size(800, 450);
            Controls.Add(resultCustomListBox);
            Controls.Add(backPictureBox);
            Controls.Add(titleLabel);
            Controls.Add(addressTextBox);
            Controls.Add(addressCaptionLabel);
            Name = "LookupForm";
            Text = "LookupForm";
            Load += LookupForm_Load;
            ((System.ComponentModel.ISupportInitialize)backPictureBox).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label addressCaptionLabel;
        private Label titleLabel;
        private PictureBox backPictureBox;
        private CustomListBox resultCustomListBox;
        private RoundedTextBox addressTextBox;
    }
}
