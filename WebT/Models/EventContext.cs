using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace WebT.Models
{
    public class EventContext : DbContext
    {
        /*Свойство DbSet представляет собой коллекцию объектов, 
         * которая сопоставляется с определенной таблицей в базе данных*/
        public DbSet<Event> Events { get; set; }

        /*Через параметр options в конструктор 
         * контекста данных будут передаваться настройки контекста.*/
        public EventContext(DbContextOptions<EventContext> options)
            : base(options)
        {
            /*с помощью вызова Database.EnsureCreated() по определению моделей 
             * будет создаваться база данных (если она отсутствует).*/
            Database.EnsureCreated();
        }
    }
}
