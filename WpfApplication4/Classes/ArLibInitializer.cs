using System.Collections.Generic;
using System.Data.Entity;

namespace ArLib.Classes
{
    class ArLibInitializer : DropCreateDatabaseIfModelChanges<ArLibCon>
    {
        protected override void Seed(ArLibCon context)
        {
            IList<Administrator> admin = new List<Administrator>();
            IList<Book> books = new List<Book>();
            IList<Reader> readers = new List<Reader>();

            admin.Add(new Administrator() { imię = "admin", nazwisko = "admin", login = "abc", hasło = "abc" });

            books.Add(new Book() { tytuł = "Książka 1", autor = "Autor 1", ISBN = "123-456", liczbaStron = "444", wydawnictwo = "Wydawnictwo 1", seria = "Seria 1", ID = 1});
            books.Add(new Book() { tytuł = "Książka 2", autor = "Autor 2", ISBN = "789-123", liczbaStron = "555", wydawnictwo = "Wydawnictwo 2", seria = "Seria 2", ID = 2 });
            books.Add(new Book() { tytuł = "Książka 3", autor = "Autor 3", ISBN = "456-789", liczbaStron = "666", wydawnictwo = "Wydawnictwo 3", seria = "Seria 3", ID = 3 });
            books.Add(new Book() { tytuł = "Książka 4", autor = "Autor 4", ISBN = "987-654", liczbaStron = "777", wydawnictwo = "Wydawnictwo 4", seria = "Seria 4", ID = 4 });
            books.Add(new Book() { tytuł = "Książka 5", autor = "Autor 5", ISBN = "321-789", liczbaStron = "888", wydawnictwo = "Wydawnictwo 5", seria = "Seria 5", ID = 5 });

            readers.Add(new Reader() { imię = "Czytelnik", nazwisko = "Pierwszy", adres = "Adres 1", nrTelefonu = "123456789", ID = 1 });
            readers.Add(new Reader() { imię = "Czytelnik", nazwisko = "Drugi", adres = "Adres 2", nrTelefonu = "987654321", ID = 2 });
            readers.Add(new Reader() { imię = "Czytelnik", nazwisko = "Trzeci", adres = "Adres 3", nrTelefonu = "524896357", ID = 3 });
            readers.Add(new Reader() { imię = "Czytelnik", nazwisko = "Czwarty", adres = "Adres 4", nrTelefonu = "741852963", ID = 4 });
            readers.Add(new Reader() { imię = "Czytelnik", nazwisko = "Piąty", adres = "Adres 5", nrTelefonu = "369258147", ID = 5 });


            foreach (Administrator std in admin)
                context.Administration.Add(std);
            foreach (Book std in books)
                context.Books.Add(std);
            foreach (Reader std in readers)
                context.Readers.Add(std);

            base.Seed(context);
        }
    }
}
