namespace Codesanook.EFNote.ConsoleApp
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Linq;

    public partial class Note
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Note()
        {
            Tags = new HashSet<Tag>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(512)]
        public string Title { get; set; }

        [Required]
        public string Content { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime CreatedUtc { get; set; }

        public DateTime? UpdatedUtc { get; set; }

        public bool IsDeleted { get; set; }

        public int ViewCount { get; set; }

        public int NotebookId { get; set; }

        public virtual Notebook Notebook { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tag> Tags { get; set; }

        public override string ToString()
        {
            return string.Join(
                Environment.NewLine,
                new[]{
                    $"{nameof(Id)}: {Id}",
                    $"{nameof(Title)}: {Title}",
                    $"{nameof(Content)}: {Content}",
                    $"{nameof(CreatedUtc)}: {CreatedUtc}",
                    $"{nameof(UpdatedUtc)}: {UpdatedUtc}",
                    $"{nameof(ViewCount)}: {ViewCount}",
                    $"{nameof(NotebookId)}: {NotebookId}",

                    $"Notebook name: {this.Notebook.Name}",
                    $"Tag names: {string.Join(", ", this.Tags.Select(t=>t.Name))}",
                }
            );
        }
    }
}
