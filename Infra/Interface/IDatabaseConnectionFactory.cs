using System.Data;

namespace Infra.Interface
{
    public interface IDatabaseConnectionFactory
    {
        IDbConnection GetConnection();
    }
}
