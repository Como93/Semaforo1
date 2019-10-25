using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ConsoleApp1.Semafori;
using ConsoleApp1.Tratta;
using ConsoleApp1.Veicoli;

namespace ConsoleApp1
{
	class Program
	{
		static void Main(string[] args)
		{
			Semaforo semaforoBianco = new SemaforoBianco();
			Semaforo semaforoBlu = new SemaforoBlu();

			TrattaStradale tratta = new TrattaStradale(2000.0);

			int numeroMacchine = 5;

			Veicolo[] veicoliBianchi = new VeicoloBianco[numeroMacchine];

			double velocitaTot = 0.0;
			double velocitaMedia = 0.0;


			for (int i = 0; i < numeroMacchine; i++)
			{
				Console.WriteLine("inserisci velocita veicolo ");
				double vel = double.Parse(Console.ReadLine());

				Veicolo veicolo = new VeicoloBianco(vel);
				veicoliBianchi[i] = veicolo;
			}

			Veicolo[] veicoliBlu = new VeicoloBlu[numeroMacchine];

			for (int i = 0; i < numeroMacchine; i++)
			{
				Console.WriteLine("inserisci velocita veicolo ");
				double vel = double.Parse(Console.ReadLine());

				Veicolo veicolo = new VeicoloBlu(vel);
				veicoliBlu[i] = veicolo;
			}

			for(int i = 0; i < numeroMacchine; i++)
			{
				velocitaTot += veicoliBianchi[i].velocita;
			}

			for (int i = 0; i < numeroMacchine; i++)
			{
				velocitaTot += veicoliBlu[i].velocita;
			}

			velocitaMedia = velocitaTot / (numeroMacchine * 2);

			semaforoBianco.durata = tratta.lunghezza / velocitaMedia;
			semaforoBlu.durata = tratta.lunghezza / velocitaMedia;

			
			Console.WriteLine("Quale semaforo vuoi accendere? 0 per Blu 1 per Bianco");
			int scelta = int.Parse(Console.ReadLine());

			switch (scelta)
			{
				case 0:
					semaforoBlu.acceso = semaforoBlu.Verde();
					break;
				case 1:
					semaforoBianco.acceso = semaforoBianco.Verde();
					break;
			}

			while(semaforoBlu.acceso || semaforoBianco.acceso)
			{
				if (semaforoBlu.acceso)
				{
					Veicolo[] macchinePassateBlu = new VeicoloBlu[5];
					for(int i = 0; i < numeroMacchine; i++)
					{
						Thread.Sleep((int)semaforoBlu.durata);
						macchinePassateBlu[i] = veicoliBlu[i];

					}
					Console.WriteLine("Vuoi continuare? 0 per No 1 per si");
					int scelta_2 = int.Parse(Console.ReadLine());
					if(scelta_2 == 1)
					{
						semaforoBlu.acceso = semaforoBlu.Rosso();
						semaforoBianco.acceso = semaforoBianco.Verde();

					} else
					{
						semaforoBlu.acceso = semaforoBlu.Rosso();
					}

				}
				if (semaforoBianco.acceso)
				{
					Veicolo[] macchinePassateBianco = new VeicoloBianco[5];
					for (int i = 0; i < numeroMacchine; i++)
					{
						Thread.Sleep((int)semaforoBianco.durata);
						macchinePassateBianco[i] = veicoliBianchi[i];

					}
					Console.WriteLine("Vuoi continuare? 0 per No 1 per si");
					int scelta_2 = int.Parse(Console.ReadLine());
					if (scelta_2 == 1)
					{
						semaforoBlu.acceso = semaforoBlu.Verde();
						semaforoBianco.acceso = semaforoBianco.Rosso();

					}
					else
					{
						semaforoBianco.acceso = semaforoBianco.Rosso();
					}
				}
				
				
				
			}

		}
	}
}
