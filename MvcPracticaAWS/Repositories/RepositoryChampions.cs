using MvcPracticaAWS.Data;
using MvcPracticaAWS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcPracticaAWS.Repositories
{
    public class RepositoryChampions
    {
        private ChampionsContext context;

        public RepositoryChampions(ChampionsContext context)
        {
            this.context = context;
        }

        public List<Jugador> GetJugadores()
        {
            var consulta = from data in this.context.Jugadores
                           select data;
            return consulta.ToList();
        }

        public List<Equipo> GetEquipos()
        {
            var consulta = from data in this.context.Equipos
                           select data;
            return consulta.ToList();
        }

        public List<Apuesta> GetApuestas()
        {
            var consulta = from data in this.context.Apuestas
                           select data;
            return consulta.ToList();
        }

        public int GetMaxIdApuesta()
        {
            if(this.context.Apuestas.Count() == 0)
            {
                return 1;
            }
            else
            {
                return this.context.Apuestas.Max(x => x.IdApuesta) + 1;
            }
         
        }

        public int GetMaxIdJugador()
        {
            return this.context.Jugadores.Max(x => x.IdJugador) + 1;
        }

        public void InsertJugador(Jugador jug)
        {
            this.context.Jugadores.Add(jug);
            this.context.SaveChanges();
        }

        public void InsertApuesta(Apuesta ap)
        {
            this.context.Apuestas.Add(ap);
            this.context.SaveChanges();
        }



    }
}
