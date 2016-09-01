using StartIdea.Model.ScrumEventos;
using System.Data.Entity.ModelConfiguration;

namespace StartIdea.DataAccess.ModelMapping.ScrumEventos
{
    public class RetrospectivaSprintMap : EntityTypeConfiguration<RetrospectivaSprint>
    {
        public RetrospectivaSprintMap()
        {
            Property(x => x.Local)
                .HasMaxLength(50)
                .IsRequired();
        }
    }
}