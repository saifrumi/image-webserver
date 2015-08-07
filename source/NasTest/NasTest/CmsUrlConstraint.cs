using System.Web;
using System.Web.Routing;

namespace NasTest
{
    public class CmsUrlConstraint : IRouteConstraint
    {
        public bool Match(HttpContextBase httpContext, Route route, string parameterName, RouteValueDictionary values, RouteDirection routeDirection)
        {
            return false;
            //if (values[parameterName] == null)
            //    return true;

            //var sysContex = DbUtil.SysDbContext;
            //var permalink = values[parameterName].ToString();
            ////if (!permalink.ToLower().Contains("page/"))
            ////    permalink = "Page/" + permalink;

            //var domain = sysContex.ClientDomains.SingleOrDefault(cd => cd.DomainName == HttpContext.Current.Request.Url.Host);
            //if (domain == null)
            //    return false;

            //var context = DbUtil.CrsDbContext;
            //return context.Contents.Any(c => c.RoutePath.ToLower() == permalink.ToLower() && c.StatusID == (int)EnumCollection.ContentStatusEnum.Published && c.ClientID == domain.ClientID);//
        }
    }
}