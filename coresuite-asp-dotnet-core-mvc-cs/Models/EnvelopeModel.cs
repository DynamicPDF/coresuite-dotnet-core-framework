namespace coresuite_asp_dotnet_core_mvc_cs.Models
{
    public class EnvelopeModel
    {
        private Address fromAddress = null;
        private Address toAddress = null;

        public Address FromAddress
        {
            get
            {
                if (fromAddress == null)
                {
                    fromAddress = new Address() { Address1 = "13071 Wainwright Road", Address2 = "Suite 100", City = "Columbia", Name = "", State = "MD", Zip = "20777" };
                }
                return fromAddress;
            }

            set => fromAddress = value;
        }

        public Address ToAddress
        {
            get
            {
                if (toAddress == null)
                {
                    toAddress = new Address() { Address1 = "123 Main Street", Address2 = "", City = "Anywhere", Name = "Any Company", State = "MD", Zip = "20815-4704" };
                }
                return fromAddress;
            }

            set => toAddress = value;
        }
    }
}