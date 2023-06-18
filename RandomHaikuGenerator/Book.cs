using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomHaikuGenerator
{
    struct book
    {
        public string title;
        public int price;
    }

    struct client
    {
        public string name;
        public List<string> borrowedBooks;
    }

    public interface IBook
    {
        public string GetBook();
        public int GetPrice();
        public void SetBookArray(string name);

        public void SetBookList(string name);
        public void SetPrice(int n);

    }

    public interface ILibrary
    {

        public bool BookFount(string name);
        public string InInvenroty();
        public int AvailableStock(string name);
        public bool SaveBook(int price, string title);

        public void PrintBookInfo();
    }

    public interface IClient
    {
        public string GetClientName();
        public int GetClientNumber();
    }

    public class Library : ILibrary, IClient
    {
        IBook _book;
        private book[] booksInStorage;
        List<book> bookList = new List<book>();

        public Library()
        {
            booksInStorage = new book[10];
        }

        public int GetBookInStorage()
        {
            return booksInStorage.Length;
        }

        public bool BookFount(string name)
        {
            for (int i = 0; i < booksInStorage.Length; i++)
            {
                if (booksInStorage[i].title == name)
                {
                    return true;
                }
            }
            return false;
        }

        public string GetClientName()
        {
            throw new NotImplementedException();
        }

        public int GetClientNumber()
        {
            throw new NotImplementedException();
        }

        public string InInvenroty()
        {
            throw new NotImplementedException();


        }

        public bool SaveBook(int price, string title)
        {
           
            for (int i = 0; i < booksInStorage.Length; i++)
            {
                if (booksInStorage[i].title == null)
                {
                    booksInStorage[i].title = title;
                    booksInStorage[i].price = price;
                    return true;
                }
            }
            return false;
        }

        public int AvailableStock(string name)
        {
            int amount = 0;
            for (int i = 0; i < booksInStorage.Length; i++)
            {
                if (booksInStorage[i].title == name)
                {
                    amount++;
                }
            }
            return amount;
        }

        public void PrintBookInfo()
        {
            for (int i = 0; i < booksInStorage.Length; i++)
            {
                Console.WriteLine("Books Info" + booksInStorage[i].title + "" + booksInStorage[i].price);
            }
        }
    }

}