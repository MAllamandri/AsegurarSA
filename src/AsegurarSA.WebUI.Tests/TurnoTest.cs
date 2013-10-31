using System;
using System.Collections.Generic;
using AsegurarSA.Domain.Abstract;
using AsegurarSA.Domain.Concrete;
using AsegurarSA.Domain.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AsegurarSA.WebUI.Controllers;
using System.Linq;
using System.Web.Mvc;
using Moq;

namespace AsegurarSA.WebUI.Tests
{
    [TestClass]
    public class TurnoTest
    {
        //[TestMethod]
        //public void DiasOcupados()
        //{
        //    //Arrange
        //      List<Turno> turno = new List<Turno>();
        //        turno.Add(new Turno { TurnoId = 1, FechaDia =  Convert.ToDateTime("25/10/2013"), EmpleadoId = 1, Dia = 1, Semana = 5, TipoTurno = 1, Franco =true });
        //        turno.Add(new Turno { TurnoId = 2, FechaDia = Convert.ToDateTime("25/10/2013").Date, EmpleadoId = 2, Dia = 6, Semana = 4, TipoTurno = 1, Franco = false });
        //        turno.Add(new Turno { TurnoId = 3, FechaDia = Convert.ToDateTime("25/10/2013"), EmpleadoId = 3, Dia = 4, Semana = 4, TipoTurno = 1, Franco = false });
        //        turno.Add(new Turno { TurnoId = 4, FechaDia = Convert.ToDateTime("25/10/2013") , EmpleadoId = 4, Dia = 1, Semana = 5, TipoTurno = 2, Franco = true});
        //        turno.Add(new Turno { TurnoId = 5, FechaDia = Convert.ToDateTime("25/10/2013"), EmpleadoId = 5, Dia = 6, Semana = 4, TipoTurno = 2, Franco = false });
        //        turno.Add(new Turno { TurnoId = 6, FechaDia = Convert.ToDateTime("25/10/2013"), EmpleadoId = 6, Dia = 4, Semana = 4, TipoTurno = 2, Franco = false });
        //        turno.Add(new Turno { TurnoId = 4, FechaDia = Convert.ToDateTime("25/10/2013"), EmpleadoId = 7, Dia = 1, Semana = 5, TipoTurno = 3, Franco = true });
        //        turno.Add(new Turno { TurnoId = 5, FechaDia = Convert.ToDateTime("25/10/2013"), EmpleadoId = 8, Dia = 6, Semana = 4, TipoTurno = 3, Franco = false });
        //        turno.Add(new Turno { TurnoId = 6, FechaDia = Convert.ToDateTime("25/10/2013"), EmpleadoId = 9, Dia = 4, Semana = 4, TipoTurno = 3, Franco = false });
            

        //   // Act
        //   List<Turno> listaFinal = EFTurnoRepository.GenerarTurnos(turno,Convert.ToDateTime("25/11/2013"));

        //    // Assert
        //    Assert.AreEqual(listaFinal.Count(),279);
        //}
    }
}
