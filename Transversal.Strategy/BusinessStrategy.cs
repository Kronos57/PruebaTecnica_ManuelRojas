namespace Transversal.Strategy
{
    public class BusinessStrategy : MainStrategy
    {
        public override StateStrategy Execute()
        {
            State = StateStrategy.Execution;

            try
            {
                this.Process();
            }
            catch (Exception ex)
            {
                SetException($"Error de Negocio No Controlado: {ex.Message}, Por Favor Intente Nuevamente");
            }

            return State;
        }

        protected override void Process()
        {

        }
    }
}
