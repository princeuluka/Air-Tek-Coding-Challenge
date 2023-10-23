using Air_Tek_Coding_Challenge.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Air_Tek_Coding_Challenge
{
    [TestClass]
    public class FlightManagerTests
    {
        [TestMethod]
        public void ScheduleOrdersTest()
        {
            FlightManager flightManager = new FlightManager();
            flightManager.AddFlight(new Flight(1, "YUL", "YYZ", 1));
            flightManager.AddFlight(new Flight(2, "YUL", "YYC", 1));
            flightManager.AddFlight(new Flight(3, "YUL", "YVR", 1));

            List<Order> orders = new List<Order>
        {
            new Order { OrderId = "order-001", DestinationCity = "YYZ" },
            new Order { OrderId = "order-002", DestinationCity = "YYC" },
            new Order { OrderId = "order-003", DestinationCity = "YVR" },
           
        };
            List<Order> unscheduledOrders = flightManager.ScheduleOrders(orders);

           
            Assert.AreEqual(0, unscheduledOrders.Count, "All orders should be scheduled.");
        }

        [TestMethod]
        public void ScheduleOrders_Should_HandleUnscheduledOrders()
        {
           
            FlightManager flightManager = new FlightManager();
            flightManager.AddFlight(new Flight(1, "YUL", "YYZ", 1));

            List<Order> orders = new List<Order>
        {
            new Order { OrderId = "order-001", DestinationCity = "YYZ" },
            new Order { OrderId = "order-002", DestinationCity = "YYC" },
           
        };

           
            List<Order> unscheduledOrders = flightManager.ScheduleOrders(orders);

           
            Assert.AreEqual(1, unscheduledOrders.Count, "One order should remain unscheduled.");
        }

        [TestMethod]
        public void GetNextAvailableFlight_Should_ReturnAvailableFlight()
        {
            
            FlightManager flightManager = new FlightManager();
            Flight availableFlight = new Flight(1, "YUL", "YYZ", 1);
            flightManager.AddFlight(availableFlight);

            Order order = new Order { OrderId = "order-001", DestinationCity = "YYZ" };

            
            Flight nextFlight = flightManager.GetNextAvailableFlight(order);

           
            Assert.IsNotNull(nextFlight, "A flight should be available for scheduling.");
        }

        [TestMethod]
        public void GetNextAvailableFlight_Should_ReturnNullForUnavailableFlight()
        {
           
            FlightManager flightManager = new FlightManager();
            Flight unavailableFlight = new Flight(1, "YUL", "YYZ", 1);
            flightManager.AddFlight(unavailableFlight);

            Order order = new Order { OrderId = "order-001", DestinationCity = "YYC" };

            
            Flight nextFlight = flightManager.GetNextAvailableFlight(order);

           
            Assert.IsNull(nextFlight, "No flight should be available for scheduling.");
        }
    }
}
