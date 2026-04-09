
using WeddingPlanner.Models;
using WeddingPlanner.Models.Enums;

namespace WeddingPlanner
{
    public class Program
    {
        public static void Main(string[] args)
        {

            var services = new List<ServiceItem>
{
    new ServiceItem("Buffet", ServiceType.PerGuest, 50, true),
    new ServiceItem("Fotógrafo", ServiceType.Fixed, 2000, true),
    new ServiceItem("Decoração", ServiceType.Percentage, 10, false)
};

            var request = new DistributionRequest(
                totalAmount: 10000,
                guestsCount: 100,
                services: services,
                excludedServices: new List<string>()
            );

            Console.WriteLine("=== REQUEST ===");
            Console.WriteLine(request);

            if (!request.Validate())
            {
                Console.WriteLine("Request inválido!");
                return;
            }

            Console.WriteLine("\n=== CALCULANDO SERVIÇOS ===");

            decimal totalUsed = 0;

            foreach (var service in request.Services)
            {
                var cost = service.CalculateCost(request.TotalAmount, request.GuestsCount);
                totalUsed += cost;

                Console.WriteLine($"{service.Name}: {cost:C}");
            }

            Console.WriteLine("\n=== RESULTADO ===");
            Console.WriteLine($"Total disponível: {request.TotalAmount:C}");
            Console.WriteLine($"Total usado: {totalUsed:C}");
            Console.WriteLine($"Restante: {(request.TotalAmount - totalUsed):C}");
        }
    }
}
