using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyFirstMVC.Models;

namespace MyFirstMVC.Data.Map
{
    public class GameMap : IEntityTypeConfiguration<GamesModel>
    {
        public void Configure(EntityTypeBuilder<GamesModel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.Usuario);
        }
    }
}
