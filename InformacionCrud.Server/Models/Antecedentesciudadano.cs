using System;
using System.Collections.Generic;

namespace InformacionCrud.Server.Models;

/// <summary>
/// registro del ciudadano
/// </summary>
public partial class Antecedentesciudadano
{
    /// <summary>
    /// identificador del registro
    /// </summary>
    public int Idantecedentesciudadano { get; set; }

    public int? Ciudadano { get; set; }

    public int? Delitos { get; set; }

    public int? Tiposdelitos { get; set; }

    public int? Detenciones { get; set; }

    public DateOnly? Fechadelito { get; set; }

    public int? Penaimpuesta { get; set; }

    public ulong? Estado { get; set; }

    public virtual Ciudadano? CiudadanoNavigation { get; set; }

    public virtual Delito? DelitosNavigation { get; set; }

    public virtual Detencione? DetencionesNavigation { get; set; }

    public virtual Penaimpuestum? PenaimpuestaNavigation { get; set; }

    public virtual Tiposdelito? TiposdelitosNavigation { get; set; }
}
