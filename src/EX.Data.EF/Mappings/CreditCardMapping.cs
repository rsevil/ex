using EX.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EX.Data.EF.Mappings
{
    public class CreditCardMapping : EntityTypeConfiguration<CreditCard>
    {
        public CreditCardMapping()
        {
            HasKey(x => x.Number);

            Property(x => x.Number)
                .IsUnicode(false)
                .IsRequired()
                .HasMaxLength(19)
                .IsFixedLength();

            Property(x => x.Pin)
                .IsUnicode(false)
                .IsRequired()
                .HasMaxLength(3)
                .IsFixedLength();
        }
    }
}
