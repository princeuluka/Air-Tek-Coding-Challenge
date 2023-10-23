using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Air_Tek_Coding_Challenge.Models
{
    public class Flight
    {
        public int FlightNumber { get; set; }
        public string DepartureCity { get; set; }
        public string ArrivalCity { get; set; }
        public int Day { get; set; }
        public int RemainingCapacity { get; set; }
        public List<Order> ScheduledOrders { get; set; }

        public Flight(int flightNumber, string departureCity, string arrivalCity, int day)
        {
            FlightNumber = flightNumber;
            DepartureCity = departureCity;
            ArrivalCity = arrivalCity;
            Day = day;
            RemainingCapacity = 20;
            ScheduledOrders = new List<Order>();
        }

        public bool CanScheduleOrder(Order order)
        {
            return RemainingCapacity > 0 && ArrivalCity == order.DestinationCity;
        }

        public void ScheduleOrder(Order order)
        {
            ScheduledOrders.Add(order);
            RemainingCapacity--;
        }


    }
  
}
