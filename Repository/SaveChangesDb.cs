using juridical_api.Db;
using Microsoft.EntityFrameworkCore;

namespace juridical_api.Repository
{
    public class SaveChangesDb
    {
        public async Task Save(AppDbContext appDbContext)
        {
            try
            {
                await appDbContext.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                Console.Error.WriteLine($"Error saving changes: {ex.Message}");
                throw;
            }
        }
    }
}
