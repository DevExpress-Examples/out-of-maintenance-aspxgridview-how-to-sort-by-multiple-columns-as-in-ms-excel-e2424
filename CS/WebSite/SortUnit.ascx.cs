using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DevExpress.Web.ASPxGridView;
using DevExpress.Web.ASPxHiddenField;

public partial class SortUnit : System.Web.UI.UserControl
{
    private ASPxGridView grid;
    private string header;

    public ASPxGridView Grid
    {
       
        set
        {
            grid = value;
        }
        get
        {
            return grid;
        }
    }


    public string Header
    {

        set
        {
            header = value;
        }
        get
        {
            return header;
        }
    }
    
    protected void Page_Load(object sender, EventArgs e)
    {

        columnNames.ClientInstanceName = "clientColumnNames" + this.ID;
        sortOrder.ClientSideEvents.SelectedIndexChanged = "function(s,e){SetSortingUnit("+columnNames.ClientInstanceName+".GetValue(),s.GetValue());}";
        FillCombo();
        unitHeader.Text = header;

        
    }

    protected void FillCombo()
    {

        for (int i = 0; i < grid.Columns.Count; i++)
        {
            if (grid.Columns[i] is GridViewDataColumn)
            {
                string fName = (grid.Columns[i] as GridViewDataColumn).FieldName;
                columnNames.Items.Add(fName, fName);
            }
        }
    }


}
