using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

/// <summary>
/// This provides a nice place to provide functionality to all pages that extend this page.
/// </summary>
public class BasePage : System.Web.UI.Page
{
    //**** Per-page variables and methods
    protected bool NoLoginRequired = false;
    protected string Referrer
    {
        get
        {
            if (Session["LastReferrer"] == null)
                Session["LastReferrer"] = "";
            return Session["LastReferrer"].ToString();
        }
        set { Session["LastReferrer"] = value; }
    }

    /// <summary>
    /// A "Person" variable for demonstrating logins
    /// </summary>
    protected string Person
    {
        get
        {
            if (Session["LoginPerson"] == null)
                return null;
            return Session["LoginPerson"].ToString();
        }
        set { Session["LoginPerson"] = value; }
    }

    protected override void OnPreInit(EventArgs e)
    {
        //Enforce our login policy
        if (!NoLoginRequired && Person == null)
            SendToLogin();
        
        base.OnPreInit(e);

        // Prevent CSRF attacks.
        ViewStateUserKey = Session.SessionID;
    }

    protected override void OnLoad(EventArgs e)
    {
        //Track our referrers between pages
        if (Request.UrlReferrer == null)
            Referrer = "";
        else if (!this.IsPostBack)
            Referrer = Request.UrlReferrer.ToString();

        base.OnLoad(e);
    }

    //****Getting current page URLs
    public string BaseUrl
    {
        get
        {
            string url = this.Request.ApplicationPath;
            if (url.Length > 1)
                return url;
            else
                return "";
        }
    }

    public string FullBaseUrl
    {
        get
        {
            return this.Request.Url.AbsoluteUri.Replace(this.Request.Url.PathAndQuery, "") + this.BaseUrl;
        }
    }

    public string FullCurrentUrl
    {
        get
        {
            if (UsingOpenSite)
            {
                //Make it an Open url
                string front = this.Request.Url.ToString().Replace(FullBaseUrl, "");
                string back = FullBaseUrl.Replace(front, "");
                string url = back + "/open" + front;
                return url;
            }
            return this.Request.Url.ToString();
        }
    }

    //****Site State and Roots
    public static bool UsingOpenSite
    {
        get
        {
            if (HttpContext.Current.Request.RawUrl.Contains("/open")
                || (HttpContext.Current.Request.UrlReferrer != null
                    && HttpContext.Current.Request.UrlReferrer.OriginalString.Contains("/open")))
                return true;
            return false;
        }
    }

    /// <summary>
    /// Made to work with rewrites
    /// </summary>
    public static string SiteRoot
    {
        get
        {
            if (UsingOpenSite)
                return VirtualPathUtility.ToAbsolute("~/open/");
            else
                return VirtualPathUtility.ToAbsolute("~/");
        }
    }

    /// <summary>
    /// Doesn't change regardless of rewrites
    /// </summary>
    public static string TrueSiteRoot
    {
        get
        {
            return VirtualPathUtility.ToAbsolute("~/");
        }
    }

    //****Redirection
    public void SendToLogin()
    {
        Response.Redirect(SiteRoot + "login/login.aspx", true);
    }

    public void BackToReferrerOrLocalIndex()
    {
        if (Referrer.Length > 0)
            Response.Redirect(Referrer, true);
        else
            BackToLocalIndex();
    }

    public void BackToReferrerOrRootIndex()
    {
        if (Referrer.Length > 0)
            Response.Redirect(Referrer, true);
        else
            BackToRootIndex();
    }

    public void BackToLocalIndex()
    {
        //Build a nice clean relative url based on our current url.
        string newurl = FullCurrentUrl;
        newurl = newurl.Substring(0, newurl.LastIndexOf("/")) + "/Default.aspx";
        Response.Redirect(newurl, true);
    }

    public void BackToRootIndex()
    {
        Response.Redirect(SiteRoot + "Default.aspx", true);
    }

    public void BackToPageInSameDir(string page)
    {
        //Build a nice clean relative url based on our current url.
        string newurl = FullCurrentUrl;
        newurl = newurl.Substring(0, newurl.LastIndexOf("/")) + "/" + page;
        Response.Redirect(newurl, true);
    }
}