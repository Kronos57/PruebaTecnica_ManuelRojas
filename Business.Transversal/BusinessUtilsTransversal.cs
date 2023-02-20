using Transversal.Entities;

namespace Business.Transversal
{
    public class BusinessUtilsTransversal
    {
        public string GetTipoDeCuenta(int enumNumber)
        {
            string? nombreEnum = Enum.GetName(typeof(AccountTypeEnum), enumNumber);

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
