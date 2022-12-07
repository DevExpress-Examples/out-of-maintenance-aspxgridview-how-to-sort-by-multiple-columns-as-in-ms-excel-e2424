// Developer Express Code Central Example:
// ASPxGridView - how to sort by multiple columns (as in MS Excel)
// 
// This sample illustrates how to sort the ASPxGridView by multiple columns using a
// custom sort popup.
// 
// You can find sample updates and versions for different programming languages here:
// http://www.devexpress.com/example=E2424

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DevExpress.Web;

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
        columnNames.ClientSideEvents.Init = String.Format("function(s,e){{OnInit(s,e,'{0}');}}",columnNames.ClientInstanceName);
        columnNames.ClientSideEvents.SelectedIndexChanged = String.Format("function(s,e){{SetSortingUnit({0},{1},'{2}');}}", columnNames.ClientInstanceName, sortOrder.ClientID, columnNames.ClientInstanceName);
        sortOrder.ClientSideEvents.SelectedIndexChanged = String.Format("function(s,e){{SetSortingUnit({0},{1},'{2}');}}", columnNames.ClientInstanceName, sortOrder.ClientID ,columnNames.ClientInstanceName);
        FillCombo();
        unitHeader.Text = header;

        
    }

    protected void FillCombo()
    {
        columnNames.Items.Add("", "");
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
