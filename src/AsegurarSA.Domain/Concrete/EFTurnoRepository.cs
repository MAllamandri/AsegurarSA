using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Web.UI.WebControls.WebParts;
using AsegurarSA.Domain.Abstract;
using AsegurarSA.Domain.Entities;

namespace AsegurarSA.Domain.Concrete
{
    public class EFTurnoRepository:ITurnoRepository
    {

        private EFDbContext context = new EFDbContext();

        public IQueryable<Entities.Turno> Turnos
        {
            get { return context.Turnos; }
        }
       
        public void SaveTurno(Entities.Turno turno)
        {
            context.Turnos.Add(turno);
            context.Entry(turno).State = System.Data.Entity.EntityState.Added;
            context.SaveChanges();
        }

        public List<Turno> ManejadorTurnos(DateTime FechaDia)
        {
            IEnumerable<Turno> listaTurnos = ObtenerListaTurnos();
            List<Turno> Turnos = GenerarTurnos(listaTurnos, FechaDia);

            return Turnos;
        }
        // Lista de turnos es una lista que tiene los turnos del ultimo dia de trabajo
        public List<Turno> GenerarTurnos(IEnumerable<Turno> listaTurnos, DateTime fechaTope)
        {
            var fechaInicio = listaTurnos.First().FechaDia;
            var listaFinalturnos = new List<Turno>();
            if (fechaInicio > fechaTope)
            {
                throw new ArgumentNullException("fechaTope","Ingrese una fecha superior al ultimo turno");
            }

            while (fechaTope > fechaInicio)
            {
                fechaInicio = fechaInicio.AddDays(1);
                foreach (var e in listaTurnos)
                {
                    if (e.Semana == 5)
                    {
                        e.Dia = 1;
                        e.Semana = 1;
                        if (e.TipoTurno == 3)
                        {
                            e.TipoTurno = 1;
                        }
                        else
                        {
                            e.TipoTurno++;
                        }
                        e.Franco = true;
                    }
                    else
                    {
                        if (e.Dia < 7)
                        {
                            e.Dia++;
                            e.Franco = false;
                            
                        }
                        else
                        {
                            e.Dia = 1;
                            e.Semana++;
                            e.Franco = true;
                        }
                    }
                    e.FechaDia = fechaInicio;
                    listaFinalturnos.Add(e);
                    context.Turnos.Add(e);
                    context.SaveChanges();
                }
            }
            return listaFinalturnos;
        }

        public IEnumerable<Turno> ObtenerListaTurnos()
        {
            var ultimoturno = context.Turnos.AsEnumerable().Last();
            return context.Turnos.Where(t => t.FechaDia ==  ultimoturno.FechaDia);
        }

        public IEnumerable<Turno> ObtenerTurnos(DateTime fechaInico, DateTime fechaTope)
        {
            return context.Turnos.Where(t=> t.FechaDia >= fechaInico && t.FechaDia <= fechaTope);;
        }
    }
}
 