using System;
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

public partial class _Default : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //Setting the true root for our CSS
        MainStylesheet.Href = TrueSiteRoot + "css/styles.css";

        //Welcoming the user
        lblOutput.Text = "Hey there, <strong>" + Person + "</strong>! ";
        //...and detecting their site
        if(UsingOpenSite)
            lblOutput.Text += "You seem to be using the <strong style=\"font-size:200%;\">open site</strong>! That's fancy!";
        else
            lblOutput.Text += "How is the plain original site treating you?";
    }
}
