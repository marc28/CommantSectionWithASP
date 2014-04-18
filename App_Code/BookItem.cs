using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for BookItem
/// </summary>
public class BookItem
{
    public string title {get; set;}
    public string publisher { get; set; }
    public int publicationYear { get; set; }
    public double price { get; set; }

    /*
     * Sample Output:
     * 
     * {"title":"No SQL Distilled",
     * "publisher":"Addison",
     * "publicationYear","2013",
     * "price":"35"}
     * 
     */ 
    public string toJSON()
    {
        string jsonBook = "{";
        jsonBook += "\"title\":\"" + this.title + "\",";
        jsonBook += "\"publisher\":\"" + this.publisher + "\",";
        jsonBook += "\"publicationYear\":\"" + this.publicationYear + "\",";
        jsonBook += "\"price\":\"" + this.price + "\"";
        jsonBook += "}";
        return jsonBook;
    }

}