using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace SistemaDeAnimais.Entidades
{
    public class Pet
    {
       
        [Key]
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Raca { get; set; }
        public string Cor { get; set; }
        public string Porte { get; set; }
        public int? UsuarioId { get; set; }
        [JsonIgnore]
        public virtual Usuario? Usuario { get; set; }
    }
}
