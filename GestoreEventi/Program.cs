using GestoreEventi;

try
{
//INPUT UTENTE	
	Console.Write("Inserisci il nome dell'Evento: ");
	string nomeEvento = Console.ReadLine();

	Console.Write("Inserisci la data dell'evento (gg/mm/yyyy): ");
	string dataEventoStringa = Console.ReadLine();
	DateTime dataEvento = DateTime.Parse(dataEventoStringa);

	Console.Write("Inserire il numero di posti totali: ");
	int capienzaMaxEvento = int.Parse(Console.ReadLine());

	Console.Write("Quanti posti vuoi prenotare? ");
	int postiPrenotati = int.Parse(Console.ReadLine());

//CREAZIONE OGGETTI EVENTO
	Evento mioEvento1 = new Evento(nomeEvento, dataEvento, capienzaMaxEvento);

//UTILIZZO METODI DELLA CLASSE EVENTO
	mioEvento1.PrenotaPosti(postiPrenotati);

}
catch(Exception e)
{
	Console.WriteLine("Qualcosa è andato stoto...");
	Console.WriteLine(e.Message);
}
