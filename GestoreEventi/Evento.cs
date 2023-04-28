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
			int result = DateTime.Compare(this.dataEvento, nuovaData);
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
	}
}
