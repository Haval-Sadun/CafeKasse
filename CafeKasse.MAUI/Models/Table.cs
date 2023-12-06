using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;

namespace CafeKasse.MAUI.Models
{
    public partial class Table : ObservableObject 
    {
        public int Id { get; set; }
        public int TableNumber { get; set; }

        public Status TableStatus {  get; set; }

    }
}
