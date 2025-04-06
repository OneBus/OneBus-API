using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OneBus.Domain.Entities;

namespace OneBus.Infra.Data.Mappings
{
    public class VehicleMapping : BaseEntityMapping<Vehicle>
    {
        public override void Configure(EntityTypeBuilder<Vehicle> builder)
        {
            builder.ToTable("Veiculo");
            base.Configure(builder);

            builder.Property(c => c.Renavam).HasMaxLength(20);
            builder.Property(c => c.Year).HasColumnName("Ano");
            builder.Property(c => c.Status).HasConversion<byte>();
            builder.Property(c => c.AxesNumber).HasColumnName("NumeroEixos");
            builder.Property(c => c.NumberDoors).HasColumnName("NumeroPortas");
            builder.Property(c => c.NumberSeats).HasColumnName("NumeroAssentos");
            builder.Property(c => c.Color).HasColumnName("Cor").HasMaxLength(30);
            builder.Property(c => c.Image).HasColumnName("Foto").HasMaxLength(20);
            builder.Property(c => c.Brand).HasColumnName("Marca").HasMaxLength(50);
            builder.Property(c => c.Plate).HasColumnName("Placa").HasMaxLength(15);
            builder.Property(c => c.Model).HasColumnName("Modelo").HasMaxLength(50);
            builder.Property(c => c.IpvaExpiration).HasColumnName("IpvaVencimento");
            builder.Property(c => c.AcquisitionDate).HasColumnName("DataAquisicao");
            builder.Property(c => c.Prefix).HasColumnName("Prefixo").HasMaxLength(30);
            builder.Property(c => c.Type).HasColumnName("Tipo").HasConversion<byte>();
            builder.Property(c => c.HasAccessibility).HasColumnName("TemAcessibilidade");
            builder.Property(c => c.EngineNumber).HasColumnName("NumeroMotor").HasMaxLength(20);
            builder.Property(c => c.NumberChassis).HasColumnName("NumeroChassi").HasMaxLength(20);
            builder.Property(c => c.LicensingExpiration).HasColumnName("LicenciamentoVencimento");
            builder.Property(c => c.FuelType).HasColumnName("TipoCombustivel").HasConversion<byte>();
            builder.Property(c => c.BodyworkNumber).HasColumnName("NumeroCarroceria").HasMaxLength(20);
            builder.Property(c => c.TransmissionType).HasColumnName("TipoTransmissao").HasConversion<byte>();

            builder.HasIndex(c => c.Plate);
            builder.HasIndex(c => c.Prefix);
            builder.HasIndex(c => c.Renavam); 
        }
    }
}
