namespace Core.Entities
{
    public class Cargo
    {
        public Cargo()
        {
            
        }

        public Cargo(string nome, float salario, Hierarquia hierarquia)
        {
            Nome = nome;
            Salario = salario;
            Hierarquia = hierarquia;
        }

        public int Id { get; set; }

        public string Nome { get;  set; }
        public float Salario { get;  set; }

        public Hierarquia Hierarquia { get;  set; }
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