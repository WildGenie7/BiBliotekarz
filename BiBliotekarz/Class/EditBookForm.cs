using System;
using System.Windows.Forms;

namespace BiBliotekarz.Class
{
    public partial class EditBookForm : Form
    {
        private Book currentBook;

        public EditBookForm(Book book = null)
        {
            currentBook = book ?? new Book("", "", DateTime.Now, 0, 0, 0);
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            Text = "Edytuj książkę";
            Width = 300;
            Height = 400;

            var nameLabel = new Label { Text = "Tytuł", Top = 20, Left = 20 };
            var nameBox = new TextBox { Top = 20, Left = 100, Width = 150, Text = currentBook.BookName };
            var authorLabel = new Label { Text = "Autor", Top = 60, Left = 20 };
            var authorBox = new TextBox { Top = 60, Left = 100, Width = 150, Text = currentBook.Author };
            var releaseDateLabel = new Label { Text = "Data wydania", Top = 100, Left = 20 };
            var releaseDateBox = new TextBox { Top = 100, Left = 100, Width = 150, Text = currentBook.ReleaseDate.ToString("yyyy-MM-dd") };
            var totalCopiesLabel = new Label { Text = "Liczba egzemplarzy", Top = 140, Left = 20 };
            var totalCopiesBox = new TextBox { Top = 140, Left = 100, Width = 150, Text = currentBook.NumberOfBooks.ToString() };
            var availableCopiesLabel = new Label { Text = "Dostępne egzemplarze", Top = 180, Left = 20 };
            var availableCopiesBox = new TextBox { Top = 180, Left = 100, Width = 150, Text = currentBook.AvailableBooks.ToString() };
            var saveButton = new Button { Text = "Zapisz", Top = 220, Left = 100 };

            saveButton.Click += (s, e) =>
            {
                if (!int.TryParse(totalCopiesBox.Text, out int totalCopies) ||
                    !int.TryParse(availableCopiesBox.Text, out int availableCopies))
                {
                    MessageBox.Show("Podano nieprawidłową liczbę egzemplarzy.", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (!DateTime.TryParse(releaseDateBox.Text, out DateTime releaseDate))
                {
                    MessageBox.Show("Nieprawidłowa data wydania.", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                currentBook.BookName = nameBox.Text;
                currentBook.Author = authorBox.Text;
                currentBook.ReleaseDate = releaseDate;
                currentBook.NumberOfBooks = totalCopies;
                currentBook.AvailableBooks = availableCopies;

                try
                {
                    LibraryManager.UpdateBook(currentBook);
                    MessageBox.Show("Książka została zaktualizowana.", "Sukces", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Wystąpił błąd: {ex.Message}", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            };

            Controls.Add(nameLabel);
            Controls.Add(nameBox);
            Controls.Add(authorLabel);
            Controls.Add(authorBox);
            Controls.Add(releaseDateLabel);
            Controls.Add(releaseDateBox);
            Controls.Add(totalCopiesLabel);
            Controls.Add(totalCopiesBox);
            Controls.Add(availableCopiesLabel);
            Controls.Add(availableCopiesBox);
            Controls.Add(saveButton);
        }
    }
}
