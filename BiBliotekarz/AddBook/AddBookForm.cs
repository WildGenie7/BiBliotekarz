using BiBliotekarz.Class;
using LibraryApp;
using System;
using System.Windows.Forms;

namespace BiBliotekarz.AddBook
{
    public partial class AddBookForm : Form
    {
        public AddBookForm()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            Text = "Dodaj Książkę";
            Width = 400;
            Height = 300;

            var nameLabel = new Label { Text = "Tytuł", Top = 20, Left = 20 };
            var nameBox = new TextBox { Top = 20, Left = 150, Width = 200 };

            var authorLabel = new Label { Text = "Autor", Top = 60, Left = 20 };
            var authorBox = new TextBox { Top = 60, Left = 150, Width = 200 };

            var dateLabel = new Label { Text = "Data Wydania (yyyy-MM-dd)", Top = 100, Left = 20 };
            var dateBox = new TextBox { Top = 100, Left = 150, Width = 200 };

            var copiesLabel = new Label { Text = "Liczba Egzemplarzy", Top = 140, Left = 20 };
            var copiesBox = new TextBox { Top = 140, Left = 150, Width = 200 };

            var idLabel = new Label { Text = "ID Książki", Top = 180, Left = 20 };
            var idBox = new TextBox { Top = 180, Left = 150, Width = 200 };

            var submitButton = new Button { Text = "Dodaj", Top = 220, Left = 150, Width = 100 };

            submitButton.Click += (s, e) =>
            {
                if (!int.TryParse(copiesBox.Text, out int totalCopies))
                {
                    MessageBox.Show("Nieprawidłowa liczba egzemplarzy!", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (!DateTime.TryParse(dateBox.Text, out DateTime releaseDate))
                {
                    MessageBox.Show("Nieprawidłowa data wydania!", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                try
                {
                    var book = new Book(
                        nameBox.Text,
                        authorBox.Text,
                        releaseDate,
                        long.Parse(idBox.Text),
                        totalCopies,
                        totalCopies // Początkowa liczba dostępnych książek równa całkowitej liczbie
                    );

                    LibraryManager.AddBook(book);
                    MessageBox.Show("Książka została dodana!", "Sukces", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Błąd: {ex.Message}", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            };


            Controls.Add(nameLabel);
            Controls.Add(nameBox);
            Controls.Add(authorLabel);
            Controls.Add(authorBox);
            Controls.Add(dateLabel);
            Controls.Add(dateBox);
            Controls.Add(copiesLabel);
            Controls.Add(copiesBox);
            Controls.Add(idLabel);
            Controls.Add(idBox);
            Controls.Add(submitButton);
        }
    }
}
