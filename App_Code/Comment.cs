using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Comment
/// </summary>
public class Comment
{

    public int Userid { get; set; }
    public string Name { get; set; }
    public string Comments { get; set; }


    public Comment()
    {

    }

    public Comment(int userid, string name, string comments)
    {
        Userid = userid;
        Name = name;
        Comments = comments;

    }

    public Comment(string name, string comments)
    {
        Name = name;
        Comments = comments;

    }

    /*
    * Method to create a json object
    * 
    */
    public string toJSON()
    {
        string jsonBook = "{";
        jsonBook += "\"userid\":\"" + this.Userid + "\",";
        jsonBook += "\"name\":\"" + this.Name + "\",";
        jsonBook += "\"comments\":\"" + this.Comments + "\"";
        jsonBook += "}";
        return jsonBook;
    }
}