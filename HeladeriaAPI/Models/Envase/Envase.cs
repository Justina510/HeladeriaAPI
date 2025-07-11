namespace HeladeriaAPI.Models.Envase
{
    public class Envase
    {
   
            public int Id { get; set; }
            public string Tipo { get; set; } = null!;           
            public string Descripcion { get; set; } = null!;         
            public decimal Precio { get; set; }
            public bool Comestible { get; set; }
            public bool Disponible { get; set; } 
        }
    }
    


