using System;
using System.Collections.Generic;

namespace CleverWeb.Models;

public partial class ImovelProprietario
{
    public int Id { get; set; }

    public int? IdImovel { get; set; }

    public int? TipoPessoa { get; set; }

    public int? IdPessoa { get; set; }
}
