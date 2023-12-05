using CafeKasse.MAUI.Entities;
using CommunityToolkit.Maui.Core;
using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeKasse.MAUI.Services
{
    public partial class OrderService : ObservableObject
    {
        public static IEnumerable<Order> _orders = new List<Order>();

        public IEnumerable<Order> GetAllOrders() => _orders;

        public IEnumerable<Order> GetOrdersByTableNumber(int  tableNumber) => _orders.Where(o => o.TableNumber == tableNumber);

        public Order GetOrderbyId(int id) => _orders.FirstOrDefault(o => o.Id == id);




    }
}
