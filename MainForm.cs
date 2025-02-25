using System;
using System.Windows.Forms;

namespace SarasaviLibrary.Views
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent(); // Calls the designer-generated method
        }

        private void btnLoan_Click(object sender, EventArgs e)
        {
            LoanForm loanForm = new LoanForm();
            loanForm.ShowDialog();
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            ReturnForm returnForm = new ReturnForm();
            returnForm.ShowDialog();
        }

        private void btnInquiry_Click(object sender, EventArgs e)
        {
            InquiryForm inquiryForm = new InquiryForm();
            inquiryForm.ShowDialog();
        }

        private void btnRegistration_Click(object sender, EventArgs e)
        {
            RegistrationForm regForm = new RegistrationForm();
            regForm.ShowDialog();
        }
    }
}
