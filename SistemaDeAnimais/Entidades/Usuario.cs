namespace SistemaDeAnimais.Entidades
{
    public class Usuario
    {
        public Usuario(int id, string nome, string sobrenome, string? email)
        {
            Id = id;
            Nome = nome;
            Sobrenome = sobrenome;
            Email = email;
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string? Email { get; set; }
        public IEnumerable<Pet> Pet { get; set; }
    }
}
