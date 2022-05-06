using Microsoft.Azure.Cosmos.Table;

namespace DNZ.Common.TableEntities
{
    public class ContentEntity : TableEntity
    {
        #region Constants

        public const string PARTITION_KEY = "content";

        #endregion

        #region Properties

        public string Description { get; set; }

        public string HtmlContent { get; set; }

        [IgnoreProperty]
        public string Name
        {
            get => RowKey;
            set => RowKey = value;
        }

        public string Title { get; set; }

        #endregion

        #region Constructors

        public ContentEntity()
        {
            PartitionKey = PARTITION_KEY;
        }

        #endregion
    }
}
