using System.ComponentModel;

namespace Core.Entities
{
    public class Cargo
    {
        public Cargo()
        {
            Servidors = new List<Servidor>();
        }

        public Cargo(string nome, float salario, Hierarquia hierarquia)
        {
            Nome = nome;
            Salario = salario;
            Hierarquia = hierarquia;
        }

        public Cargo(int id, string nome, float salario, Hierarquia hierarquia)
        {
            Id = id;
            Nome = nome;
            Salario = salario;
            Hierarquia = hierarquia;
        }

        public int Id { get; set; }

        public string Nome { get;  set; }
        public float Salario { get;  set; }

        public Hierarquia Hierarquia { get;  set; }
        public ICollection<Servidor>? Servidors { get; set; }
    }

    public enum Hierarquia
    {
        [Description("Prefeito")]
        Prefeito,
        [Description("Secretario")]
        Secretario,
        [Description("Diretor")]
        Diretor,
        [Description("Coordenador")]
        Coordenador,
        [Description("Funcionario")]
        Funcionario
    }
}