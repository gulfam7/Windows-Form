using System;
using System.Collections;
using System.Windows.Forms;

namespace BookInformationKepperApp
{
    public partial class MainUI : Form
    {
        Hashtable bookList = new Hashtable(StringComparer.OrdinalIgnoreCase);

        string numberISBN, bookName;

        int totalDigit, flag = 0;



        public MainUI()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            numberISBN = textBoxISBNInput.Text;
            bookName = textBoxBookName.Text;

            totalDigit = numberISBN.Length;


            if (string.IsNullOrWhiteSpace(numberISBN))
            {
                MessageBox.Show("Please Enter valid ISBN");
            }



            else if (totalDigit == 13)
            {
                IsNumberIsbnExist(numberISBN);
            }
            else
            {
                MessageBox.Show("Please Enter exact 13 digit of ISBN Number.");
            }
        }

        private void IsNumberIsbnExist(string numberISBN)
        {
            if (bookList.ContainsKey(numberISBN))
            {
                MessageBox.Show("This ISBN Number already Exist. \n\n" +
                    "Please Enter New ISBN Number");
            }
            else
            {
                IsExistBook(bookName);
            }
        }

        private void IsExistBook(string bookName)
        {
            if (bookList.ContainsValue(bookName))
            {
                MessageBox.Show("This Book already Exist.");
            }

            else if (string.IsNullOrWhiteSpace(bookName))
            {
                MessageBox.Show("Please Enter Book Name");
            }
            else
            {
                AddBook();
            }
        }

        private void AddBook()
        {
            bookList.Add(numberISBN, bookName);
            listBoxBookName.Items.Add(bookList[numberISBN]);
        }



        private void radioButtonISBN_CheckedChanged(object sender, EventArgs e)
        {
            flag = 1;
        }
        private void radioButtonName_CheckedChanged(object sender, EventArgs e)
        {
            flag = 2;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (flag == 0)
            {
                MessageBox.Show("Please Select any radio button for searching");
            }

            else if (flag == 1)
            {
                SearchBook();
            }
            else if (flag == 2)
            {
                SearchISBN();

            }
        }

        private void SearchBook()
        {
            listBoxOutput.Items.Clear();
            numberISBN = textBoxSearch.Text;

            if (string.IsNullOrWhiteSpace(numberISBN))
            {
                MessageBox.Show("Please Enter ISBN Number");
            }

            else if (bookList.ContainsKey(numberISBN))
            {
                listBoxOutput.Items.Add(bookList[numberISBN]);
            }
            else
            {
                MessageBox.Show("Not Found");
            }
        }

        private void SearchISBN()
        {
            listBoxOutput.Items.Clear();
            bookName = textBoxSearch.Text;
            string tempBook;
            ICollection keyISBN = bookList.Keys;

            if (string.IsNullOrWhiteSpace(bookName))
            {
                MessageBox.Show("Please Enter Book Name");
            }



            else if (bookList.ContainsValue(bookName))
            {
                foreach (string key in keyISBN)
                {
                    tempBook = (string)bookList[key];
                    if (bookName == tempBook)
                    {
                        listBoxOutput.Items.Add(key);
                        break;
                    }
                }

            }


            else
            {
                MessageBox.Show("Not Found");
            }
        }

        private void TextBoxBookName_TextChanged(object sender, EventArgs e)
        {

        }

        private void MainUI_Load(object sender, EventArgs e)
        {

        }


        private void ClearISBNTextBox()
        {
            textBoxISBNInput.Text = "";
            textBoxBookName.Text = "";
        }

    }
}
