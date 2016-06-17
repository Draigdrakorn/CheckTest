using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Script.Services;
using System.Web.Services;


/// <summary>
/// Summary description for CheckService
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
[ScriptService]
public class CheckService : System.Web.Services.WebService
{

    public CheckService()
    {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    [WebMethod]
    public void NewMethod(string fileName, bool check)
    {
        CheckController objChk = new CheckController();
        CheckInfo checkInfo = new CheckInfo();
        checkInfo.FileName = fileName;
        checkInfo.Checked = check;
        objChk.CheckAdd(checkInfo);

    }

    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public string GetAll()
    {
        CheckController objChk = new CheckController();
        var jsonSerializer = new JavaScriptSerializer();
        var jsonData = jsonSerializer.Serialize(objChk.CheckGetAll());
        return jsonData;
    }
}