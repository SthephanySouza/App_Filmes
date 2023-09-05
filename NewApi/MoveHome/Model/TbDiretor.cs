using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MoveHome.Model;

[System.ComponentModel.DataAnnotations.Table("tbDiretor")]
public partial class TbDiretor
{
    [Key]
    public int IdDiretor { get; set; }

    [StringLength(200)]
    [Unicode(false)]
    public string NomeDiretor { get; set; } = null!;

    [StringLength(200)]
    [Unicode(false)]
    public string MaiorObra { get; set; } = null!;

    [System.ComponentModel.DataAnnotations.InverseProperty("IdDiretorNavigation")]
    public virtual ICollection<TbFilme> TbFilmes { get; set; } = new List<TbFilme>();
}
