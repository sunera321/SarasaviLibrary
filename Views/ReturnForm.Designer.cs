using System;
using System.Linq;
using System.Windows.Forms;
using SarasaviLibrary.Models;
using SarasaviLibrary.Services;

namespace SarasaviLibrary.Views
{
    public partial class ReturnForm : Form
    {
        private ReturnService returnService ;
        private UserService userService;

        private Label lblUser;
        private Label lblCopy;
        private TextBox txtUserNumber;
        private TextBox txtCopyNumber;
        private Button btnReturn;
        private ReservationService reservationService;

        private void InitializeComponent()
        {
            reservationService = new ReservationService();
            returnService = new ReturnService(reservationService);
            userService = new UserService();
            this.lblUser = new Label();
            this.lblCopy = new Label();
            this.txtUserNumber = new TextBox();
            this.txtCopyNumber = new TextBox();
            this.btnReturn = new Button();
            this.SuspendLayout();
            // 
            // lblUser
            // 
            this.lblUser.Location = new System.Drawing.Point(20, 20);
            this.lblUser.Size = new System.Drawing.Size(100, 23);
            this.lblUser.Text = "User Number:";
            // 
            // txtUserNumber
            // 
            this.txtUserNumber.Location = new System.Drawing.Point(130, 20);
            this.txtUserNumber.Size = new System.Drawing.Size(150, 23);
            // 
            // lblCopy
            // 
            this.lblCopy.Location = new System.Drawing.Point(20, 60);
            this.lblCopy.Size = new System.Drawing.Size(100, 23);
            this.lblCopy.Text = "Copy Number:";
            // 
            // txtCopyNumber
            // 
            this.txtCopyNumber.Location = new System.Drawing.Point(130, 60);
            this.txtCopyNumber.Size = new System.Drawing.Size(150, 23);
            // 
            // btnReturn
            // 
            this.btnReturn.Location = new System.Drawing.Point(130, 100);
            this.btnReturn.Size = new System.Drawing.Size(100, 30);
            this.btnReturn.Text = "Return Book";
            this.btnReturn.Click += new EventHandler(this.btnReturn_Click);
            // 
            // ReturnForm
            // 
            this.ClientSize = new System.Drawing.Size(320, 150);
            this.Controls.Add(this.lblUser);
            this.Controls.Add(this.txtUserNumber);
            this.Controls.Add(this.lblCopy);
            this.Controls.Add(this.txtCopyNumber);
            this.Controls.Add(this.btnReturn);
            this.Text = "Return Process";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            try
            {
                string userNumber = txtUserNumber.Text.Trim();
                string copyNumber = txtCopyNumber.Text.Trim();

                User user = userService.GetUser(userNumber);
                if (user == null)
                {
                    MessageBox.Show("User not found.");
                    return;
                }

                // Find the active loan for this copy.
                Loan loan = user.CurrentLoans.FirstOrDefault(l =>
                    !l.IsReturned && l.BookCopy.CopyNumber.Equals(copyNumber, StringComparison.OrdinalIgnoreCase));

                if (loan == null)
                {
                    MessageBox.Show("Active loan for the specified book copy not found.");
                    return;
                }

                returnService.ProcessReturn(loan);
                MessageBox.Show("Book returned successfully.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
    }
}
