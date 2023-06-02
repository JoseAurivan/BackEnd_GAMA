namespace Core.Entities
{
    public class Cargo
    {
        public Cargo()
        {

        }
        public int Id { get; set; }
        public string Nome { get; private set; }
        public float Salario { get; private set; }

        public Hierarquia Hierarquia { get; private set; }
    }

    public enum Hierarquia
    {
        Prefeito,
        Secretario,
        Diretor,
        Coordenador,
        Funcionario
    }
}