using Rubrica.Core.Entities;
using Rubrica.Core.InterfaceRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rubrica.Core.BusinessLayer
{
    public class MainBusinessLayer : IBusinessLayer
    {
        private readonly IRepositoryContatti contattiRepo;
        private readonly IRepositoryIndirizzi indirizziRepo;

        public MainBusinessLayer(IRepositoryContatti contatti, IRepositoryIndirizzi indirizzi)
        {
            contattiRepo=contatti;
            indirizziRepo=indirizzi;
        }

        public Esito AddNuovoContatto(Contatto newContatto)
        {
            Contatto contattoEsistente =contattiRepo.GetByNomeCognome(newContatto.Nome, newContatto.Cognome);
            if(contattoEsistente == null)
            {
                contattiRepo.Add(newContatto);
                return new Esito { Messaggio ="Contatto aggiunto con successo\n", isOk = true };
            }
            else
            {
                return new Esito { Messaggio="Impossibile aggiungere il nuovo contatto." +
                    "\nContatto Esistente.\n", isOk=false };
            }
        }

        public Esito AggiungiIndirizzo(Indirizzo newIndirizzo)
        {
            var contatto = contattiRepo.GetByID(newIndirizzo.ContattoID);
            if (contatto == null)
            {
                return new Esito { Messaggio="\n ID del contatto è errato o inesistente", isOk=false};
            }
            else
            {
                indirizziRepo.Add(newIndirizzo);
                return new Esito { Messaggio="Indirizzo aggiunto con successo", isOk=true };
            }

        }

        public Esito EliminaContatto(int idContatto)
        {
           var contattoToDelete= contattiRepo.GetByID(idContatto);
            if (contattoToDelete == null)
            {
                return new Esito { Messaggio = "Non esiste nessun contatto con questo ID", isOk = false };
            }
            else
            {
                List<Indirizzo> indirizziDelContatto = indirizziRepo.GetIndirizzoByContattoID(idContatto);
                if (indirizziDelContatto.Count == 0)
                {
                    contattiRepo.Delete(contattoToDelete);
                    return new Esito { Messaggio = "Contatto eliminato con successo", isOk = true };

                }
                else
                {
                    return new Esito { Messaggio = "Impossibile eliminare il contatto", isOk = false };
                }
            }
        }

        public List<Contatto> GetAllContatti()
        {
            return contattiRepo.GetAll().ToList();
        }
    }
}
