using Air_Tek_Coding_Challenge.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Air_Tek_Coding_Challenge
{
    public class FlightManager
    {
        private List<Flight> flights = new List<Flight>();

        public void AddFlight(Flight flight)
        {
            flights.Add(flight);
        }

        public List<Order> ScheduleOrders(List<Order> orders)
        {
            List<Order> unscheduledOrders = new List<Order>();

            foreach (var order in orders)
            {
                Flight flight = GetNextAvailableFlight(order);

                if (flight != null)
                {
                    flight.ScheduleOrder(order);
                }
                else
                {
                    unscheduledOrders.Add(order);
                }
            }

            return unscheduledOrders;
        }

        public Flight GetNextAvailableFlight(Order order)
        {
            foreach (var flight in flights)
            {
                if (flight.CanScheduleOrder(order))
                {
                    return flight;
                }
            }
            return null;
        }

        public void ListFlightSchedule()
        {
            foreach (var flight in flights)
            {
                Console.WriteLine($"Flight: {flight.FlightNumber}, departure: {flight.DepartureCity}, arrival: {flight.ArrivalCity}, day: {flight.Day}");
            }
        }
    }
}
