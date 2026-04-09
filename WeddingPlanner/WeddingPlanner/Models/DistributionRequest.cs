namespace WeddingPlanner.Models
{
    public class DistributionRequest
    {
        public decimal TotalAmount { get; set; }
        public int GuestsCount { get; set; }
        public List<ServiceItem> Services { get; set; } = new();
        public List<string> ExcludedServices { get; set; } = new();

        public DistributionRequest() 
        { 
        }

        public DistributionRequest(decimal totalAmount, int guestsCount, List<ServiceItem> services, List<string> excludedServices)
        {
            TotalAmount = totalAmount;
            GuestsCount = guestsCount;
            Services = services ?? new();
            ExcludedServices = excludedServices ?? new();
        }

        public override string ToString()
        {
            return $"TotalAmount: {TotalAmount}, Guests: {GuestsCount}, Services: {Services?.Count ?? 0}";
        }

        public bool Validate()
        {
            if (TotalAmount <= 0)
                return false;
            if (GuestsCount <= 0)
                return false;
            if (Services.Count == 0)
                return false;
            if (Services.Any(s => !s.IsValid()))
                return false;
            if (ExcludedServices.Any(string.IsNullOrWhiteSpace))
                return false;
            return true;
        }
    }
}
