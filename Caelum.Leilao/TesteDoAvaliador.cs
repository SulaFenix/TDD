﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Caelum.Leilao
{
    [TestFixture]
    public class TesteDoAvaliador
    {
        [Test]
        public void DeveEntenderLancesEmOrdemCrescente()
        {
            // 1ª parte: Cenário
            Usuario joao = new Usuario("Joao");
            Usuario jose = new Usuario("Jose");
            Usuario maria = new Usuario("Maria");

            Leilao leilao = new Leilao("Playstation 3 Novo");

            leilao.Propoe(new Lance(maria, 250.0));
            leilao.Propoe(new Lance(joao, 300.0));
            leilao.Propoe(new Lance(jose, 400.0));

            // 2ª parte: Ação
            Avaliador leiloeiro = new Avaliador();
            leiloeiro.Avalia(leilao);

            // 3ª parte: Validação
            double maiorEsperado = 400;
            double menorEsperado = 250;

            Assert.AreEqual(maiorEsperado, leiloeiro.MaiorLance);
            Assert.AreEqual(menorEsperado, leiloeiro.MenorLance);
        }

        [Test]
        public void OutroCenario()
        {
            // implementar....
        }
    }
}
