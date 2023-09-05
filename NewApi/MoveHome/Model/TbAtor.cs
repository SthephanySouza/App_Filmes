using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MoveHome.Model;

[System.ComponentModel.DataAnnotations.Table("tbAtor")]
public partial class TbAtor
{
    [Key]
    public int IdAtor { get; set; }

    [StringLength(200)]
    [Unicode(false)]
    public string NomeAtor { get; set; } = null!;

    [StringLength(200)]
    [Unicode(false)]
    public string ObraTrab { get; set; } = null!;

    [System.ComponentModel.DataAnnotations.InverseProperty("IdAtorNavigation")]
    public virtual ICollection<TbFilme> TbFilmes { get; set; } = new List<TbFilme>();
}
