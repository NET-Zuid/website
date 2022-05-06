using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;

using AutoMapper;

using DNZ.Common.Models;
using DNZ.Common.TableEntities;

namespace DNZ.API.Functions
{
    public class GetContentFunction
    {
        #region Fields

        private readonly IMapper _mapper;

        #endregion

        #region Constructor

        public GetContentFunction(IMapper mapper)
        {
            _mapper = mapper;
        }

        #endregion

        [FunctionName(nameof(GetContentFunction))]
        public IActionResult Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "content/{name}")] HttpRequest req,
            [Table("Content", ContentEntity.PARTITION_KEY, "{name}")] ContentModel content)
        {
            return new OkObjectResult(_mapper.Map<ContentModel>(content));
        }
    }
}
