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
		string titolo;
		List<Evento> eventi;

		//COSTRUTTORE
		public ProgrammaEventi(string titoloEvento)
		{
			this.titolo = titoloEvento;
			this.eventi = new List<Evento>();
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
	}
}
