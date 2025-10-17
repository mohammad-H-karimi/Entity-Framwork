using System;
using Entity_Framework;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        using (var context = new LibraryContext())
        {
            var author = new Author
            {
                Name = "George Orwell",
                BirthdayDate = new DateTime(1903, 6, 25),
                Nationality = "British",
                Biography = "Author of 1984 and Animal Farm"
            };


            var book = new Book
            {
                Title = "1984",
                ISBN = "9780451524935",
                PublishYear = 1949,
                Price = 150000
            };

            author.Books.Add(book);


            var member = new Member
            {
                FullName = "Ali Ahmadi",
                Email = "ali@example.com",
                JoinDate = DateTime.Now,
                IsActive = true,
                MembershipCard = new MembershipCard
                {
                    CardNumber = "CARD1234",
                    IssueDate = DateTime.Now,
                    ExpiryDate = DateTime.Now.AddYears(1),
                    Status = "Active"
                }
            };

            var loan = new BookLoan
            {
                Book = book,
                Member = member,
                BorrowDate = DateTime.Now
            };

            context.Authors.Add(author);
            context.Members.Add(member);
            context.BookLoans.Add(loan);
            context.SaveChanges();


            var members = context.Members
                .Select(m => new
                {
                    m.FullName,
                    m.Email,
                    CardNumber = m.MembershipCard.CardNumber
                })
                .ToList();

            Console.WriteLine("📋 اعضا:");
            foreach (var m in members)
                Console.WriteLine($"- {m.FullName} ({m.Email}) | کارت: {m.CardNumber}");
        }

    }
}
