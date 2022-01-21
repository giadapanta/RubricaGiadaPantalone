using Rubrica.Core.BusinessLayer;
using Rubrica.Core.Entities;
using Rubrica.RepositoryEF.Repositories;
using Rubrica.RepositoryMock;
using System.Collections.Generic;
using Xunit;


namespace Rubrica.Test
{
    

    public class UnitTest1
    {
        IBusinessLayer bl = new MainBusinessLayer(new RepositoryContattiEF(), new RepositoryIndirizziEF());
        //IBusinessLayer bl = new MainBusinessLayer(new RepositoryContattiMock(), new RepositoryIndirizziMock());
        [Fact]
        public void Test1()
        {
            Contatto contatto = new Contatto();
            contatto.Nome = "Anna";
            contatto.Cognome = "Rossi";
            Esito esito = new Esito();
            List<Contatto> listaContatti = bl.GetAllContatti();

            foreach (Contatto c in listaContatti)
            {
                if (c.Nome == contatto.Nome && c.Cognome == contatto.Cognome)
                {

                    bl.EliminaContatto(contatto.ContattoID);

                }
            }

            esito = bl.AddNuovoContatto(contatto);

            Assert.True(esito.isOk == true);


        }
       
       

    }
}