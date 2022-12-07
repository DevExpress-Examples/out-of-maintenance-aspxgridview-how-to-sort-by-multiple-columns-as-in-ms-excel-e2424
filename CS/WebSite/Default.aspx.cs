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


public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        for (int i = 0; i < ASPxGridView1.Columns.Count; i++)
        {
            if (ASPxGridView1.Columns[i] is GridViewDataColumn)
            {
                SortUnit c = LoadControl("SortUnit.ascx") as SortUnit;
                GridViewDataColumn col = ASPxGridView1.Columns[i] as GridViewDataColumn;
                c.ID = "unit" + col.FieldName;
                c.Grid = ASPxGridView1;
                if (i == 0)
                {
                    c.Header = "Sort By";
                }
                else
                {
                    c.Header = "Then By";
                }
                ASPxPanel1.Controls.Add(c);
            }


        }
    }
    protected void ASPxGridView1_CustomCallback(object sender, ASPxGridViewCustomCallbackEventArgs e)
    {
        ASPxGridView1.ClearSort();
        for (int i = 0; i < ((ASPxGridView)sender).Columns.Count; i++)
        {
            if (((ASPxGridView)sender).Columns[i] is GridViewDataColumn)
            {
                GridViewDataColumn col = ((ASPxGridView)sender).Columns[i] as GridViewDataColumn;
                if (ASPxHiddenField1.Contains("clientColumnNamesunit" + col.FieldName))
                {
                    Dictionary<string, object> dict = ASPxHiddenField1.Get("clientColumnNamesunit" + col.FieldName) as Dictionary<string, object>;
                    string sortOrder = dict["Order"] as string;
                    string FieldName = dict["FieldName"] as string;

                    if (sortOrder == null || FieldName == null)
                    {
                        object previousField;
                        if (dict.TryGetValue("ClearSort", out previousField))
                        {
                            ((GridViewDataColumn)((ASPxGridView)sender).Columns[(string)previousField]).UnSort();                          
                        }
                        continue;
                    }

                    if (sortOrder == "A")
                    {
                        ((GridViewDataColumn)((ASPxGridView)sender).Columns[FieldName]).SortAscending();
                    }
                    else
                    {
                        ((GridViewDataColumn)((ASPxGridView)sender).Columns[FieldName]).SortDescending();
                    }
                }
            }
        }
    }
}
