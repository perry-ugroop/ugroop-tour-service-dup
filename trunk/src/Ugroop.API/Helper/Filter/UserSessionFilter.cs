﻿using Newtonsoft.Json.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using Ugroop.API.Controllers;
using Ugroop.API.Helper.Json;
using UGroopData.Mongo.Service.UGroopWeb.Interface;

namespace Ugroop.API.Helper.Filter {
    public class UserSessionFilter : ActionFilterAttribute {

        private string UserSessionKey;
        private IAccountService _accountService;

        public override void OnActionExecuting(HttpActionContext actionContext) {
            var jsonData = (JObject)actionContext.ActionArguments["jsonData"];
            var idAccount = JsonData.Instance(jsonData).Get_JsonObject("id");
            UserSessionKey = JsonData.Instance(jsonData).Get_JsonObject("UserSessionKey").ToString();

            var baseController = ((BaseController)actionContext.ControllerContext.Controller);
            _accountService = baseController.AccountService;

            var result = _accountService.Validate_UserSession(UserSessionKey);
            if (result == false) {
                var response = actionContext.Request.CreateErrorResponse(HttpStatusCode.Unauthorized, "Invalid User Session.");
                actionContext.Response = response;
                //throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.Unauthorized));
            }
            base.OnActionExecuting(actionContext);
        }

    }
}