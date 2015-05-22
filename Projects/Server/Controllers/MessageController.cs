using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace WebApiServer.Controllers
{
    public class MessageController : ApiController
    {
        [HttpPost]
        public async Task<HttpResponseMessage> Post(HttpRequestMessage request)
        {
            Model.Message message = new Model.Message(await request.Content.ReadAsStringAsync(), System.DateTime.Now);
            Services.ProcessService processService = new Services.ProcessService(message);
            Parallel.Invoke(
                new Action(processService.ProcessMessage)

                );
            return new HttpResponseMessage(HttpStatusCode.Created);
        }
    }
}