
using Rubrica.Core.BusinessLayer;
using Rubrica.Core.Entities;
using Rubrica.RepositoryEF.Repositories;
using Rubrica.RepositoryMock;

//IBusinessLayer bl = new MainBusinessLayer(new RepositoryContattiMock(), new RepositoryIndirizziMock());
IBusinessLayer bl = new MainBusinessLayer(new RepositoryContattiEF(), new RepositoryIndirizziEF());

bool continua = true;

while (continua)
{
    int scelta = Menu();
    continua = AnalizzaScelta(scelta);
}
int Menu()
{
    Console.WriteLine("========== BENVENUTO NEL MENU DELLA RUBRICA ==========");
    Console.WriteLine("\n1.Visualizza l'elenco completo dei contatti,");
    Console.WriteLine("2.Aggiungi un nuovo contatto,");
    Console.WriteLine("3.Aggiungi un indirizzo ad un contatto esistente,");
    Console.WriteLine("4.Elimina un contatto solo se non ha nessun indirizzo,");
    Console.WriteLine("0.Exit");
    Console.WriteLine("\n====================================================");

    int scelta;
    Console.WriteLine("Inserisci la tua scelta: ");
    while (!(int.TryParse(Console.ReadLine(), out scelta)))
    {
        Console.WriteLine("Scelta errata. Inserisci una scelta corretta: ");
    }
    return scelta;
}
bool AnalizzaScelta(int scelta)
{
    switch (scelta)
    {
        case 1:
            VisualizzaContatti();
            break;
        case 2:
            AggiungiContatto();
            break;
        case 3:
            AggiungiIndirizzo();
            break;
        case 4:
            EliminaContatto();
            break;
        case 0:
            return false;
        default: Console.WriteLine("Scelta inserita non valida");
            break;
    }
    return true;
}

void EliminaContatto()
{
    Console.WriteLine("Elenco completo dei contatti: ");
    VisualizzaContatti();
    int idContatto;
    while(!int.TryParse(Console.ReadLine(),out idContatto))
    {
        Console.WriteLine("Scelta non valida. Riprova");
    }
    Esito esito = bl.EliminaContatto(idContatto);
    Console.WriteLine(esito.Messaggio);

}

void AggiungiIndirizzo()
{
    Console.WriteLine("Elenco completo dei contatti: ");
    VisualizzaContatti();
    Console.WriteLine("Scegli un contatto a cui aggiungere un indirizzo. Inserisci il suo ID: ");
    int contattoID=int.Parse(Console.ReadLine());
    int tipo;
    do
    {
        Console.WriteLine("Scegli la tipologia:" +
            "\nClicca 1 per inserire un indirizzo di RESIDENZA" +
            "\nClicca 2 per inserire un indirizzo di DOMICILIO");
        tipo = int.Parse(Console.ReadLine());

    }while (tipo!=1 && tipo!=2);
    string tipologia;
    if (tipo == 1)
    {
       tipologia = "Residenza";
    }
    else
    {
        tipologia = "Domicilio";
    }
    Console.WriteLine($"Hai scelto: {tipologia}");
    Console.WriteLine("Inserisci la via: ");
    string via = Console.ReadLine();
    Console.WriteLine("Inserisci la città: ");
    string citta = Console.ReadLine();
    int cap;
    Console.WriteLine("Inserisci il CAP: ");
    int.TryParse(Console.ReadLine(), out cap);
    Console.WriteLine("Inserisci la nazione: ");
    string nazione = Console.ReadLine();
    
    Indirizzo newIndirizzo = new Indirizzo();
    newIndirizzo.ContattoID = contattoID;
    newIndirizzo.Tipologia = tipologia;
    newIndirizzo.Via = via;
    newIndirizzo.Citta = citta;
    newIndirizzo.Nazione = nazione;
    newIndirizzo.Cap = cap;

    Esito esito = bl.AggiungiIndirizzo(newIndirizzo);
    Console.WriteLine(esito.Messaggio);

    Console.WriteLine($"\nHai inserito: {newIndirizzo}\n");
}

void AggiungiContatto()
{
    Console.WriteLine("Inserisci il nome del nuovo contatto");
    string nome = Console.ReadLine();
    Console.WriteLine("Inserisci il cognome del nuovo contatto");
    string cognome = Console.ReadLine();

    Contatto newContatto = new Contatto();
    newContatto.Nome = nome;
    newContatto.Cognome = cognome;
    Esito esito = bl.AddNuovoContatto(newContatto);
    Console.WriteLine(esito.Messaggio);

}

void VisualizzaContatti()
{
    List<Contatto> listaContatti = bl.GetAllContatti();

    if(listaContatti.Count == 0)
    {
        Console.WriteLine("LISTA VUOTA");
    }
    else
    {
        foreach(var c in listaContatti)
        {
            Console.WriteLine(c);
        }
    }
}