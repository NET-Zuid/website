using System;
using System.Threading.Tasks;
using System.Collections.Generic;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Cosmos.Table;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;

using AutoMapper;

using DNZ.Common.Models;
using DNZ.Common.TableEntities;

namespace DNZ.API.Functions
{
    public class GetMeetingsFunction
    {
        #region Fields

        private readonly IMapper _mapper;

        #endregion

        #region Constructors

        public GetMeetingsFunction(IMapper mapper)
        {
            _mapper = mapper;
        }

        #endregion

        [FunctionName("GetMeetingsFunction")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "meetings")] HttpRequest req,
            [Table("meetings", Connection = "storageConnectionString")] CloudTable cloudTable,
            ILogger log)
        {
            var entities = new List<MeetingEntity>();
            TableQuerySegment<MeetingEntity> querySegment = null;
            var query = new TableQuery<MeetingEntity>().Where(TableQuery.GenerateFilterCondition(nameof(ITableEntity.PartitionKey), QueryComparisons.Equal, DateTime.Now.Year.ToString()));

            do
            {
                querySegment = await cloudTable.ExecuteQuerySegmentedAsync(query, querySegment?.ContinuationToken);
                entities.AddRange(querySegment.Results);
            } while (querySegment.ContinuationToken != null);


            return new OkObjectResult(entities);
        }
    }
}
