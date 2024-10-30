using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIBasica.models
{
    public class Cliente
    {
        public  Cliente(){
            Id = Guid.NewGuid().ToString();
        }

        public Cliente (string nome){
            this.Nome = nome;
            Id = Guid.NewGuid().ToString();
        }

        public string Id {get; set;}
        public string? Nome {get; set;}


    }
}