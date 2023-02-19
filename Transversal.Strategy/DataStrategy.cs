using Transversal.Exceptions;

namespace Transversal.Strategy
{
    public class DataStrategy : MainStrategy
    {
        public override StateStrategy Execute()
        {
            State = StateStrategy.Execution;

            try
            {
                this.Process();
                State = StateStrategy.Success;
            }
            catch (ApiException ex)
            {
                State = StateStrategy.Exception;
                SetException(ex.Message);
            }
            catch (Exception ex)
            {
                State = StateStrategy.Exception;
                SetException($"Error de Datos No Controlado: {ex.Message}, Por Favor Intente Nuevamente");
            }

            return State;
        }

        protected override void Process()
        {

        }
    }
}
