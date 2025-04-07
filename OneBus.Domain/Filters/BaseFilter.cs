using OneBus.Domain.Enums;
using System.ComponentModel;

namespace OneBus.Domain.Filters
{
    public abstract class BaseFilter
    {
        protected BaseFilter()
        {
            IsEnabled = true;
            CurrentPage = 1;
            PageSize = 15;
            OrderField = "id";
            OrderType = OrderType.Desc;
        }

        [DefaultValue(true)]
        public bool? IsEnabled { get; set; }

        public DateTime? StartDateTime { get; set; }

        public DateTime? EndDateTime { get; set; }

        [DefaultValue(1)]
        public uint CurrentPage { get; set; }

        [DefaultValue(15)]
        public uint PageSize { get; set; }

        [DefaultValue("id")]
        public string OrderField { get; set; }

        [DefaultValue(OrderType.Desc)]
        public OrderType OrderType { get; set; }       
    }
}
