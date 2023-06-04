﻿namespace Core.Entities
{
    public class Cargo
    {
        public Cargo()
        {
            
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