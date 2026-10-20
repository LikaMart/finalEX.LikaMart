using AtmApp.Consts;
using AtmApp.Models;

namespace AtmApp.Services;

// სესხების სერვისი, GenericService-დან იღებს ჩატვირთვას და შენახვას
public class LoanService : GenericService<LoanRequest>
{
    // base-ს ვაწვდი სესხების ფაილის სახელს
    public LoanService() : base(FilePaths.LoansFile)
    {
    }

    // აქ ვეუბნები როგორ წაიკითხოს ხაზი
    protected override LoanRequest Deserialize(string line)
    {
        return LoanRequest.Deserialize(line);
    }

    // ახალი მოთხოვნა, თავიდან ყოველთვის pending სტატუსით
    public void RequestLoan(string username, double amount)
    {
        LoanRequest request = new LoanRequest(username, amount, "pending");
        items.Add(request);
        Save();
    }

    // მხოლოდ დაუმტკიცებელ სესხებს ვაბრუნებ
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

    // სესხის დამტკიცება, userService აქ იმიტომ გადმოვეცი რომ თანხა ბალანსზე დავუმატო
    public bool ApproveLoan(string username, UserService userService)
    {
        foreach (LoanRequest request in items)
        {
            // ვეძებ ამ მომხმარებლის pending მოთხოვნას
            if (request.Id == username && request.Status == "pending")
            {
                request.Status = "approved";
                Save();

                // ახლა მომხმარებელს ვპოულობ და ბალანსზე ვურიცხავ
                foreach (User user in userService.GetAll())
                {
                    if (user.Username == username)
                    {
                        userService.Deposit(user, request.Amount);
                        // ვიპოვე და აღარ მჭირდება ძებნის გაგრძელება
                        break;
                    }
                }

                return true;
            }
        }
        // თუ ვერ ვიპოვე false
        return false;
    }
}
