using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Demo.Desktop.Model.Entities;

namespace Demo.Desktop.Model.Configurations
{
    public class SettingConfiguration : IEntityTypeConfiguration<Setting>
    {
        public void Configure(EntityTypeBuilder<Setting> builder)
        {
            builder.HasData(
                new Setting()
                {
                    Id = new Guid("63973A67-52C8-43A5-A196-457FA16074B6"),
                    DemoServerBaseUrl = "https://localhost:7111/api/",
                }
            );
        }
    }
}
