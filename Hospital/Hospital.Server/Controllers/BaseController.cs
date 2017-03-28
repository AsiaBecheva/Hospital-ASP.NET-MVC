namespace Hospital.Server.Controllers
{
    using Data.Repository;
    using DatabaseModels;
    using System.Web.Mvc;
    using System;
    using System.Web.Routing;
    using System.Linq;

    public class BaseController : Controller
    {
        protected IUnitOfWork Data { get; private set; }
        protected User UserProfile { get; private set; }
        
        public BaseController(IUnitOfWork data)
        {
            this.Data = data;
        }

        protected override IAsyncResult BeginExecute(RequestContext requestContext, AsyncCallback callback, object state)
        {
            if (requestContext.HttpContext.User.Identity.IsAuthenticated)
            {
                this.UserProfile = this.Data.Users.All().Where(x => x.UserName == requestContext.HttpContext.User.Identity.Name).FirstOrDefault();
            }

            return base.BeginExecute(requestContext, callback, state);
        }
    }
}