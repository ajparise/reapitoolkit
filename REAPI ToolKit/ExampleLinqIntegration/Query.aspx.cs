using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ExampleLinqIntegration
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (RaisersEdge.API.ToolKit.Managed.Entities.Query.QueryExists(TextBox1.Text))
            {
                GridView1.DataBind();
            }

        }
    }
}
