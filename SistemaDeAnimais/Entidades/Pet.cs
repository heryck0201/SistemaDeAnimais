namespace SistemaDeAnimais.Entidades
{
    public class Pet
    {
        public Pet(int id, string nome, string raca, string cor, string porte)
        {
            Id = id;
            Nome = nome;
            Raca = raca;
            Cor = cor;
            Porte = porte;
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public string Raca { get; set; }
        public string Cor { get; set; }
        public string Porte { get; set; }
        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }
    }
}
