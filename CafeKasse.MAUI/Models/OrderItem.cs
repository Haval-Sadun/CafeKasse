using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeKasse.MAUI.Models
{
    public partial class OrderItem : ObservableObject
    {
        public int Id { get; set; }
        public int ItemId { get; set; }
        public int OrderId { get; set; }
        public double Price { get; set; }

        [ObservableProperty, NotifyPropertyChangedFor(nameof(Amount))]
        private int _quantity;
        public double Amount => Price * Quantity;
        public OrderItem Clone() => (OrderItem)MemberwiseClone();
    }
}
