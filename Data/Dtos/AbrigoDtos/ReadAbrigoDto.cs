﻿

namespace adopt_pet.api.data.dtos.abrigodtos
{
    public class ReadAbrigoDto
    {

        public string username { get; set; } = null!;

        public string city { get; set; } = null!;

        public string state { get; set; } = null!;


        public string email { get; set; } = null!;


        public int phonenumber { get; set; }
        public int CNPJ { get; set; }
    }
}
