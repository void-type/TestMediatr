using System.Collections.Generic;
using System.Linq;

namespace MediatrRailwayExample.Models.Data
{
    public class LoaneeData
    {
        public IQueryable<Loanee> Loanees => new List<Loanee>
        {
            new Loanee()
            {
                Name = "joe",
                    Credit = 403,
                    Email = "joeplumber@email.com"
            },
            new Loanee()
            {
                Name = "bill",
                    Credit = 207,
                    Email = "billeaton@email.com"
            },
            new Loanee()
            {
                Name = "bob",
                    Credit = 301,
                    Email = "bobbloomer@email.com"
            }
        }.AsQueryable();
    }
}
