﻿namespace Transversal.Entities.DTO
{
    public class MovementDTO
    {
        public int IdMovimiento { get; set; }

        public int IdCuenta { get; set; }

        public int IdTipoMovimiento { get; set; }

        public decimal Valor { get; set; }

        public DateTime FechaMovimiento { get; set; }

        public decimal SaldoDisponible { get; set; }

        public bool Estado { get; set; }


        public MovementDTO()
        {

        }

        public MovementDTO(int idMovimiento)
        {
            IdMovimiento = idMovimiento;
        }

        public MovementDTO(int idMovimiento, int idCuenta, int idTipoMovimiento, decimal valor, DateTime fechaMovimiento,
            decimal saldoDisponible, bool estado)
        {
            IdMovimiento = idMovimiento;
            IdCuenta = idCuenta;
            IdTipoMovimiento = idTipoMovimiento;
            Valor = valor;
            FechaMovimiento = fechaMovimiento;
            SaldoDisponible = saldoDisponible;
            Estado = estado;
        }
    }
}
