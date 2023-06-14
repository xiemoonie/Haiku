using System.Collections.Generic;
using System.Threading.Tasks;

namespace RandomHaikuGenerator
{
    public class WalletTransaction
    {
        private IWalletController _wallerController;

        public WalletTransaction(IWalletController wallet)
        {
            this._wallerController = wallet;
            Transactions = new List<Transaction>();
        }
        public List<Transaction> Transactions
        {
            set;
            get;
        }
        public async Task GetTransactions()
        {
            var transactions = await _wallerController.GetTransactions();
       
            Transactions = transactions;
        }
    }
    public class Coin
    {

    }
    public class Transaction
    {
        public int Id;
        public int Amount;
        public string Symbol;
    }

    public interface IWalletController
    {
        Task<List<Coin>> GetCoins(bool forceReload = false);
        Task<List<Transaction>> GetTransactions(bool forceReload = false);
    }
    public class StubWallet : IWalletController
    {
        Task<List<Coin>> IWalletController.GetCoins(bool forceReload)
        {
            throw new System.NotImplementedException();
        }

        Task<List<Transaction>> IWalletController.GetTransactions(bool forceReload = false)
        {
            var task = Task.FromResult(new List<Transaction>
            {
                new Transaction { Id = 1, Amount = 2, Symbol = "BTC" },
                new Transaction { Id = 2, Amount = 3, Symbol = "ETH" },
                new Transaction { Id = 3, Amount = 7, Symbol = "ETH" },
            });
            
            return task;
        }
    }
}



