using System.ComponentModel.DataAnnotations;

namespace SistemaDeAnimais.Entidades
{
    public class Usuario
    {

        [Key]
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string? Email { get; set; }
        public virtual IEnumerable<Pet> Pet { get; set; }
    }
}
