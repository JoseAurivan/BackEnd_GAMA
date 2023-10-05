namespace Core.Entities
{
    public class DTOCargo
    {
        public DTOCargo()
        {
            Servidors = new List<DTOServidor>();
        }
        public int Id { get; set; }
        public string Nome { get;  set; }
        public float Salario { get;  set; }

        public Hierarquia Hierarquia { get;  set; }
        public ICollection<DTOServidor> Servidors { get; set; }

        public DTOCargo(string nome, float salario, Hierarquia hierarquia)
        {
            Nome = nome;
            Salario = salario;
            Hierarquia = hierarquia;
        }

        public DTOCargo(int id, string nome, float salario, Hierarquia hierarquia)
        {
            Id = id;
            Nome = nome;
            Salario = salario;
            Hierarquia = hierarquia;
        }

        public Cargo ConverterDTOParaModel(DTOCargo cargo)
        {
            return new Cargo(cargo.Id,cargo.Nome,cargo.Salario,cargo.Hierarquia);
        }
    }

}