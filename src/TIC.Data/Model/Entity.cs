namespace BBWM.Core.Data
{
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Base class for all entities
    /// </summary>
    public abstract class Entity
    {
        /// <summary>
        /// Entity identity field
        /// </summary>
        [Key]
        public int Id { get; set; }
    }
}
