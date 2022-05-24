namespace PaymentSlip.Model
{
    public class Slip
    {
        public long Id { get; set; }
        public string PayerName { get; set; } = String.Empty;
        public string RecipientName { get; set; } = String.Empty;
        public string Amount { get; set; } = String.Empty;
        public string DateProcessed { get; set; } = String.Empty;
        public string Model { get; set; } = String.Empty;
        public string ReferencNumber { get; set; } = String.Empty;
        public string Description { get; set; } = String.Empty;
    }
}
