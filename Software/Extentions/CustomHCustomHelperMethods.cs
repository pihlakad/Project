﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Software.Extentions
{
    public static class CustomHCustomHelperMethods
    {
        public static MvcHtmlString Submit(this HtmlHelper helper, string displayText)
        {
            return MvcHtmlString.Create
                (
                string.Format("<input type='submit' name=Btn{0} id=Btn{0} value={0} />", displayText)
                );
        }
    }
}