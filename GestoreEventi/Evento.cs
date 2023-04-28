using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestoreEventi
{
	public class Evento
	{
		//ATTRIBUTI
		private string titolo;
		private DateTime dataEvento = new DateTime();
		private int CapienzaMassimaEvento;
		private int numeroPostiPrenotati = 0;

		//GETTERS
		public string GetTitolo()
		{
			return this.titolo;
		}

		public DateTime GetData()
		{
			return this.dataEvento;
		}

		public int GetCapienzaMassimaEvento()
		{
			return this.CapienzaMassimaEvento;
		}

		public int GetNumeroPostiPrenotati()
		{
			return this.numeroPostiPrenotati;
		}

		//SETTERS
		public string SetTitolo(string nuovoTitolo)
		{
			if (nuovoTitolo == "")
			{
				throw new ArgumentException("Il titolo nuovo risulta vuoto!","nuovoTitolo");
			}
			this.titolo = nuovoTitolo;
			return this.titolo;
		}

		public DateTime SetData(DateTime nuovaData)
		{
			int result = DateTime.Compare(DateTime.Now, nuovaData);
			if(result < 0)
			{
				throw new ArgumentException("La data inserita risulta già passata!", "nuovaData");
			}
			this.dataEvento = nuovaData;
			return this.dataEvento;
		}

		//COSTRUTTORE
		public Evento(string titoloEvento, DateTime data, int postiDisponibili)
		{
			this.titolo = titoloEvento;
			this.dataEvento = data;
			this.CapienzaMassimaEvento = postiDisponibili;
		}

		//METODI
		public void PrenotaPosti(int posti)
		{
			int result = DateTime.Compare(DateTime.Now, dataEvento);
			if (result < 0)
			{
				throw new Exception("L'Evento è già passato!");
			}

			if (CapienzaMassimaEvento == 0)
			{
				throw new Exception("Nessun posto Disponibile!");
			}

			if (posti == 0)
			{
				throw new ArgumentException("Nessun posto da prenotare!", "posti");
			}

			this.CapienzaMassimaEvento -= posti;
			this.numeroPostiPrenotati += posti;
			Console.WriteLine($"Numero di posti prenotati: {numeroPostiPrenotati}");
			Console.WriteLine($"Numero posti disponibili: {CapienzaMassimaEvento}");
		}

		public void Disdiciosti(int numeroPosti)
		{
			int result = DateTime.Compare(DateTime.Now, dataEvento);
			if (result < 0)
			{
				throw new Exception("L'Evento è già passato!");
			}

			if (numeroPosti == 0)
			{
				throw new ArgumentException("Nessun posto da disdire!", "posti");
			}

			this.CapienzaMassimaEvento += numeroPosti;
			this.numeroPostiPrenotati -= numeroPosti;
			Console.WriteLine($"Numero di posti prenotati: {numeroPostiPrenotati}");
			Console.WriteLine($"Numero posti disponibili: {CapienzaMassimaEvento}");
		}
	}
}
