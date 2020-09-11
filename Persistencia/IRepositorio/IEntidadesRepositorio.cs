using PruebaIFX.Helpers;
using PruebaIFX.Modelos;

namespace PruebaIFX.Persistencia.IRepositorio
{
    public interface IEntidadesRepositorio
    {
        GenericAnswer GetObjEntidad(EntidadesModel dataRulette);
        GenericAnswer GetEntidades();
        GenericAnswer CreateEntidad(EntidadesModel dataRulette);
        GenericAnswer UpdateEntidad(EntidadesModel dataRulette);
        GenericAnswer DeleteEntidad(EntidadesModel dataRulette);
    }
}
