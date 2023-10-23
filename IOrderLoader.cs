using Air_Tek_Coding_Challenge.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Air_Tek_Coding_Challenge
{
    public interface IOrderLoader
    {
        List<Order> LoadOrders();
    }
}
