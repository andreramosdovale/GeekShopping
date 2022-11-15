using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GeekShoping.ProductApi.Model.Base;

public class BaseEntity
{
    [Key]
    [Column("id")]
    public long id { get; set; }
}
