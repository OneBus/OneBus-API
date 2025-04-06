using OneBus.Domain.Enums;
using System.ComponentModel;

namespace OneBus.Domain.Filters
{
    public abstract class BaseFilter
    {
        private ulong _companyId;

        protected BaseFilter()
        {
            OrderField = "id";
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

        public OrderBy OrderBy { get; set; }

        public void SetCompanyId(ulong companyId)
        {
            _companyId = companyId;
        }

        public ulong GetCompanyId()
        {
            return _companyId;
        }
    }
}
