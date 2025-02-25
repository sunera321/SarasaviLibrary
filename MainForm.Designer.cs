namespace SarasaviLibrary.Views
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Button btnLoan;
        private System.Windows.Forms.Button btnReturn;
        private System.Windows.Forms.Button btnInquiry;
        private System.Windows.Forms.Button btnRegistration;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.btnLoan = new System.Windows.Forms.Button();
            this.btnReturn = new System.Windows.Forms.Button();
            this.btnInquiry = new System.Windows.Forms.Button();
            this.btnRegistration = new System.Windows.Forms.Button();
            this.SuspendLayout();

            // btnLoan
            this.btnLoan.Location = new System.Drawing.Point(50, 30);
            this.btnLoan.Name = "btnLoan";
            this.btnLoan.Size = new System.Drawing.Size(150, 40);
            this.btnLoan.TabIndex = 0;
            this.btnLoan.Text = "Loan Process";
            this.btnLoan.UseVisualStyleBackColor = true;
            this.btnLoan.Click += new System.EventHandler(this.btnLoan_Click);

            // btnReturn
            this.btnReturn.Location = new System.Drawing.Point(50, 90);
            this.btnReturn.Name = "btnReturn";
            this.btnReturn.Size = new System.Drawing.Size(150, 40);
            this.btnReturn.TabIndex = 1;
            this.btnReturn.Text = "Return Process";
            this.btnReturn.UseVisualStyleBackColor = true;
            this.btnReturn.Click += new System.EventHandler(this.btnReturn_Click);

            // btnInquiry
            this.btnInquiry.Location = new System.Drawing.Point(50, 150);
            this.btnInquiry.Name = "btnInquiry";
            this.btnInquiry.Size = new System.Drawing.Size(150, 40);
            this.btnInquiry.TabIndex = 2;
            this.btnInquiry.Text = "Inquiry Process";
            this.btnInquiry.UseVisualStyleBackColor = true;
            this.btnInquiry.Click += new System.EventHandler(this.btnInquiry_Click);

            // btnRegistration
            this.btnRegistration.Location = new System.Drawing.Point(50, 210);
            this.btnRegistration.Name = "btnRegistration";
            this.btnRegistration.Size = new System.Drawing.Size(150, 40);
            this.btnRegistration.TabIndex = 3;
            this.btnRegistration.Text = "Registration Process";
            this.btnRegistration.UseVisualStyleBackColor = true;
            this.btnRegistration.Click += new System.EventHandler(this.btnRegistration_Click);

            // MainForm
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(260, 300);
            this.Controls.Add(this.btnLoan);
            this.Controls.Add(this.btnReturn);
            this.Controls.Add(this.btnInquiry);
            this.Controls.Add(this.btnRegistration);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sarasavi Library";
            this.ResumeLayout(false);
        }
    }
}
