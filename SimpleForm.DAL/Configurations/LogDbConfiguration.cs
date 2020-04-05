using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SimpleForm.BLL;

namespace SimpleForm.DAL.Configurations
{
    public class LogDbConfiguration : IEntityTypeConfiguration<Log>
    {
        public void Configure(EntityTypeBuilder<Log> builder)
        {
            builder.ToTable(typeof(Log).Name);
        }
    }
}
