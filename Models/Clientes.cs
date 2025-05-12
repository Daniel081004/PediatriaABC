using System;
using System.Collections.Generic;

namespace PediatriaABC.Models;

public partial class Clientes
{
    public int Id { get; set; }

    public string NombreTutor { get; set; } = null!;

    public string NombreHijo { get; set; } = null!;

    public DateOnly FechaNacimientoHijo { get; set; }

    public string? Telefono { get; set; }

    public string Direccion { get; set; } = null!;

    public DateOnly FechaRegistro { get; set; }
}
