using System.Web;
using System.Web.Mvc;
using APFTestingUI.Filters;

namespace APFTestingUI {
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            // Perhaps InitialiseSimpleMembership should be added here?
        }
    }
}