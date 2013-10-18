using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using AsegurarSA.Domain.Abstract;
using AsegurarSA.Domain.Entities;
using AsegurarSA.WebUI.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace AsegurarSA.WebUI.Tests
{
    [TestClass]
    public class ClienteTest
    {
        [TestMethod]
        public void Obtener_Clientes()
        {
            //Arrenge
            var mock = new Mock<IClienteRepository>();
            mock.Setup(m => m.Cliente).Returns(new Cliente[] {
                new Cliente { Nombre = "Lucas", Apellido = "Rodriguez", Telefono1 = "554564", Telefono2 = "554564", Domicilio = "JJ 201"},
                new Cliente { Nombre = "Diego", Apellido = "Veronesse", Telefono1 = "554564", Telefono2 = "554564", Domicilio = "CC 201"},
                new Cliente { Nombre = "Mariano", Apellido = "Ferrero", Telefono1 = "554564", Telefono2 = "554564", Domicilio = "AA 201"},
                new Cliente { Nombre = "Pedro", Apellido = "LaPrida", Telefono1 = "554564", Telefono2 = "554564", Domicilio = "DD 201"},
                new Cliente { Nombre = "Ignacio", Apellido = "Santos", Telefono1 = "554564", Telefono2 = "554564", Domicilio = "EE 201"}
             }.AsQueryable());

            //Act
            var controller = new ClienteController(mock.Object);

            var cliente = ((ViewResult)controller.List()).ViewData.Model as List<Cliente>;

            //Assert
            Assert.Equals(cliente.Count, 5);
        }
    }
}
