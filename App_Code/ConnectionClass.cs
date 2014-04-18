using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;

/// <summary>
/// Summary description for ConnectionClass
/// </summary>
public class ConnectionClass
{
    //Class Variables
    private static SqlConnection conn; //opens a connection
    private static SqlCommand command; //needed to execute an SQL statement


    //============================================================
    /*
     * constructor - note its static. Possible because an action that needs to be performed once only 
     * Everytime an object made the connection is made to the 'ConnectionString'
     * 
     */
    static ConnectionClass()
    {
        string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString(); //this links to the xml configure file
        conn = new SqlConnection(connectionString); //connection to the configured file
        command = new SqlCommand("", conn);

    }


    public static string returnData(String title)
    {
        //Check to see if user already exists
        string query = string.Format("SELECT * FROM books WHERE title LIKE '%{0}%'", title); // remember titl here is being passed in as a paramater 
        command.CommandText = query;

        List<BookItem> booksList = new List<BookItem>(); //List to store book object
        try
        {
            conn.Open();
            SqlDataReader reader = command.ExecuteReader();
            while(reader.Read())
            {
                //string, string, int, float
                BookItem book = new BookItem(); //create a new ook object
                book.title = reader.GetString(0);
                book.publisher = reader.GetString(1);
                book.publicationYear = reader.GetInt32(2);
                book.price = reader.GetDouble(3);
                booksList.Add(book);
            }
            reader.Close();
        }
        finally
        {
           
            conn.Close();
        }

        //creating the json object
        string result = "[";
        for (int i = 0; i < booksList.Count; i++)
        {
            BookItem book = booksList[i];
            result += book.toJSON(); //toJson is the methos I creted in the book class
            if (booksList.Count - 1 > i)
            {
                result += ",";
            }
        }
        //BookItem last = booksList[booksList.Count - 1];
        //string result = "[";
        //foreach (BookItem book in booksList)
        //{
        //    result += book.toJSON();
        //    if (book != last)
        //        result += ",";
        //}
        result += "]";
        return result; //remember result is a Json Object




    }
}