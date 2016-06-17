using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Check.SQL.Utilities;

/// <summary>
/// Summary description for CheckDataProvider
/// </summary>
public class CheckDataProvider
{
    public CheckDataProvider()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public void CheckAdd(CheckInfo checkInfo)
    {
        List<KeyValuePair<string, object>> Param = new List<KeyValuePair<string, object>>();
        Param.Add(new KeyValuePair<string, object>("@FileName", checkInfo.FileName));
        Param.Add(new KeyValuePair<string, object>("@Checked", checkInfo.Checked));

        SQLHandler objSQL = new SQLHandler();
        objSQL.ExecuteNonQuery("usp_AddFileCheck", Param);
    }

    public void CheckUpdate(CheckInfo checkInfo)
    {
        List<KeyValuePair<string, object>> Param = new List<KeyValuePair<string, object>>();
        Param.Add(new KeyValuePair<string, object>("@CheckID", checkInfo.CheckID));
        Param.Add(new KeyValuePair<string, object>("@FileName", checkInfo.FileName));
        Param.Add(new KeyValuePair<string, object>("@Checked", checkInfo.Checked));

        SQLHandler objSQL = new SQLHandler();
        objSQL.ExecuteNonQuery("usp_UpdateFileCheck", Param);
    }

    public List<CheckInfo> CheckGetAll()
    {
        SQLHandler objSQL = new SQLHandler();
        return objSQL.ExecuteAsList<CheckInfo>("usp_SelectAllCheck");
    }

    public CheckInfo SelectByID(int checkID)
    {
        List<KeyValuePair<string, object>> Param = new List<KeyValuePair<string, object>>();
        Param.Add(new KeyValuePair<string, object>("@CheckID", checkID));
        SQLHandler objSQL = new SQLHandler();
        return objSQL.ExecuteAsObject<CheckInfo>("usp_SelectByID", Param);
    }

    public void CheckDelete(int checkID)
    {
        List<KeyValuePair<string, object>> Param = new List<KeyValuePair<string, object>>();
        Param.Add(new KeyValuePair<string, object>("@CheckID", checkID));

        SQLHandler objSQL = new SQLHandler();
        objSQL.ExecuteNonQuery("usp_DeleteFileCheck", Param);
    }
}