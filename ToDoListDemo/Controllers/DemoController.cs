using DanDemoCrud1.Models;
using DanDemoCrud1.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DanDemoCrud1.Controllers
{
    [RoutePrefix("api/demo")]
    public class DemoController : ApiController
    {
        readonly IDemoDataService demoDataService;

        public DemoController(IDemoDataService demoDataService)
        {
            this.demoDataService = demoDataService;
        }

        [Route("message"), HttpGet]
        public object GetMessage()
        {
            return new DemoDataService().GetAllMessages();
        }

        [Route, HttpPost]
        public int InsertMessages(InsertMessages model)
        {
            return new DemoDataService().InsertMessages(model);
        }
        [Route("{Id:int}"), HttpPut]
        public void UpdateMessages(UpdateMessages model)
        {
            new DemoDataService().UpdateMessages(model);
        }
        [Route("{Id:int}"), HttpDelete]
        public void DeleteMessages(int Id)
        {
            new DemoDataService().Delete(Id);
        }
    }
}
