using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PruebaIFX.Helpers
{
    public class Enumeradores
    {
        public enum Roles
        {
            Empleado = 1,
            CoordinadorTécnico = 2,
            Juridico = 3,
            ProfesionalSIG = 4,
            SeguimientoyControlSYC = 5,
            LiderdeNegocio = 6,
            LiderOperativos = 7,
            Cliente = 8,
            SuperAdministrador = 9,
            Administrador = 10,
            GestordePagos = 11,
            CoordinadordeEntidades = 12,
            JefedeDepartamento = 13
        }

        public enum IdFormularios
        {
            formularioa = 1,
            formularioconclusionavaluo = 2,
            formularioconceptovalor = 3,
            formularioconclusionconceptovalor = 4,
            formularioPersona = 5,
            
        }
    }
}
