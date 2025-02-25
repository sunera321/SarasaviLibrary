using System;
using System.Windows.Forms;
using SarasaviLibrary.Models;
using SarasaviLibrary.Services;

namespace SarasaviLibrary.Views
{
    public partial class InquiryForm : Form
    {
        private BookService bookService;
        private Label lblSearch;
        private TextBox txtSearch;
        private Button btnSearch;
        private ListBox lstResults;

        // Constructor with dependency injection
        public InquiryForm(BookService bookServiceParam = null)
        {
            InitializeComponent();
            this.bookService = bookServiceParam ?? new BookService();
        }

        private void InitializeComponent()
        {
            bookService = new BookService();
            this.lblSearch = new Label();
            this.txtSearch = new TextBox();
            this.btnSearch = new Button();
            this.lstResults = new ListBox();
            this.SuspendLayout();
            // 
            // lblSearch
            // 
            this.lblSearch.Location = new System.Drawing.Point(20, 20);
            this.lblSearch.Size = new System.Drawing.Size(80, 23);
            this.lblSearch.Text = "Search:";
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(100, 20);
            this.txtSearch.Size = new System.Drawing.Size(200, 23);
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(320, 20);
            this.btnSearch.Size = new System.Drawing.Size(80, 23);
            this.btnSearch.Text = "Search";
            this.btnSearch.Click += new EventHandler(this.btnSearch_Click);
            // 
            // lstResults
            // 
            this.lstResults.Location = new System.Drawing.Point(20, 60);
            this.lstResults.Size = new System.Drawing.Size(380, 150);
            // 
            // InquiryForm
            // 
            this.ClientSize = new System.Drawing.Size(420, 230);
            this.Controls.Add(this.lblSearch);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.lstResults);
            this.Text = "Inquiry Process";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                string searchTerm = txtSearch.Text.Trim();
                lstResults.Items.Clear();
                if (string.IsNullOrEmpty(searchTerm))
                {
                    MessageBox.Show("Please enter a search term.");
                    return;
                }

                // Use the bookService to search for books
                var results = bookService.Inquiry(searchTerm);
                if (results != null)
                {
                    lstResults.Items.Add($"Book Number: {results.BookNumber}");
                    lstResults.Items.Add($"Title: {results.Title}");
                    lstResults.Items.Add($"Author: {results.Author}");
                    lstResults.Items.Add($"Publisher: {results.Publisher}");
                    lstResults.Items.Add($"Copies Count: {results.Copies.Count}");

                    // Display information about each copy
                    lstResults.Items.Add("---Copies---");
                    foreach (var copy in results.Copies)
                    {
                        string status = copy.IsBorrowed ? "Borrowed" : "Available";
                        if (copy.IsReferenceOnly)
                            status += " (Reference Only)";
                        if (copy.IsReserved)
                            status += " (Reserved)";

                        lstResults.Items.Add($"Copy {copy.CopyNumber}: {status}");
                    }
                }
                else
                {
                    lstResults.Items.Add("No matching book found.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error during inquiry: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
