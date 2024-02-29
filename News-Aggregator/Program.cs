
using Microsoft.EntityFrameworkCore;
using News_Aggregator_Data;
using News_Aggregator_Data.Entities;
using System.Reflection.Metadata;

namespace News_Aggregator

{
    public class Program
    {
        static async Task Main(string[] args)
        {
            //await CreateUserData();
            //await CreateArticleData();
            //await CreateCommentData();

            //await DeleteCommentData();

            //await UpdateUserData();
            var users = await ReadUserData();
            foreach (var user in users)
            {
                Console.WriteLine($"Username: {user.US_user_name}, Positivity treshold: {user.US_positivity_treshold}");
            
            }          

  

        }

        static async Task DeleteCommentData()
        {

            using (var db = new News_AggregatorDbContext())
            {
                db.Database.EnsureCreated();
                var badComment = await db.COmments
                    .Where(c => c.CO_comment.Contains("Sample"))
                    .FirstOrDefaultAsync();
                if (badComment != null)
                {
                    db.COmments.Remove(badComment);
                    await db.SaveChangesAsync();
                }
            }

        }

        static async Task CreateCommentData()
        {

            using (var db = new News_AggregatorDbContext())
            {
                db.Database.EnsureCreated();
                var comment = new COmment
                {
                CO_comment_id = System.Guid.NewGuid(),
                CO_art_id = Guid.Parse("85C1C0A1-E291-4F42-BCB4-4A0DAF1F46C2"),
                CO_user_id = Guid.Parse("A2588A74-1DD0-4C61-9EA5-503890D88429"),
                CO_comment = "Sample comment",
                CO_comm_status = true
                };
    

                await db.COmments.AddAsync(comment);
                await db.SaveChangesAsync();
            }

        }
        static async Task CreateArticleData()
        {

            using (var db = new News_AggregatorDbContext())
            {
                db.Database.EnsureCreated();
                var article = new ARticle
                {
                    AR_art_id = System.Guid.NewGuid(),
                    AR_content = "Sample content",
                    AR_source_adr = "abcd.pl",
                    AR_user_id = Guid.Parse("A2588A74-1DD0-4C61-9EA5-503890D88429"),
                    AR_positivity = 25,
                    AR_art_status = true
                };


                await db.ARticles.AddAsync(article);
                await db.SaveChangesAsync();
            }

        }

        static async Task CreateUserData()
        {

            using (var db = new News_AggregatorDbContext())
            {
                db.Database.EnsureCreated();
                var user = new USer
                {
                    US_user_id = System.Guid.NewGuid(),
                    US_user_name = "Jan Kowalski",
                    US_user_role = "admin",
                    US_email = "sample2.email@example.com",
                    US_user_status = true,
                    US_positivity_treshold = 25
                };


                await db.USers.AddAsync(user);
                await db.SaveChangesAsync();
            }

        }

        static async Task UpdateUserData()
        {

            using (var db = new News_AggregatorDbContext())
            {
                db.Database.EnsureCreated();
                var user = await db.USers
                    .Where(USer => USer.US_user_name == "Jan Kowalski")
                    .FirstOrDefaultAsync();
                if (user != null)
                {
                    user.US_user_name = "Jan Nowak";
                    await db.SaveChangesAsync();
                }
            }

        }

        static async Task <List <USer>> ReadUserData()
        {

            using (var db = new News_AggregatorDbContext())
            {
                db.Database.EnsureCreated();
                var users = await db.USers
                    .Where(USer => !string.IsNullOrEmpty(USer.US_user_name))
                    .ToListAsync();
                return users;

             
            }

        }

    }
}
