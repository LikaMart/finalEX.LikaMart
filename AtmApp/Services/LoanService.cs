using AtmApp.Consts;
using AtmApp.Models;

namespace AtmApp.Services;

public class LoanService : GenericService<LoanRequest>
{
    public LoanService() : base(FilePaths.LoansFile)
    {
    }

    protected override LoanRequest Deserialize(string line)
    {
        return LoanRequest.Deserialize(line);
    }

    public void RequestLoan(string username, double amount)
    {
        LoanRequest request = new LoanRequest(username, amount, "pending");
        items.Add(request);
        Save();
    }

    public List<LoanRequest> GetPendingLoans()
    {
        List<LoanRequest> pending = new List<LoanRequest>();
        foreach (LoanRequest request in items)
        {
            if (request.Status == "pending")
            {
                pending.Add(request);
            }
        }
        return pending;
    }

    public bool ApproveLoan(string username, UserService userService)
    {
        foreach (LoanRequest request in items)
        {
            if (request.Id == username && request.Status == "pending")
            {
                request.Status = "approved";
                Save();

                foreach (User user in userService.GetAll())
                {
                    if (user.Username == username)
                    {
                        userService.Deposit(user, request.Amount);
                        break;
                    }
                }

                return true;
            }
        }
        return false;
    }
}
