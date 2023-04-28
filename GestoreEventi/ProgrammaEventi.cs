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
		private int numeroEventiNelProgramma = 0;

		//COSTRUTTORE
		public ProgrammaEventi(string titoloEvento)
		{
			this.titolo = titoloEvento;
		}

		//GETTERS
		public int GetNumeroEventiNelProgramma()
		{
			return this.numeroEventiNelProgramma;
		}

		//METODI
		public void AddEvento(Evento eventoDaAggiungere)
		{
			eventi.Add(eventoDaAggiungere);
			numeroEventiNelProgramma++;
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
	}
}
