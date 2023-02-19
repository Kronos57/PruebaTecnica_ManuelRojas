using Data.EntityFramework.Entities;

namespace Repository
{
    public interface IMovementRepository
    {
        Task<IEnumerable<Movimiento>> GetAllMovementsAsync();
        Task<Movimiento> GetMovementByIdAsync(int id);
        Task CreateMovementAsync(Movimiento movimiento);
        Task UpdateMovementAsync(Movimiento movimiento);
        Task DeleteMovementAsync(int id);
    }
}
