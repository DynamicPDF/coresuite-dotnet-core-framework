namespace coresuite_asp_dotnet_core_mvc_cs.Models
{
    public class W9FormModel
    {
        public string Name { get; set; } = "Any Company, Inc.";

        public string BusinessName { get; set; } = "Any Company";

        public BusinessType BusinessType { get; set; } = BusinessType.Individual;

        public string OtherBusinessType { get; set; } = string.Empty;

        public string TaxClassification { get; set; } = string.Empty;

        public string Address { get; set; } = "123 Main Street";

        public string CityState { get; set; } = "Washington, DC  22222";

        public string RequestersNameAndAddress { get; set; } = string.Empty;

        public string AccountNumbers { get; set; } = string.Empty;

        public string SSN { get; set; } = string.Empty;

        public string EmployersID { get; set; } = "52-1234567";
    }
}