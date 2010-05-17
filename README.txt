This is an example using UrlRewriter for ASP.NET.

It is available here with documentation: http://urlrewriter.net/

To view the the rewriter in action, try these two URLS (where "~" is your site's root):

~/Default.aspx
~/open/Default.aspx

In either case, you should be forced to login (simply enter a name). 

Between links, post backs, and redirects, you should maintain the same base directory.



***IMPORTANT NOTE***:

Because non-ASP.NET content is not processed, it does not recieve any URL rewriting. When referencing this content (css, js, images, etc...) it's important to use the "TrueSiteRoot" as specified in the BasePage class.

Without using this variable, you'll find yourself having dead links to content when navigating through the /open/ directory.