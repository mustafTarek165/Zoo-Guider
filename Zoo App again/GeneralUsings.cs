using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Zoo_App_again.Data;

namespace Zoo_App_again
{

    public class GeneralUsings
    {
        
        public async Task UpdateDataBaseAsync<T>(DataGridView dataGridView,AppDbContext dbContext,DbSet<T> dbSet ) where T : class
        {
            await dbContext.SaveChangesAsync();
            dataGridView.DataSource = await dbSet.ToListAsync();
            
        }

        public void UpdateDataBasesync<T>(DataGridView dataGridView, AppDbContext dbContext, DbSet<T> dbSet) where T : class
        {
             dbContext.SaveChanges();
            dataGridView.DataSource =  dbSet.ToList();

        }
    }
}
