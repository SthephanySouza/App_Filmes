using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MoveHome.Model;

[System.ComponentModel.DataAnnotations.Table("tbGenero")]
public partial class TbGenero
{
    [Key]
    public int IdGenero { get; set; }

    [StringLength(200)]
    [Unicode(false)]
    public string NomeGenero { get; set; } = null!;

    [System.ComponentModel.DataAnnotations.InverseProperty("IdGeneroNavigation")]
    public virtual ICollection<TbFilme> TbFilmes { get; set; } = new List<TbFilme>();
}
