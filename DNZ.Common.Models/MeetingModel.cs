using System;

namespace DNZ.Common.Models
{
    public class MeetingModel
    {
        public string Year { get; set; }

        public string Slug { get; set; }

        public string Headline { get; set; }

        public string Description { get; set; }

        public string Speaker { get; set; }

        public string ImageUrl { get; set; }

        public DateTime StartDateTime { get; set; }

        public DateTime EndDateTime { get; set; }

        public string Address { get; set; }

        public int SubscriptionLimit { get; set; }
    }
}
