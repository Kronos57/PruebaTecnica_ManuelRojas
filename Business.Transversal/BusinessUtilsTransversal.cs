using Transversal.Entities;

namespace Business.Transversal
{
    public class BusinessUtilsTransversal
    {
        public string GetTipoDeCuenta(int idTipoCuenta)
        {
            string? nombreEnum = Enum.GetName(typeof(AccountTypeEnum), idTipoCuenta);

            if (string.IsNullOrEmpty(nombreEnum))
            {
                nombreEnum = "Sin Definir";
            }

            return nombreEnum;
        }

        public string GetTipoDeIdentificacion(int idTipoIdentificacion)
        {
            string? nombreEnum = Enum.GetName(typeof(IdentificationTypeEnum), idTipoIdentificacion);

            if (string.IsNullOrEmpty(nombreEnum))
            {
                nombreEnum = "Sin Definir";
            }

            return nombreEnum;
        }

        public string GetGenero(int idGenero)
        {
            string? nombreEnum = Enum.GetName(typeof(GenderTypeEnum), idGenero);

            if (string.IsNullOrEmpty(nombreEnum))
            {
                nombreEnum = "Sin Definir";
            }

            return nombreEnum;
        }

        public string GetTipoDeMovimiento(int idTipoMovimiento)
        {
            string? nombreEnum = Enum.GetName(typeof(MovementTypeEnum), idTipoMovimiento);

            if (string.IsNullOrEmpty(nombreEnum))
            {
                nombreEnum = "Sin Definir";
            }

            return nombreEnum;
        }

        public string GetEstado(bool estado)
        {
            string? nombreEstado = estado ? Enum.GetName(typeof(StateEnum), 1) : Enum.GetName(typeof(StateEnum), 0);

            if (string.IsNullOrEmpty(nombreEstado))
            {
                nombreEstado = "Estado Desconocido";
            }

            return nombreEstado;
        }
    }
}
