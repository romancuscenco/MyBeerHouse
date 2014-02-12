using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Web.Caching;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MB.TheBeerHouse.UI
{
    public static class Helpers
    {
        public static string[] GetThemes()
        {
            if (HttpContext.Current.Cache["SiteThemes"] != null)
            {
                return (string[])HttpContext.Current.Cache["SiteThemes"];
            }
            else
            {
                string themesDirPath = HttpContext.Current.Server.MapPath("~/App_Themes");

                string[] themes = Directory.GetDirectories(themesDirPath);

                for (int i = 0; i <= themes.Length - 1; i++)
                {
                    themes[i] = Path.GetFileName(themes[i]);
                }

                //cache the array with a dependency to the folder
                CacheDependency dep = new CacheDependency(themesDirPath);
                HttpContext.Current.Cache.Insert("SiteThemes", themes, dep);

                return themes;
            }
        }

        public static void SetInputControlsHighlight(Control container, string className, bool onlyTextBoxes)
        {
            foreach (Control ctl in container.Controls)
            {
                if ((onlyTextBoxes && ctl is TextBox) || ctl is TextBox || ctl is DropDownList || ctl is ListBox || ctl is CheckBox ||
                    ctl is RadioButton || ctl is RadioButtonList || ctl is CheckBoxList)
                {
                    WebControl wctl = ctl as WebControl;
                    wctl.Attributes.Add("onfocus", string.Format("this.className = '{0}';", className));
                    wctl.Attributes.Add("onblur", "this.className = '';");
                }
                else
                {
                    if (ctl.Controls.Count > 0)
                    {
                        SetInputControlsHighlight(ctl, className, onlyTextBoxes);
                    }
                }
            }
        }
    }
}