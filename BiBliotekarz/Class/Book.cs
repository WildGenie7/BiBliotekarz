using System;

namespace BiBliotekarz.Class
{
    public class Book
    {
        public string BookName { get; set; }
        public string Author { get; set; }
        public DateTime ReleaseDate { get; set; }
        public long BookID { get; set; }
        public int NumberOfBooks { get; set; }
        public int AvailableBooks { get; set; }

        public Book(string bookName, string author, DateTime releaseDate, long bookID, int numberOfBooks, int availableBooks)
        {
            BookName = bookName;
            Author = author;
            ReleaseDate = releaseDate;
            BookID = bookID;
            NumberOfBooks = numberOfBooks;
            AvailableBooks = availableBooks;
        }





        //public void BookOutput()
        //{
        //    Console.WriteLine($"Ksi¹¿ka: {BookName}\nAutor: {Author}\nWydana: {ReleaseDate:yyyy-MM-dd}\nNumer ID: {BookID}\nDostêpna liczba sztuk: {NumberOfBooks}");
        //}
    }
}
