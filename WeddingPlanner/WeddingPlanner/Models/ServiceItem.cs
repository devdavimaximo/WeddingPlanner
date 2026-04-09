using WeddingPlanner.Models.Enums;

namespace WeddingPlanner.Models
{
    public class ServiceItem
    {
        public string Name { get; set; } = string.Empty;
        public ServiceType Type { get; set; }
        public decimal Percentage { get; set; }
        public bool IsRequired { get; set; }

        public ServiceItem()
        {
        }

        public ServiceItem(string name, ServiceType type, decimal percentage, bool isRequired)
        {
            Name = name;
            Type = type;
            Percentage = percentage;
            IsRequired = isRequired;
        }

        public override string ToString()
        {
            return $"{Name} ({Type}): {Percentage:C} {(IsRequired ? "[Required]" : "")}";
        }

        public decimal CalculateCost(decimal totalAmount, int guestsCount)
        {
            if (!IsValid())
                throw new InvalidOperationException("Invalid service configuration");

            return Type switch
            {
                ServiceType.Fixed => Percentage,
                ServiceType.PerGuest => Percentage * guestsCount,
                ServiceType.Percentage => totalAmount * (Percentage / 100m),
                _ => throw new InvalidOperationException("Invalid service type")
            };
        }

        public bool IsValid()
        {
            if (string.IsNullOrWhiteSpace(Name))
                return false;
            if (Percentage < 0)
                return false;
            if (Type == ServiceType.Percentage && Percentage > 100)
                return false;
            if (!Enum.IsDefined(typeof(ServiceType), Type))
                return false;
            return true;
        }
    }
}