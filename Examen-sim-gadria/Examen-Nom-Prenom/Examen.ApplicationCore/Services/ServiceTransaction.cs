using Examen.ApplicationCore.Domain;
using Examen.ApplicationCore.Interfaces;
using Examen.Interfaces;
using Examen.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen.ApplicationCore.Services
{
    public class ServiceTransaction: Service<Transaction>, IServiceTransaction
    {
        public ServiceTransaction(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public IList<Transaction> getTransactionsEpargne(DateTime date)
        {
            return (IList<Transaction>)GetMany(t => (t.Compte.Type.Equals(TypeCompte.Epargne)) && (t.Date.Equals(date)));
        }

        public int nombreTotalDesTransaction(Compte compte)
        {
           return compte.Transactions.Where(t=>(DateTime.Now-t.Date).Days<7).Count();
        }

        public double totalTransactionTrsanfert(DAB dab)
        {
            IList<TransactionTransfert> transactionTransferts= new List<TransactionTransfert>();
            var query = from a in GetAll().OfType<TransactionTransfert>() select a.Montant;
            return query.Sum();
        }   
       
    }
}
