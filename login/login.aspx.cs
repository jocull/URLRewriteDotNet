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

public partial class login_login : BasePage
{
    protected override void OnPreInit(EventArgs e)
    {
        //Login is not enforced for this page.
        NoLoginRequired = true;

        //Next, run the PreInit for our BasePage
        base.OnPreInit(e);
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        
    }
    protected void btnLogin_Click(object sender, EventArgs e)
    {
        Person = txtUsername.Text;
        BackToRootIndex();
    }
}
