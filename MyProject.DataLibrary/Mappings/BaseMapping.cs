using System.Data.Entity.ModelConfiguration;
using Identity.DataLibrary.Models;

namespace Identity.DataLibrary.Mappings
{
    public abstract class BaseMapping<TEntity> : EntityTypeConfiguration<TEntity>
        where TEntity : BaseModel
    {
        protected BaseMapping()
        {
            HasKey(e => e.Id);
        }
    }
}