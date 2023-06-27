namespace Core.Entities
{
    public class DTOCargo
    {
        public DTOCargo()
        {
            
        }
        public int Id { get; set; }
        public string Nome { get;  set; }
        public float Salario { get;  set; }

        public Hierarquia Hierarquia { get;  set; }

        public DTOCargo(string nome, float salario, Hierarquia hierarquia)
        {
            Nome = nome;
            Salario = salario;
            Hierarquia = hierarquia;
        }

        public Cargo ConverterDTOParaModel(DTOCargo cargo)
        {
            return new Cargo(cargo.Nome,cargo.Salario,cargo.Hierarquia);
        }
    }

}