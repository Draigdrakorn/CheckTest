using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for CheckController
/// </summary>
public class CheckController
{
    public CheckController()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public void CheckAdd(CheckInfo checkInfo)
    {
        CheckDataProvider objCon = new CheckDataProvider();
        objCon.CheckAdd(checkInfo);
    }

    public void CheckUpdate(CheckInfo checkInfo)
    {
        CheckDataProvider objCon = new CheckDataProvider();
        objCon.CheckUpdate(checkInfo);
    }

    public List<CheckInfo> CheckGetAll()
    {
        CheckDataProvider objCon = new CheckDataProvider();
        List<CheckInfo> lstCheckInfo = objCon.CheckGetAll();
        return lstCheckInfo;
    }

    public CheckInfo SelectByID(int checkID)
    {
        CheckDataProvider objCon = new CheckDataProvider();
        CheckInfo objCheckInfo = objCon.SelectByID(checkID);
        return objCheckInfo;
    }

    public void CheckDelete(int checkID)
    {
        CheckDataProvider objCon = new CheckDataProvider();
        objCon.CheckDelete(checkID);
    }
}