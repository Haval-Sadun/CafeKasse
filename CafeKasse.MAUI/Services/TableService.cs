using CafeKasse.MAUI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeKasse.MAUI.Services
{
    public class TableService
    {
        private readonly static IEnumerable<Table> _tables = new List<Table>()
        {
            new Table() { Id = 1, TableNumber = 1, TableStatus = Status.Available },
            new Table() { Id = 2, TableNumber = 2, TableStatus = Status.Resevered },
            new Table() { Id = 3, TableNumber = 3, TableStatus = Status.Accupied },
            new Table() { Id = 4, TableNumber = 4, TableStatus = Status.Resevered },
            new Table() { Id = 5, TableNumber = 5, TableStatus = Status.Resevered },
            new Table() { Id = 6, TableNumber = 6, TableStatus = Status.Resevered },
            new Table() { Id = 7, TableNumber = 7, TableStatus = Status.Resevered },
            new Table() { Id = 8, TableNumber = 8, TableStatus = Status.Resevered },
            new Table() { Id = 9, TableNumber = 9, TableStatus = Status.Resevered },
            new Table() { Id = 10, TableNumber = 10, TableStatus = Status.Resevered },
            new Table() { Id = 11, TableNumber = 11, TableStatus = Status.Available },
            new Table() { Id = 12, TableNumber = 12, TableStatus = Status.Resevered },
            new Table() { Id = 13, TableNumber = 13, TableStatus = Status.Accupied },
            new Table() { Id = 14, TableNumber = 14, TableStatus = Status.Resevered },
            new Table() { Id = 15, TableNumber = 15, TableStatus = Status.Resevered },
        };

        public IEnumerable<Table> GetAllTables () => _tables;

        public IEnumerable<Table> GetTablesByStatus(Status status = Status.Available) => 
            _tables.Where(t => t.TableStatus == status);
    }
}
