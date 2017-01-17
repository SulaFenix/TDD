using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caelum.Leilao
{
    public class Avaliador
    {
        private double maiorDeTodos = Double.MinValue;
        private double menorDeTodos = Double.MaxValue;
        private double mediaLance;
        private double media = 0;
        private List<Lance> maiores;

        public void Avalia(Leilao leilao)
        {
            foreach(var lance in leilao.Lances)
            {
                if (lance.Valor > maiorDeTodos)
                {
                    maiorDeTodos = lance.Valor;
                }
                if (lance.Valor < menorDeTodos)
                {
                    menorDeTodos = lance.Valor;
                }
            }

            pegaOsMaioresNoLeilao(leilao);
        }

        public double MaiorLance
        {
            get { return maiorDeTodos; }
        }

        public double MenorLance
        {
            get { return menorDeTodos; }
        }

        public void Media(Leilao leilao)
        {
            double soma = 0;
            int qtd = 0;

            foreach(var lance in leilao.Lances)
            {
                soma += lance.Valor;
                qtd++;
            }

            mediaLance = soma / qtd;
        }

        public double MediaLance
        {
            get { return mediaLance; }
        }

        //Resolução do Instrutor
        public void AvaliaInstrutor(Leilao leilao)
        {
            double total = 0;
            foreach (Lance lance in leilao.Lances)
            {
                if (lance.Valor > maiorDeTodos)
                    maiorDeTodos = lance.Valor;
                if (lance.Valor < menorDeTodos)
                    menorDeTodos = lance.Valor;
                total += lance.Valor;
            }
            media = total / leilao.Lances.Count;
        }

        private void pegaOsMaioresNoLeilao(Leilao leilao)
        {
            maiores = new List<Lance>(leilao.Lances.OrderByDescending(x => x.Valor));
            maiores = maiores.GetRange(0, maiores.Count > 3 ? 3 : maiores.Count);
        }

        public List<Lance> TresMaiores
        {
            get { return this.maiores; }
        }
    }
}
