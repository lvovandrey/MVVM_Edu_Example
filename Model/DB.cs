using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMexample.Model
{
    public class Context : DbContext
    {
        public Context()
            : base("DbConnection")
        { }

        public DbSet<Level> Levels { get; set; }
        public DbSet<Video> Videos { get; set; }
    }

    public class Repository
    {
        public static IQueryable<TEntity> Select<TEntity>()
            where TEntity : class
        {
            Context context = new Context();

            // Здесь мы можем указывать различные настройки контекста,
            // например выводить в отладчик сгенерированный SQL-код
            context.Database.Log =
                (s => System.Diagnostics.Debug.WriteLine(s));

            // Загрузка данных с помощью универсального метода Set
            return context.Set<TEntity>();
        }
    }
}
