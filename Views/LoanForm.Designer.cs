using System;
using System.Windows.Forms;
using SarasaviLibrary.Models;
using SarasaviLibrary.Services;

namespace SarasaviLibrary.Views
{
    public partial class LoanForm : Form
    {
        private LoanService loanService;
        private UserService userService;
        private BookService bookService;

        private Label lblUser;
        private Label lblCopy;
        private TextBox txtUserNumber;
        private TextBox txtCopyNumber;
        private Button btnLoan;

  public LoanForm(UserService userServiceParam, BookService bookServiceParam, LoanService loanServiceParam)
{
    InitializeComponent();
    // Use the services passed in as parameters
    loanService = loanServiceParam;
    userService = userServiceParam;
    bookService = bookServiceParam;
}

        private void InitializeComponent()
        {
            loanService = new LoanService();
            userService = new UserService();
            bookService = new BookService();
            this.lblUser = new Label();
            this.lblCopy = new Label();
            this.txtUserNumber = new TextBox();
            this.txtCopyNumber = new TextBox();
            this.btnLoan = new Button();
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
            // btnLoan
            // 
            this.btnLoan.Location = new System.Drawing.Point(130, 100);
            this.btnLoan.Size = new System.Drawing.Size(100, 30);
            this.btnLoan.Text = "Loan Book";
            this.btnLoan.Click += new EventHandler(this.btnLoan_Click);
            // 
            // LoanForm
            // 
            this.ClientSize = new System.Drawing.Size(320, 150);
            this.Controls.Add(this.lblUser);
            this.Controls.Add(this.txtUserNumber);
            this.Controls.Add(this.lblCopy);
            this.Controls.Add(this.txtCopyNumber);
            this.Controls.Add(this.btnLoan);
            this.Text = "Loan Process";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private void btnLoan_Click(object sender, EventArgs e)
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

                // Search for the copy in the entire catalogue.
                BookCopy selectedCopy = null;
                foreach (var book in bookService.BookTitles)
                {
                    selectedCopy = book.Copies.Find(c =>
                        c.CopyNumber.Equals(copyNumber, StringComparison.OrdinalIgnoreCase));
                    if (selectedCopy != null)
                        break;
                }
                if (selectedCopy == null)
                {
                    MessageBox.Show("Book copy not found.");
                    return;
                }

                Loan loan = loanService.CreateLoan(user, selectedCopy);
                MessageBox.Show($"Loan created successfully!\nDue Date: {loan.DueDate.ToShortDateString()}");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
    }
}
