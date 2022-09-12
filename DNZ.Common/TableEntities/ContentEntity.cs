using System.Runtime.Serialization;

namespace DNZ.Common.TableEntities
{
    public class ContentEntity : BaseTableEntity
    {
        #region Constants

        public const string PARTITION_KEY = "content";

        #endregion

        #region Properties

        public string Description { get; set; }

        public string HtmlContent { get; set; }

        [IgnoreDataMember]
        public string Name
        {
            get => RowKey;
            set => RowKey = value;
        }

        public string Title { get; set; }

        public bool ShowTitle { get; set; } = true;

        #endregion

        #region Constructors

        public ContentEntity()
        {
            PartitionKey = PARTITION_KEY;
        }

        #endregion
    }
}
