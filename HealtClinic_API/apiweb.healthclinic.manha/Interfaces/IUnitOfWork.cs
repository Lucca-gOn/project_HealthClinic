namespace apiweb.healthclinic.manha.Interfaces;

public interface IUnitOfWork : IDisposable
{
    void Commit();

    Task CommitAsync(CancellationToken cancellationToken = default);
}
