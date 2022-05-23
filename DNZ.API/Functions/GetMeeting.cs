using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;

using AutoMapper;

using DNZ.Common.Models;
using DNZ.Common.TableEntities;

namespace DNZ.API.Functions
{
    public class GetMeeting
    {
        #region Fields
        
        private readonly IMapper _mapper;

        #endregion

        #region Constructors

        public GetMeeting(IMapper mapper)
        {
            _mapper = mapper;
        }

        #endregion

        [FunctionName(nameof(GetMeeting))]
        public IActionResult Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "meetings/{partitionKey}/{rowKey}")] HttpRequest req,
            [Table("meetings", "{partitionKey}", "{rowKey}", Connection = "storageConnectionString")] MeetingEntity meetingEntity)
        {
            return new OkObjectResult(_mapper.Map<MeetingModel>(meetingEntity));
        }
    }
}
