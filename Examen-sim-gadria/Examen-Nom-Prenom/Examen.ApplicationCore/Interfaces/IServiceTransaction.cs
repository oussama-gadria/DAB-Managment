using Examen.ApplicationCore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen.ApplicationCore.Interfaces
{
    public interface IServiceTransaction
    {
        double totalTransactionTrsanfert(DAB dab);
        int nombreTotalDesTransaction(Compte compte);
        IList<Transaction> getTransactionsEpargne(DateTime date);

    }
}
