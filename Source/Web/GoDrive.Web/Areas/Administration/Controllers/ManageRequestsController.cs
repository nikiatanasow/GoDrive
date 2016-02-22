﻿namespace GoDrive.Web.Areas.Administration.Controllers
{
    using System.Linq;
    using System.Web.Mvc;
    using System.Web.Mvc.Expressions;
    using Common;
    using Infrastructure.Mapping;
    using Services.Data.Contracts;
    using ViewModels.OrganizationRequests;
    using Web.Controllers;

    public class ManageRequestsController : BaseController
    {
        private ICreateOrganizationRequestsService createOrganizationRequests;

        public ManageRequestsController(ICreateOrganizationRequestsService createOrganizationRequests)
        {
            this.createOrganizationRequests = createOrganizationRequests;
        }

        public ActionResult Index()
        {
            return this.View();
        }

        public ActionResult GetUnProceedRequest()
        {
            var requests = this.createOrganizationRequests
                .GetUnProceededRequests()
                .To<CreateOrganizationRequestViewModel>()
                .ToList();

            return this.PartialView(GlobalConstants.OrganizationOwnerRoleName, requests);
        }

        public ActionResult GetProceedRequest()
        {
            var requests = this.createOrganizationRequests
                .GetProceededRequests()
                .To<CreateOrganizationRequestViewModel>()
                .ToList();

            return this.PartialView(GlobalConstants.OrganizationOwnerRoleName, requests);
        }

        public ActionResult ProceedRequest(int id)
        {
            this.createOrganizationRequests.ProceedRequest(id);
            return this.RedirectToAction(x => x.Index());
        }
    }
}
