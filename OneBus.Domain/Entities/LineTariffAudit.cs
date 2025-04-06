namespace OneBus.Domain.Entities
{
    public class LineTariffAudit : BaseEntity
    {
        public ulong EmployeeId { get; set; }

        public ulong LineTariffId { get; set; }

        public ushort RemainingTicketsNumber { get; set; }

        public DateOnly Date { get; set; }

        public Employee? Employee { get; set; }

        public LineTariff? LineTariff { get; set; }
    }
}
