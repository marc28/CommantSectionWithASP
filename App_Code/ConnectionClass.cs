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

    private static SqlConnection conn; //opens a connection
    private static SqlCommand command; //needed to execute an SQL statement

	static ConnectionClass()
	{
        string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString(); //this links to the xml configure file
        conn = new SqlConnection(connectionString); //connection to the configured file
        command = new SqlCommand("", conn);
		
	}

    public static void AddComment(string name, string comment)
    {
        string query = string.Format(
            @"INSERT INTO comment VALUES ('{0}', '{1}')",name, comment);

        command.CommandText = query; //sets the sql query

        try
        {
            conn.Open();
            command.ExecuteNonQuery();
        }
        finally
        {
            conn.Close();
            command.Parameters.Clear();
        }
    }

    //=========================================
    public static string returnData()
    {
     
        string query = string.Format("SELECT name, comment FROM comment"); // remember titl here is being passed in as a paramater 
        command.CommandText = query;
        //Comment comment = new Comment();
        List<Comment> commentList = new List<Comment>(); //List to store book object
        try
        {
            conn.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                //string, string, int, float
               
                string nameRtd = reader.GetString(0);
                string commentRtd = reader.GetString(1);
                Comment comment = new Comment(nameRtd, commentRtd);
                commentList.Add(comment);
            }
            reader.Close();
        }
        finally
        {

            conn.Close();
        }

        //creating the json object
        string result = "[";
        for (int i = 0; i < commentList.Count; i++)
        {
            Comment comment = commentList[i];
            result += comment.toJSON(); //toJson is the methos I creted in the book class
            if (commentList.Count - 1 > i)
            {
                result += ",";
            }
        }
    
        result += "]";
        return result; //remember result is a Json Object




    }

}