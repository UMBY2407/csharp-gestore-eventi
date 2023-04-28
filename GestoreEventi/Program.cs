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

	//CICLO PER RICHIEDERE ALL'UTENTE SE VUOLE DISDIRE O PRENOTARE ALTRI POSTI
	Console.Write("Vuoi disdire dei posti? (si/no) ");
	string sceltaUtente = Console.ReadLine();
	sceltaUtente.ToLower();
	while (sceltaUtente == "si" || sceltaUtente == "sì")
	{
		Console.Write("Indica il numero di posti da disdire: ");
		int postiDaDisidire = int.Parse(Console.ReadLine());
		mioEvento1.DisdiciPosti(postiDaDisidire);
		Console.Write("Vuoi disdire dei posti? (si/no) ");
		sceltaUtente = Console.ReadLine();
	}
	Console.WriteLine("Ok va bene!");
	Console.WriteLine("");
	Console.WriteLine("Numero di posti prenotati: " + mioEvento1.GetNumeroPostiPrenotati());
	Console.WriteLine("Numero di posti disponibili: " + mioEvento1.GetCapienzaMassimaEvento());

}
catch(Exception e)
{
	Console.WriteLine("Qualcosa è andato stoto...");
	Console.WriteLine(e.Message);
}
