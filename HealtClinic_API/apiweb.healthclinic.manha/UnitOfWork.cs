using apiweb.healthclinic.manha.Contexts;
using apiweb.healthclinic.manha.Interfaces;

namespace apiweb.healthclinic.manha;

public class UnitOfWork : IUnitOfWork
{
    private readonly HealthContext _healthContext;

    public UnitOfWork(HealthContext context)
    {
        _healthContext = context;
    }

    public void Commit()
    {
        _healthContext.SaveChanges();
    }

    public async Task CommitAsync(CancellationToken cancellationToken = default)
    {
        await _healthContext.SaveChangesAsync(cancellationToken);
    }

    public void Dispose()
    {
        _healthContext.Dispose();
    }
}
