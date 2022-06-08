using System.Linq;
using System.Collections.Generic;

using Azure.Data.Tables;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;

using AutoMapper;

using DNZ.Common.Models;
using DNZ.Common.TableEntities;

namespace DNZ.API.Functions
{
    public class GetMeetings
    {
        #region Fields

        private readonly IMapper _mapper;

        #endregion

        #region Constructors

        public GetMeetings(IMapper mapper)
        {
            _mapper = mapper;
        }

        #endregion

        [FunctionName(nameof(GetMeetings))]
        public IActionResult Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "meetings")] HttpRequest req,
            [Table("meetings", Connection = "storageConnectionString")] TableClient tableClient,
            ILogger log)
        {
            var meetings = tableClient.Query<MeetingEntity>().OrderByDescending(o => o.StartDateTime).ToList();

            return new OkObjectResult(_mapper.Map<List<MeetingModel>>(meetings));
        }
    }
}
