using System;
using System.Collections.Generic;

namespace InformacionCrud.Server.Models;

/// <summary>
/// informacion del ciudadano
/// </summary>
public class Ciudadano
{
    /// <summary>
    /// identificador del ciudadano
    /// </summary>
    public int Idciudadano { get; set; }

    /// <summary>
    /// nombre del ciudadano
    /// </summary>
    public string? Nombre { get; set; }

    /// <summary>
    /// apellido del ciudadano
    /// </summary>
    public string? Apellido { get; set; }

    /// <summary>
    /// fecha del ciudadano
    /// </summary>
    public DateOnly? Fechanacimiento { get; set; }

    /// <summary>
    /// identificador del ciudadano
    /// </summary>
    public string? Dui { get; set; }

    public int? Tiposciudadanos { get; set; }

    public int? Nacionalidad { get; set; }

    public int? Tipodedocumento { get; set; }

    public string? Telefonofijio { get; set; }

    public string? Telefonomovil { get; set; }

    public string? Correoelectronico { get; set; }

    public string? Direccionciudadano { get; set; }

    public int? Bienes { get; set; }

    public byte? Estado { get; set; }

    public virtual Biene? BienesNavigation { get; set; }

    public virtual Nacionalidad? NacionalidadNavigation { get; set; }

    public virtual Tipodocumento? TipodedocumentoNavigation { get; set; }

    public virtual Tiposciudadano? TiposciudadanosNavigation { get; set; }


    // Nel

    public virtual ICollection<Antecedentesciudadano> Antecedentesciudadanos { get; set; } = new List<Antecedentesciudadano>();

    public virtual ICollection<Antecedentespenale> Antecedentespenales { get; set; } = new List<Antecedentespenale>();

    public virtual ICollection<Arrestopolicial> Arrestopolicials { get; set; } = new List<Arrestopolicial>();

    public virtual ICollection<Documentosciudadano> Documentosciudadanos { get; set; } = new List<Documentosciudadano>();

    public virtual ICollection<Historiallaboral> Historiallaborals { get; set; } = new List<Historiallaboral>();

    public virtual ICollection<Historialmedico> Historialmedicos { get; set; } = new List<Historialmedico>();

    public virtual ICollection<Historialmigratorio> Historialmigratorios { get; set; } = new List<Historialmigratorio>();

    public virtual ICollection<Informacionacademica> Informacionacademicas { get; set; } = new List<Informacionacademica>();

    public virtual ICollection<Informacionfinanciera> Informacionfinancieras { get; set; } = new List<Informacionfinanciera>();

    public virtual ICollection<Infraccionesciudadano> Infraccionesciudadanos { get; set; } = new List<Infraccionesciudadano>();

    public virtual ICollection<Victima> Victimas { get; set; } = new List<Victima>();
}
