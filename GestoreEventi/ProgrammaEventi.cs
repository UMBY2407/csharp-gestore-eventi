using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestoreEventi
{
	public class ProgrammaEventi
	{
		//ATTRIBUTI
		private string titolo;
		private List<Evento> eventi = new List<Evento>();

		//COSTRUTTORE
		public ProgrammaEventi(string titoloEvento)
		{
			if(titoloEvento == "")
			{
				throw new ArgumentException("Il titolo inserito non esiste!", "titoloEvento");
			}
			this.titolo = titoloEvento;
		}

		//METODI
		public void AddEvento(Evento eventoDaAggiungere)
		{
			eventi.Add(eventoDaAggiungere);
			Console.WriteLine($"{eventoDaAggiungere} aggiunto alla lista Eventi!");
		}

		public void EventiPerData(DateTime data)
		{
			List<Evento> eventiPerData = new List<Evento>();
			foreach (Evento eventoLetto in eventi)
			{
				if(eventoLetto.GetData() == data)
				{
					eventiPerData.Add(eventoLetto);
				}
			}
			
			foreach(Evento eventoLetto in eventiPerData)
			{
				Console.WriteLine(data + " - " + eventoLetto.GetTitolo());
			}
		}

		public static string ListaEventiToString(List<Evento> listaEvento)
		{
			string stringaEvento = "";
			foreach (Evento eventoletto in listaEvento)
			{
				stringaEvento += eventoletto.ToString() + "\n";
			}
			return stringaEvento;
		}

		public void ContaNumeroEventi()
		{
			int numeroEventiNellaLista = 0;
			numeroEventiNellaLista = eventi.Count();
			Console.WriteLine("Il numero di eventi nel programma è:" + numeroEventiNellaLista);
		}

		public void SvuotaListaEventi()
		{
			this.eventi.Clear();
			Console.WriteLine("Lista eventi svuotata!");
		}

		public string TitoloEDataEventiInListaToString()
		{
			string stringaEvento = $"{this.titolo}:\n";
			foreach (Evento eventoLetto in eventi)
			{
				stringaEvento += $"\t{eventoLetto.GetData()} - {eventoLetto.GetTitolo()}\n";
			}
			return stringaEvento;
		}
	}
}