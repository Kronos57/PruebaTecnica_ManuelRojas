namespace Transversal.Entities
{
    public class ConstantMessages
    {
        public static class EXCEPTION_MESSAGES
        {
            public const string CUENTA_NO_EXISTE = "La Cuenta no existe";
            public const string CUENTA_INACTIVA = "La Cuenta se encuentra Inactiva";
            public const string CLIENTE_NO_EXISTE = "El Cliente no existe";
            public const string PERSONA_NO_EXISTE = "La Persona no existe";
            public const string MOVIMIENTO_NO_EXISTE = "El Movimiento no existe";

            public const string SALDO_NO_DISPONIBLE = "No es posible obtener el saldo de su cuenta. Por favor Inténtelo nuevamente";
        }

        public static class VALIDATION_MESSAGES
        {
            public const string DEFAULT_VALUE = "0";
            public const string SALDO_INSUFICIENTE = "El saldo actual es insuficiente";
            public const string SALDO_CERO = "El saldo actual de su cuenta es 0";
            public const string CUPO_DIARIO_SUPERADO = "La operación excede el Cupo Diario permitido";
            public const string ID_CLIENTE_OBLIGATORIO = "Debe indicar un IdCliente Válido";
            public const string FECHA_INICIAL_OBLIGATORIA = "Debe indicar una Fecha Inicial ";
            public const string FECHA_FINAL_OBLIGATORIA = "Debe indicar una Fecha Final";
            public const string ERROR_RANGO_FECHAS = "La Fecha Inicial no puede ser mayor a la Fecha Final";
            public const string ERROR_MODELO_DATOS = "El Modelo de datos no puede ser nulo";
            public const string CLIENTE_SIN_CUENTA_ASOCIADA = "El Cliente consultado no tiene ninguna Cuenta asociada";
            public const string CUENTA_SIN_MOVIMIENTOS = "Las Cuentas asociadas al Cliente consultado no tienen movimientos en el periodo indicado";
        }

        public static class ACCOUNT_MESSAGES
        {
            public const string CUENTA_CREADA = "Cuenta Creada Correctamente";
            public const string CUENTA_ACTUALIZADA = "Cuenta Actualizada Correctamente";
            public const string CUENTA_ELIMINADA = "Cuenta Eliminada Correctamente";
        }

        public static class CLIENT_MESSAGES
        {
            public const string CLIENTE_CREADO = "Cliente Creado Correctamente";
            public const string CLIENTE_ACTUALIZADO = "Cliente Actualizado Correctamente";
            public const string CLIENTE_ELIMINADO = "Cliente Eliminado Correctamente";
        }

        public static class MOVEMENT_MESSAGES
        {
            public const string MOVIMIENTO_CREADO = "Movimiento Creado Correctamente";
            public const string MOVIMIENTO_ACTUALIZADO = "Movimiento Actualizado Correctamente";
            public const string MOVIMIENTO_ELIMINADO = "Movimiento Eliminado Correctamente";
        }
    }
}
