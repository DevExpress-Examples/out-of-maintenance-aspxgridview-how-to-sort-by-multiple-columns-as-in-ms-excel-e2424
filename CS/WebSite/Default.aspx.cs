using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DevExpress.Web.ASPxGridView;


public partial class _Default : System.Web.UI.Page 
{
    protected void Page_Load(object sender, EventArgs e)
    {
        for (int i = 0; i<ASPxGridView1.Columns.Count; i++)
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
        for (int i = 0; i < ((ASPxGridView)sender).Columns.Count; i++)
        {
            if (((ASPxGridView)sender).Columns[i] is GridViewDataColumn)
            {
                GridViewDataColumn col = ((ASPxGridView)sender).Columns[i] as GridViewDataColumn;
                if (ASPxHiddenField1.Contains(col.FieldName))
                {
                    string sortOrder = ASPxHiddenField1.Get(col.FieldName).ToString();
                    if (sortOrder == "A")
                    {
                        col.SortAscending();
                    }
                    else
                    {
                        col.SortDescending();
                    }
                }
            }
        }
    }
}
