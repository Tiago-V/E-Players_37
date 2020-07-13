using System.Collections.Generic;
using EPlayers_Senai.Models;

namespace EPlayers_Senai.Interfaces
{
    public interface INoticias
    {
        //Crud

        //Criar
        void Criar(Noticias n);
        //Ler
        List<Noticias> Ler();
        //Alterar 
        void Alterar(Noticias n);
        //Excluir     
        void Excluir(int id); 
    }
}