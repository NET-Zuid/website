using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;

using DNZ.Common.Models;
using DNZ.Common.TableEntities;

namespace DNZ.API.Functions
{
    public static class GetMeetingFunction
    {
        [FunctionName("GetMeetingFunction")]
        public static IActionResult Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "meetings/{partitionKey}/{rowKey}")] HttpRequest req,
            [Table("meetings", "{partitionKey}", "{rowKey}", Connection = "storageConnectionString")] MeetingEntity meetingEntity)
        {
            return new OkObjectResult(meetingEntity);
        }
    }
}
