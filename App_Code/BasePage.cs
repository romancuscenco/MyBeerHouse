using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MB.TheBeerHouse;
using MB.TheBeerHouse.UI;

public class BasePage : System.Web.UI.Page
{
    protected override void OnPreInit(EventArgs e)
    {
        string id = Globals.ThemesSelectorID;

        if (id.Length > 0)
        {
            // if this is a postback caused by the theme selector's dropdownlist,
            // retrieve the selected theme and use it for the current page request
            if (this.Request.Form["__EVENTTARGET"] == id && !string.IsNullOrEmpty(this.Request.Form[id]))
            {
                this.Theme = this.Request.Form[id];
                this.Session["CurrentTheme"] = this.Theme;
            }
            else
            {
                // if not a postback, or a postback caused by controls other then
                // the theme selector, set the page's theme with the value found
                // in Session, if present
                if (this.Session["CurrentTheme"] != null)
                {
                    this.Theme = this.Session["CurrentTheme"].ToString();
                }
            }
        }

        base.OnPreInit(e);
    }

    protected override void OnLoad(EventArgs e)
    {
        // add onfocus and onblur javascripts to all input controls on the forum,
        // so that the active control has a difference appearance
        Helpers.SetInputControlsHighlight(this, "highlight", false);

        base.OnLoad(e);
    }
}