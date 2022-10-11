using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SelfieAWookie.Core.Selfies.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelfieAWookie.Core.Selfies.Infrastructures.Data.TypeConfigurations
{
    class WookieEntityTypeConfiguration : IEntityTypeConfiguration<Wookie>
    {
        #region Public Methods
        public void Configure(EntityTypeBuilder<Wookie> builder)
        {
            builder.ToTable("Wookie");

            builder.HasKey(x => x.Id);
        }
        #endregion
    }
}
