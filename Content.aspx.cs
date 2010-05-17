using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

public partial class Content : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnGetMeOut_Click(object sender, EventArgs e)
    {
        //Using a Response.Redirect will lose our current URL rewritings, because
        //ASP.NET will base it off of the EXECUTION path, not the URL path.
        //Using these provided methods helps keep them straight.
        BackToLocalIndex();
    }
}
