using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MoveHome.Model;

[System.ComponentModel.DataAnnotations.Table("tbFilme")]
public partial class TbFilme
{
    [Key]
    public int IdFilme { get; set; }

    [StringLength(200)]
    [Unicode(false)]
    public string NomeFilme { get; set; } = null!;

    public int Classific { get; set; }

    [System.ComponentModel.DataAnnotations.Column(TypeName = "date")]
    public DateTime DataLanc { get; set; }

    [StringLength(60)]
    [Unicode(false)]
    public string Idioma { get; set; } = null!;

    public int? IdGenero { get; set; }

    public int? IdDiretor { get; set; }

    public int? IdAtor { get; set; }

    [System.ComponentModel.DataAnnotations.ForeignKey("IdAtor")]
    [System.ComponentModel.DataAnnotations.InverseProperty("TbFilmes")]
    public virtual TbAtor? IdAtorNavigation { get; set; }

    [System.ComponentModel.DataAnnotations.ForeignKey("IdDiretor")]
    [System.ComponentModel.DataAnnotations.InverseProperty("TbFilmes")]
    public virtual TbDiretor? IdDiretorNavigation { get; set; }

    [System.ComponentModel.DataAnnotations.ForeignKey("IdGenero")]
    [System.ComponentModel.DataAnnotations.InverseProperty("TbFilmes")]
    public virtual TbGenero? IdGeneroNavigation { get; set; }
}
