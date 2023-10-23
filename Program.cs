using Air_Tek_Coding_Challenge.Models;


namespace Air_Tek_Coding_Challenge
{
    public class Program
    {
        static void Main(string[] args)
        {

            FlightManager flightManager = new FlightManager();

            // Add flights to the manager
            flightManager.AddFlight(new Flight(1, "YUL", "YYZ", 1));
            flightManager.AddFlight(new Flight(2, "YUL", "YYC", 1));
            flightManager.AddFlight(new Flight(3, "YUL", "YVR", 1));
            flightManager.AddFlight(new Flight(4, "YUL", "YYZ", 2));
            flightManager.AddFlight(new Flight(5, "YUL", "YYC", 2));
            flightManager.AddFlight(new Flight(6, "YUL", "YVR", 2));

            // Load orders
            IOrderLoader orderLoader = new JsonOrderLoader();
            List<Order> orders = orderLoader.LoadOrders();

            // Schedule orders
            List<Order> unscheduledOrders = flightManager.ScheduleOrders(orders);

            // Output flight schedule
            Console.WriteLine("Loaded Flight Schedule:");
            flightManager.ListFlightSchedule();

            // Output flight itineraries
            Console.WriteLine("\nFlight Itineraries:");
            foreach (var order in orders)
            {
                var flight = flightManager.GetNextAvailableFlight(order);
                if (flight != null)
                {
                    Console.WriteLine($"order: {order.OrderId}, flightNumber: {flight.FlightNumber}, departure: {flight.DepartureCity}, arrival: {flight.ArrivalCity}, day: {flight.Day}");
                }
            }

            // Output unscheduled orders
            Console.WriteLine("\nUnscheduled Orders:");
            foreach (var order in unscheduledOrders)
            {
                Console.WriteLine($"order: {order.OrderId}, flightNumber: not scheduled");
            }
        }
    }
}
