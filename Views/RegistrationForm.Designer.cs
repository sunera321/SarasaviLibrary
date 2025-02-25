using System;
using System.Windows.Forms;
using SarasaviLibrary.Models;
using SarasaviLibrary.Services;

namespace SarasaviLibrary.Views
{
    public partial class RegistrationForm : Form
    {
        private TabControl tabControl;
        private TabPage tabUser;
        private TabPage tabBook;

        // Controls for User Registration
        private Label lblUserNumber, lblName, lblSex, lblNIC, lblAddress, lblUserType;
        private TextBox txtUserNumber, txtName, txtNIC, txtAddress;
        private ComboBox cmbSex, cmbUserType;
        private Button btnRegisterUser;

        // Controls for Book Registration
        private Label lblBookNumber, lblTitle, lblAuthor, lblPublisher, lblIsReference;
        private TextBox txtBookNumber, txtTitle, txtAuthor, txtPublisher;
        private CheckBox chkIsReference;
        private Button btnRegisterBook;
        private Button btnAddCopy;

        // Services
        private UserService userService;
        private BookService bookService;

 
        private void InitializeComponent()
        {
            bookService = new BookService();
            userService = new UserService();
            // Initialize TabControl and Tabs
            this.tabControl = new TabControl();
            this.tabUser = new TabPage("User Registration");
            this.tabBook = new TabPage("Book Registration");

            // Initialize User Registration Controls
            lblUserNumber = new Label();
            lblName = new Label();
            lblSex = new Label();
            lblNIC = new Label();
            lblAddress = new Label();
            lblUserType = new Label();
            txtUserNumber = new TextBox();
            txtName = new TextBox();
            txtNIC = new TextBox();
            txtAddress = new TextBox();
            cmbSex = new ComboBox();
            cmbUserType = new ComboBox();
            btnRegisterUser = new Button();

            // Initialize Book Registration Controls
            lblBookNumber = new Label();
            lblTitle = new Label();
            lblAuthor = new Label();
            lblPublisher = new Label();
            lblIsReference = new Label();
            txtBookNumber = new TextBox();
            txtTitle = new TextBox();
            txtAuthor = new TextBox();
            txtPublisher = new TextBox();
            chkIsReference = new CheckBox();
            btnRegisterBook = new Button();
            btnAddCopy = new Button();

            // Setup TabControl
            tabControl.Dock = DockStyle.Fill;
            tabControl.TabPages.Add(tabUser);
            tabControl.TabPages.Add(tabBook);

            // Set properties for User Registration Controls
            lblUserNumber.Text = "User Number:";
            lblUserNumber.SetBounds(20, 20, 100, 23);
            txtUserNumber.SetBounds(130, 20, 150, 23);

            lblName.Text = "Name:";
            lblName.SetBounds(20, 60, 100, 23);
            txtName.SetBounds(130, 60, 150, 23);

            lblSex.Text = "Sex:";
            lblSex.SetBounds(20, 100, 100, 23);
            cmbSex.SetBounds(130, 100, 150, 23);
            cmbSex.Items.AddRange(new string[] { "Male", "Female", "Other" });

            lblNIC.Text = "NIC:";
            lblNIC.SetBounds(20, 140, 100, 23);
            txtNIC.SetBounds(130, 140, 150, 23);

            lblAddress.Text = "Address:";
            lblAddress.SetBounds(20, 180, 100, 23);
            txtAddress.SetBounds(130, 180, 150, 23);

            lblUserType.Text = "User Type:";
            lblUserType.SetBounds(20, 220, 100, 23);
            cmbUserType.SetBounds(130, 220, 150, 23);
            cmbUserType.Items.AddRange(new string[] { "Member", "Visitor" });

            btnRegisterUser.Text = "Register User";
            btnRegisterUser.SetBounds(130, 260, 120, 30);
            btnRegisterUser.Click += new EventHandler(this.btnRegisterUser_Click);

            // Add user controls to tabUser
            tabUser.Controls.AddRange(new Control[] { lblUserNumber, txtUserNumber, lblName, txtName,
                lblSex, cmbSex, lblNIC, txtNIC, lblAddress, txtAddress, lblUserType, cmbUserType, btnRegisterUser });

            // Set properties for Book Registration Controls
            lblBookNumber.Text = "Book Number:";
            lblBookNumber.SetBounds(20, 20, 100, 23);
            txtBookNumber.SetBounds(130, 20, 150, 23);

            lblTitle.Text = "Title:";
            lblTitle.SetBounds(20, 60, 100, 23);
            txtTitle.SetBounds(130, 60, 150, 23);

            lblAuthor.Text = "Author:";
            lblAuthor.SetBounds(20, 100, 100, 23);
            txtAuthor.SetBounds(130, 100, 150, 23);

            lblPublisher.Text = "Publisher:";
            lblPublisher.SetBounds(20, 140, 100, 23);
            txtPublisher.SetBounds(130, 140, 150, 23);

            lblIsReference.Text = "Reference Only:";
            lblIsReference.SetBounds(20, 180, 100, 23);
            chkIsReference.SetBounds(130, 180, 150, 23);

            btnRegisterBook.Text = "Register Book Title";
            btnRegisterBook.SetBounds(130, 220, 150, 30);
            btnRegisterBook.Click += new EventHandler(this.btnRegisterBook_Click);

            btnAddCopy.Text = "Add Book Copy";
            btnAddCopy.SetBounds(130, 260, 150, 30);
            btnAddCopy.Click += new EventHandler(this.btnAddCopy_Click);

            // Add book controls to tabBook
            tabBook.Controls.AddRange(new Control[] { lblBookNumber, txtBookNumber, lblTitle, txtTitle,
                lblAuthor, txtAuthor, lblPublisher, txtPublisher, lblIsReference, chkIsReference,
                btnRegisterBook, btnAddCopy });

            // Set properties for RegistrationForm
            this.ClientSize = new System.Drawing.Size(350, 350);
            this.Controls.Add(tabControl);
            this.Text = "Registration Process";
        }

        private void btnRegisterUser_Click(object sender, EventArgs e)
        {
            try
            {
                User newUser = new User
                {
                    UserNumber = txtUserNumber.Text.Trim(),
                    Name = txtName.Text.Trim(),
                    Sex = cmbSex.SelectedItem?.ToString() ?? "",
                    NIC = txtNIC.Text.Trim(),
                    Address = txtAddress.Text.Trim(),
                    Type = cmbUserType.SelectedItem?.ToString() == "Member" ? UserType.Member : UserType.Visitor
                };
                userService.RegisterUser(newUser);
                MessageBox.Show("User registered successfully!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void btnRegisterBook_Click(object sender, EventArgs e)
        {
            try
            {
                BookTitle newBook = new BookTitle
                {
                    BookNumber = txtBookNumber.Text.Trim(),
                    Title = txtTitle.Text.Trim(),
                    Author = txtAuthor.Text.Trim(),
                    Publisher = txtPublisher.Text.Trim()
                };
                bookService.RegisterBookTitle(newBook);
                MessageBox.Show("Book title registered successfully!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void btnAddCopy_Click(object sender, EventArgs e)
        {
            try
            {
                string bookNumber = txtBookNumber.Text.Trim();
                BookCopy newCopy = new BookCopy
                {
                    // The service will set the copy number.
                    IsReferenceOnly = chkIsReference.Checked,
                    IsBorrowed = false,
                    IsReserved = false
                };
                bookService.RegisterBookCopy(bookNumber, newCopy);
                MessageBox.Show("Book copy added successfully!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
    }
}