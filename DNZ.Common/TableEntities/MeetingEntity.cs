using System;
using System.Runtime.Serialization;

using DNZ.Common.Helpers;


namespace DNZ.Common.TableEntities
{
    public class MeetingEntity : BaseTableEntity
    {
        #region Fields

        private string _headline;
        private DateTime _startDateTime;

        #endregion

        #region Properties

        [IgnoreDataMember]
        public string Slug
        { 
            get => RowKey;
            set => RowKey = value;
        }

        public string Headline 
        { 
            get => _headline;
            set
            {
                _headline = value;
                Slug = SlugHelper.GenerateSlug(value);
            }
        }

        public string Description { get; set; }

        public string Speaker { get; set; }

        public string ImageUrl { get; set; }

        public DateTime StartDateTime 
        { 
            get => _startDateTime;
            set
            {
                _startDateTime = value;
                PartitionKey = value.Year.ToString();
            }
        }

        public DateTime EndDateTime { get; set; }

        public string Address { get; set; }

        public int SubscriptionLimit { get; set; }

        #endregion
    }
}
