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
	ProgrammaEventi mioProgramma = new ProgrammaEventi(titoloProgramma);

	Console.Write("Indica il numero di eventi da inserire: ");
	int numeroEventi = int.Parse(Console.ReadLine());

//CREAZIONE ED INSERIMENTO EVENTI NEL PROGRAMMA CREATO
	for (int i = 0; i < numeroEventi; i++)
	{
		try
		{
			Console.WriteLine("");  // PER FORMATTAZIONE
			Console.Write($"Inserire il nome del {i + 1}° evento: ");
			nomeEvento = Console.ReadLine();
			if(nomeEvento == "")
			{
				throw new ArgumentException($"Il titolo del {i+1}° evento risulta nullo!", "nomeEvento");
			}
		}
		catch (Exception e)
		{
			Console.WriteLine($"Ci sono stati degli errori durante l'inserimento del titolo dell'evento n.{i+1}!");
			Console.Write(e.Message);
			while (nomeEvento == "")
			{
				Console.Write("\nReinserisci il titolo dell'evento! ");
				nomeEvento = Console.ReadLine() ;
			}
		}
		try
		{
			Console.Write("Inserisci la data dell'evento (gg/mm/yyyy): ");
			dataEventoStringa = Console.ReadLine();
			if (dataEventoStringa == "")
			{
				throw new ArgumentException($"La data del {i + 1}° evento risulta nullo!", "dataEventoStringa");
			}
			dataEvento = DateTime.Parse(dataEventoStringa);
		}
		catch (Exception e)
		{
			Console.WriteLine($"Ci sono stati degli errori durante l'inserimento della data dell'evento n.{i + 1}!");
			Console.Write(e.Message);
			while (dataEventoStringa == "")
			{
				Console.Write("\nReinserisci la data dell'evento! ");
				dataEventoStringa = Console.ReadLine();
			}
		}
		try
		{
			Console.Write("Inserisci il numero di posti totali: ");
			capienzaMaxEvento = int.Parse(Console.ReadLine());
			if(capienzaMaxEvento == 0 || capienzaMaxEvento < 0)
			{
				throw new ArgumentException($"La capienza massima del {i + 1}° evento risulta vuota o negativa!", "capienzaMaxEvento");
			}
			
		}
		catch(Exception e)
		{
			Console.WriteLine($"Ci sono stati degli errori durante l'inserimento dei posti totali dell'evento n.{i+1}!");
			Console.Write(e.Message);
			while (capienzaMaxEvento == 0 || capienzaMaxEvento < 0)
			{
				Console.Write("\nReinserisci il numero di posti totale dell'evento! ");
				capienzaMaxEvento = int.Parse(Console.ReadLine());
			}
		}
		try
		{
			Evento eventoProgramma = new Evento(nomeEvento, dataEvento, capienzaMaxEvento);
			mioProgramma.AddEvento(eventoProgramma);

			Console.WriteLine("");  // PER FORMATTAZIONE
		}catch(Exception e)
		{
			Console.WriteLine("Ci sono stati degli errori durante la crezione dell'oggetto eventoProgramma!");
			Console.Write(e.Message);
		}
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
catch (Exception e)
{
	Console.WriteLine("Qualcosa è andato storto...");
	Console.WriteLine(e.Message);
}