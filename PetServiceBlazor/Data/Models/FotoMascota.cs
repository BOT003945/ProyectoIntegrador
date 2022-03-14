using System;
using System.Collections.Generic;

namespace PetServiceBlazor.Data.Models
{
    public partial class FotoMascota
    {
        public FotoMascota()
        {
            Mascota = new HashSet<Mascota>();
        }

        public int IdFotoMascota { get; set; }
        public string Foto1 { get; set; } = null!;
        public string? Foto2 { get; set; }
        public string? Foto3 { get; set; }

        public virtual ICollection<Mascota> Mascota { get; set; }
    }
}
