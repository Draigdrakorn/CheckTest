using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Controls_ctl_Check : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //HideAll();
            BindCheckGrid();
            //divList.Visible = true;
        }
    }

    private void BindCheckGrid()
    {
        CheckController ctl = new CheckController();
        gdvCheckList.DataSource = ctl.CheckGetAll();
        gdvCheckList.DataBind();
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        Add();
        divForm.Visible = false;
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        ClearForm();
        divForm.Visible = false;
    }

    private void ClearForm()
    {
        txtFileName.Text = string.Empty;
        chkChecked.Checked = false;

        Session.Remove("CheckID");
        divList.Visible = true;
    }

    private void Add()
    {
        btnAdd.Text = "Add";
        CheckInfo objDemo = new CheckInfo();
        objDemo.FileName = txtFileName.Text.Trim();
        objDemo.Checked = IsChecked();
        CheckController objController = new CheckController();
        if (Session["CheckID"] != null && Session["CheckID"].ToString() != string.Empty)
        {
            objDemo.CheckID = Int32.Parse(Session["CheckID"].ToString());
            objController.CheckUpdate(objDemo);
            lblMessage.Text = "Updated...";
        }
        else
        {

            objController.CheckAdd(objDemo);
            lblMessage.Text = "Saved...";
        }
        BindCheckGrid();
        ClearForm();
    }

    private void HideAll()
    {
        divForm.Visible = false;
        divList.Visible = false;
    }



    protected void btnAddNew_Click(object sender, EventArgs e)
    {
        ClearForm();
        HideAll();
        divForm.Visible = true;
    }



    private void DeleteCheckByID(int CheckID)
    {
        CheckController ctl = new CheckController();
        ctl.CheckDelete(CheckID);
        lblMessage.Text = "Deleted succeeded...";
        BindCheckGrid();
    }

    private void EditCheckByID(int CheckID)
    {
        CheckController ctl = new CheckController();
        CheckInfo objDemo = ctl.SelectByID(CheckID);
        txtFileName.Text = objDemo.FileName;
        chkChecked.Checked = objDemo.Checked;
        Session["CheckID"] = CheckID;
        btnAdd.Text = "Update";
        HideAll();
        divForm.Visible = true;
        
}   

    private bool IsChecked()
    {
        if(chkChecked.Checked)
        {
            return true;
        }
        else
        {
            return false;
        }
           
    }


    #region "Gridview Events"

    protected void gdvCheckList_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int CheckID = Int32.Parse(e.CommandArgument.ToString());
        if (e.CommandName == "Edit")
        {
            EditCheckByID(CheckID);
        }
        else if (e.CommandName == "Delete")
        {
            DeleteCheckByID(CheckID);
        }
    }

    protected void gdvCheckList_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            LinkButton btnDelete = (LinkButton)e.Row.FindControl("imgDelete");
            btnDelete.Attributes.Add("onclick", "javascript:return " + "confirm('Are you sure to delete?')");
        }
    }

    protected void gdvCheckList_RowEditing(object sender, GridViewEditEventArgs e)
    {

    }

    protected void gdvCheckList_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

    }

    protected void gdvCheckList_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {

    }

    #endregion
}

