using BiBliotekarz.Class;
using System;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;

namespace LibraryApp
{
    public partial class BookManagementForm : Form
    {
        public BookManagementForm()
        {
            InitializeComponent();
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            // Pobieranie danych z pól tekstowych
            string bookName = BookNameTextBox.Text.Trim();
            string author = AutorTextBox.Text.Trim();
            string releaseDateString = RelaseDateBox.Text.Trim();
            string bookCountString = BookCountBox.Text.Trim();
            string bookIDString = IdBookBox.Text.Trim();

            if (string.IsNullOrWhiteSpace(bookName) ||
                string.IsNullOrWhiteSpace(author) ||
                string.IsNullOrWhiteSpace(releaseDateString) ||
                string.IsNullOrWhiteSpace(bookCountString) ||
                string.IsNullOrWhiteSpace(bookIDString))
            {
                MessageBox.Show("Wszystkie pola muszą być wypełnione.", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!DateTime.TryParseExact(releaseDateString, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime releaseDate))
            {
                MessageBox.Show("Podano nieprawidłowy format daty. Użyj formatu yyyy-MM-dd, np. 2000-02-12.", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!int.TryParse(bookCountString, out int bookCount) || bookCount <= 0)
            {
                MessageBox.Show("Liczba egzemplarzy musi być dodatnią liczbą całkowitą.", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!long.TryParse(bookIDString, out long bookID))
            {
                MessageBox.Show("BookID musi być liczbą całkowitą.", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Tworzenie obiektu książki
            Book newBook = new Book(bookName, author, releaseDate, bookID, bookCount, bookCount);

            try
            {
                // Dodanie książki do bazy danych SQL
                LibraryManager.AddBook(newBook);
                MessageBox.Show($"Książka \"{bookName}\" została zapisana w bazie danych.", "Sukces", MessageBoxButtons.OK, MessageBoxIcon.Information);

                ClearFormFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Wystąpił błąd podczas zapisywania książki:\n{ex.Message}", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void ClearFormFields()
        {
            BookNameTextBox.Clear();
            AutorTextBox.Clear();
            RelaseDateBox.Clear();
            BookCountBox.Clear();
        }

        
    }
}
