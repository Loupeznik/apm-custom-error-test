using Elastic.Apm.Api;

namespace ApmErrorTransaction
{
    public class TransactionFactory
    {
        public async Task CreateTransaction(TransactionTest service)
        {
            await Elastic.Apm.Agent.Tracer
                .CaptureTransaction("testjob2", ApiConstants.TypeRequest, async (t) =>
                {
                    try
                    {
                        //var service = app.Services.GetService<TransactionTest>();
                        await service.Execute();
                        /*
                        await new HttpClient().PostAsync("http://sajdajdlkajsdklajdlkajkdlajdlkaj.com/xd",
                            new StringContent("xd"));
                        */
                    }
                    catch (Exception ex)
                    {
                        //t.Outcome = Outcome.Failure; //je možné nastavit ale agent nastavenou hodnotu ignoruje
                        //t.End(); // NEUKONČOVAT TRANSACTION PŘEDČASNĚ, CaptureTransaction() metoda transakci zavře sam
                        throw;
                    }


                });
        }
    }
}
