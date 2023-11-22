using apiweb.healthclinic.manha.Contexts;
using apiweb.healthclinic.manha.Interfaces;

namespace apiweb.healthclinic.manha;

public class UnitOfWork : IUnitOfWork
{
    private readonly HealthContext _context;

    public UnitOfWork(HealthContext context)
    {
        _context = context;
    }

    public void Commit()
    {
        _context.SaveChanges();
    }

    public async Task CommitAsync(CancellationToken cancellationToken = default)
    {
        await _context.SaveChangesAsync(cancellationToken);
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}
