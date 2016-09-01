using StartIdea.Model.ScrumArtefatos;
using System.Data.Entity.ModelConfiguration;

namespace StartIdea.DataAccess.ModelMapping.ScrumArtefatos
{
    public class StatusMap : EntityTypeConfiguration<Status>
    {
        public StatusMap()
        {
            Property(x => x.Descricao)
                .HasMaxLength(20)
                .IsRequired();
        }
    }
}