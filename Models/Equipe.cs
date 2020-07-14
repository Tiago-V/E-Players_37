using System;
using System.Collections.Generic;
using System.IO;
using E_Players_AspNETCore.Interfaces;

namespace E_Players_AspNETCore.Models
{
    public class Equipe : EPlayerBase, IEquipe
    {
        public int IdEquipe { get; set; }
        public string Nome { get; set; }
        public string Imagem { get; set; }

        private const string PATH = "Database/equipe.csv";
        public Equipe()
        {
            CreateFolderAndFile(PATH);
        }

        /// <summary>
        /// Cria linha
        /// </summary>
        /// <param name="e">Equipe a ser adicionada</param>
        public void Create(Equipe e)
        {
            string[] linha = { PrepararLinha(e) };
            File.AppendAllLines(PATH, linha);
        }

        private string PrepararLinha(Equipe e){
            return $"{e.IdEquipe};{e.Nome};{e.Imagem}";
        }

        /// <summary>
        /// Deleta linha
        /// </summary>
        /// <param name="id">Id da Equipe a ser excluída</param>
        public void Delete(int id)
        {
            List<string> linhas = ReadAllLinesCSV(PATH);
            // 1;Flamengo;fla.png
            linhas.RemoveAll(x => x.Split(";")[0] == IdEquipe.ToString());
            RewriteCSV(PATH, linhas);

        }

        /// <summary>
        /// Lê todas as linhas do csv
        /// </summary>
        /// <returns>Lista de Equipes</returns>
        public List<Equipe> ReadAll()
        {
            List<Equipe> equipes = new List<Equipe>();
            string[] linhas = File.ReadAllLines(PATH);

            foreach (var item in linhas)
            {
                string[] linha = item.Split(";");
                Equipe equipe = new Equipe();
                equipe.IdEquipe = Int32.Parse(linha[0]);
                equipe.Nome = linha[1];
                equipe.Imagem = linha[2];

                equipes.Add(equipe);
            }
            return equipes;

        }

        /// <summary>
        /// Atualiza Linha
        /// </summary>
        /// <param name="e">Equipe a ser atualizada</param>
        public void Update(Equipe e)
        {
            List<string> linhas = ReadAllLinesCSV(PATH);
            linhas.RemoveAll(x => x.Split(";")[0] == IdEquipe.ToString());
            linhas.Add( PrepararLinha(e) );
            RewriteCSV(PATH, linhas);
        }
    }
}