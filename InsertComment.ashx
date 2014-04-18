<%@ WebHandler Language="C#" Class="InsertComment" %>

using System;
using System.Web;

public class InsertComment : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "text/plain";
        
        //Variables
        string name = context.Request.Params.Get("name");
        string comment = context.Request.Params.Get("comment");
        
        //Check to see not null
        if (name != null && comment != null) 
        {
            ConnectionClass.AddComment(name, comment); //method 1 being called
        }
        
        //Send data on as json object
        string resDataJSONObject = ConnectionClass.returnData(); //method 2 being called
        context.Response.Write(resDataJSONObject); //sending the json object on!!
       
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}