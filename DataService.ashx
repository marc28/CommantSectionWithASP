<%@ WebHandler Language="C#" Class="DataService" %>

using System;
using System.Web;

public class DataService : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "text/plain";
        string title = context.Request.Params.Get("title");
        if (string.IsNullOrEmpty(title) == true)
        {
            context.Response.Write("Error From DataService");
            return;     
        }
        
        string resDataJSONObject = ConnectionClass.returnData(title);
        context.Response.Write(resDataJSONObject);
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}