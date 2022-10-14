using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cliente.Shared.Mensajes;
public static class MensajesError
{
    public const string MENSAJE_ID_INVALIDO = "Número de Identificación Inválido!";
    public const string MENSAJE_ERROR_INESPERADO = "Ocurrio un Error Inesperado, Intentelo nuevamente!";
    public const string MENSAJE_ERROR_VALIDACION_ACTA = "La Imagen no ha sido subida correctamente o la Papeleta no tiene Candidatos";
}
