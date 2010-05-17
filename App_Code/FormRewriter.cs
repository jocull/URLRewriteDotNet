using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.IO;

/// <summary>
/// This class handles using ASP.NET forms and postbacks with URL rewriting.
/// Without it, pages will not post back to their rewritten URLs.
/// 
/// EXAMPLE:
/// 1. User goes to ~/open/login/login.aspx
/// 2. User posts back
/// 3. User is redirected to ~/login/login.aspx, and url rewriting is lost
/// 
/// Much of this was taken from this article on URL Rewriting in ASP.NET:
/// http://weblogs.asp.net/scottgu/archive/2006/11/29/tip-trick-use-the-asp-net-2-0-css-control-adapters-for-css-friendly-html-output.aspx
/// 
/// This class was converted from the Visual Basic example.
/// </summary>
public class FormRewriterControlAdapter : System.Web.UI.Adapters.ControlAdapter
{
    protected override void Render(HtmlTextWriter writer)
    {
        base.Render(new RewriteFormHtmlTextWriter(writer));
    }
}

public class RewriteFormHtmlTextWriter : HtmlTextWriter
{
    public RewriteFormHtmlTextWriter(HtmlTextWriter writer) : base(writer)
    {
        InnerWriter = writer;
    }

    public override void WriteAttribute(string name, string value, bool fEncode)
    {
        //' If the attribute we are writing is the "action" attribute, and we are not on a sub-control, 
        //' then replace the value to write with the raw URL of the request - which ensures that we'll
        //' preserve the PathInfo value on postback scenarios
        if (name == "action")
        {
            HttpContext Context = HttpContext.Current;
            //' Because we are using the UrlRewriting.net HttpModule, we will use the 
            //' Request.RawUrl property within ASP.NET to retrieve the origional URL
            //' before it was re-written.  You'll want to change the line of code below
            //' if you use a different URL rewriting implementation.
            if (Context.Items["ActionAlreadyWritten"] == null)
            {
                //' Indicate that we've already rewritten the <form>'s action attribute to prevent
                //' us from rewriting a sub-control under the <form> control
                value = Context.Request.RawUrl;
                Context.Items["ActionAlreadyWritten"] = true;
            }
        }

        base.WriteAttribute(name, value, fEncode);
    }
}