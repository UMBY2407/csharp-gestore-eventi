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
	string sceltaUtente = Console.ReadLine().ToLower();
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
	Console.WriteLine("");

	//CREAZIONE PROGRAMMA EVENTI
	Console.Write("Inserisci il nome del tuo programma di eventi: ");
	string titoloProgramma = Console.ReadLine();
	if(titoloProgramma == "")
	{
		throw new ArgumentException("il titolo inserito risulta nullo", "titoloProgramma");
	}

	ProgrammaEventi mioProgramma = new ProgrammaEventi(titoloProgramma);
	
	Console.Write("Indica il numero di eventi da inserire: ");
	int numeroEventi = int.Parse(Console.ReadLine());

	//CREAZIONE ED INSERIMENTO EVENTI NEL PROGRAMMA CREATO
	for (int i = 0; i < numeroEventi; i++)
	{
		Console.WriteLine("");  // PER FORMATTAZIONE
		Console.Write($"Inserire il nome del {i + 1}° evento: ");
		nomeEvento = Console.ReadLine();

		Console.Write("Inserisci la data dell'evento (gg/mm/yyyy): ");
		dataEventoStringa = Console.ReadLine();
		dataEvento = DateTime.Parse(dataEventoStringa);

		Console.Write("Inserisci il numero di posti totali: ");
		capienzaMaxEvento = int.Parse(Console.ReadLine());

		Evento eventoProgramma = new Evento(nomeEvento, dataEvento, capienzaMaxEvento);
		mioProgramma.AddEvento(eventoProgramma);
		
		Console.WriteLine("");  // PER FORMATTAZIONE
	}
	//USO DEI METODI CLASSE PROGRAMMA EVENTO
	
	Console.WriteLine("");
	mioProgramma.ContaNumeroEventi();
	Console.WriteLine("Ecco il tuo programma eventi:");
	Console.WriteLine(mioProgramma.TitoloEDataEventiInListaToString());
	Console.WriteLine("");

	Console.Write("Inserisci una data per sapere che eventi ci saranno (gg/mm/yyyy): ");
	dataEventoStringa = Console.ReadLine();
	DateTime eventoPerData = DateTime.Parse(dataEventoStringa);

	mioProgramma.EventiPerData(eventoPerData);
}
catch(Exception e)
{
	Console.WriteLine("Qualcosa è andato storto...");
	Console.WriteLine(e.Message);
}
