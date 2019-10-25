using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Semafori
{
	class Semaforo
	{
		public bool acceso { get; set; }
		public double durata { get; set; }

		public Semaforo()
		{
			acceso = false;
		}

		public bool Verde()
		{
			return true;
		}

		public bool Rosso()
		{
			return false;
		}
	}
}
