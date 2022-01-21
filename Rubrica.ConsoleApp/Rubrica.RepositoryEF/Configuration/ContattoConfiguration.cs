using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Rubrica.Core.Entities;

namespace Rubrica.RepositoryEF
{
    internal class ContattoConfiguration : IEntityTypeConfiguration<Contatto>
    {
        public void Configure(EntityTypeBuilder<Contatto> builder)
        {
            builder.ToTable("Contatto");
            builder.HasKey(c=>c.ContattoID);
            builder.Property(c=>c.Nome).IsRequired();
            builder.Property(c=>c.Cognome).IsRequired();

            builder.HasMany(c => c.Indirizzi).WithOne(i => i.Contatto).HasForeignKey(i => i.ContattoID);

        }
    }
}