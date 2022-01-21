using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Rubrica.Core.Entities;

namespace Rubrica.RepositoryEF
{
    internal class IndirizzoConfiguration : IEntityTypeConfiguration<Indirizzo>
    {
        public void Configure(EntityTypeBuilder<Indirizzo> builder)
        {
            builder.ToTable("Indirizzo");
            builder.HasKey(i=>i.IndirizzoID);
            builder.Property(i => i.Tipologia).IsRequired();
            builder.Property(i=>i.Nazione).IsRequired();
            builder.Property(i=>i.Citta).IsRequired();
            builder.Property(i=>i.Via).IsRequired();
            builder.Property(i => i.Cap).IsRequired().IsFixedLength().HasMaxLength(5);

            builder.HasOne(c=> c.Contatto).WithMany(i=>i.Indirizzi).HasForeignKey(c=>c.ContattoID);
                

        }
    }
}