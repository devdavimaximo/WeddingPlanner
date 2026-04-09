using System.Security.Principal;

namespace WeddingPlanner.Models
{
    public class DistributionResult
    {
        public decimal TotalAmount { get; set; }
        public decimal TotalUsed { get; set; }
        public decimal RemainingAmount { get; set; }
        public List<ServiceDistribution> Services { get; set; } = new();

        public DistributionResult()
        {
        }

        public DistributionResult(decimal totalAmount, decimal totalUsed, decimal remainingAmount, List<ServiceDistribution> services)
        {
            TotalAmount = totalAmount;
            TotalUsed = totalUsed;
            RemainingAmount = remainingAmount;
            Services = services ?? new();
        }

        public override string ToString()
        {
            return $"TotalAmount: {TotalAmount}, TotalUsed: {TotalUsed}, Remaining: {RemainingAmount}, Services: {Services?.Count ?? 0}";
        }

        public decimal CalculateRemaining()
        {
            return TotalAmount - TotalUsed;
        }
    }
}
