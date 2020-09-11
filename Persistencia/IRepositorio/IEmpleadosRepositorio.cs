using PruebaIFX.Helpers;
using PruebaIFX.Modelos;

namespace PruebaIFX.Persistencia.IRepositorio
{
    public interface IEmpleadosRepositorio
    {
        GenericAnswer GetObjEmpleado(EmpleadosModel entity);
        GenericAnswer GetEmpleados();
        GenericAnswer CreateEmpleado(EmpleadosModel entity);
        GenericAnswer UpdateEmpleado(EmpleadosModel entity);
        GenericAnswer DeleteEmPleado(EmpleadosModel entity);
    }
}
