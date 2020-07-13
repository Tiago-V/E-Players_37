using System.Collections.Generic;
using EPlayers_Senai.Models;

namespace EPlayers_Senai.Interfaces
{
    public interface IEquipe
    {
         //Crud

        //Criar
        void Create(Equipe e);
        //Ler
        List<Equipe> ReadAll();
        //Alterar 
        void Update(Equipe e);
        //Excluir     
        void Delete(int id);
    }
}