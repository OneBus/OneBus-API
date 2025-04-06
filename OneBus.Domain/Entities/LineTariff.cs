namespace OneBus.Domain.Entities
{
    public class LineTariff : BaseEntity
    {
        public ulong LineId { get; set; }

        public decimal Price { get; set; }

        public ushort NumberTickets { get; set; }

        public Line? Line { get; set; }

        public ICollection<LineTariffAudit>? LineTariffAudits { get; set; }
    }
}
