
namespace ApmErrorTransaction
{
    public class TransactionTest
    {
        private readonly ILogger _logger;

        public TransactionTest(ILogger<TransactionTest> logger)
        {
            _logger = logger;
        }

        public Task Execute()
        {
            var transaction = Elastic.Apm.Agent.Tracer.CurrentTransaction;

            /*
            !!! Tady se catchne error a vrátí se Task.CompletedTask -> APM si myslí že všechno proběhlo ok a má být success !!!
            try
            {
                throw new ApplicationException("Kill exception");
            }
            catch (Exception ex)
            {
                _logger.LogError("asdsada", new Exception("Test exception"));
            }
            */

            throw new ApplicationException("Kill exception"); // throwne chybu, APM ví že je to error


            return Task.CompletedTask;
        }

    }
}
