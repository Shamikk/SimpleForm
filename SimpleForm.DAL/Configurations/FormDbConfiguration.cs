using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SimpleForm.BLL;

namespace SimpleForm.DAL.Configurations
{
    public class FormDbConfiguration : IEntityTypeConfiguration<Form>
    {
        public void Configure(EntityTypeBuilder<Form> builder)
        {
            builder.ToTable(typeof(Form).Name);
            builder.HasKey(k => k.Id);
            builder.HasOne(u => u.Sender)
                .WithMany(f => f.FormsSent)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
