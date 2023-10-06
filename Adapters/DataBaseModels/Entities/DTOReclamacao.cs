namespace Core.Entities
{
    public class DTOReclamacao
    {
        public DTOReclamacao()
        {

        }

        public DTOReclamacao(int id)
        {
            Id = id;
        }

        public DTOReclamacao(int id, int autorId, string texto, DateTimeOffset dataCriacao, int destinoId)
        {
            Id = id;
            AutorId = autorId;
            Texto = texto;
            DataCriacao = DateTime.SpecifyKind(dataCriacao.DateTime, DateTimeKind.Utc);
            DestinoId = destinoId;
        }
        public DTOReclamacao( int autorId, string texto, DateTimeOffset dataCriacao, int destinoId)
        {
            AutorId = autorId;
            Texto = texto;
            DataCriacao = DateTime.SpecifyKind(dataCriacao.DateTime,DateTimeKind.Utc);
            DestinoId = destinoId;
        }

        public int Id { get;  set; }
        public DTOCidadao? Autor { get;  set; }
        public int AutorId { get; set; }
        public string Texto { get;  set; }
        public DateTimeOffset DataCriacao { get;  set; }
        public DTOSecretaria? Destino { get;  set; }
        public int DestinoId { get; set; }

        public Reclamacao ConverterDTOParaModel(DTOReclamacao reclamacao)
        {
            var autor = reclamacao.Autor.ConverterDTOParaModel(reclamacao.Autor);
            var destino = reclamacao.Destino.ConverterDTOParaModel(reclamacao.Destino);
            return new Reclamacao(reclamacao.Id,autor,reclamacao.Texto,reclamacao.DataCriacao,destino);
        }
    }
}