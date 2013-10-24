using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using AsegurarSA.Domain.Entities;

namespace AsegurarSA.Domain.Abstract
{
    public interface IAlarmaRepository
    {
        IQueryable<Alarma> ListaAlarmaCliente(int idCliente);
        Alarma Alarma(int idAlarma);
        void SaveAlarma(Alarma alarma);
        void DeleteAlarma(Alarma alarma);
    }
}
