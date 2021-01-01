using System;
using System.Collections.Generic;
using System.Text;

namespace WebApi.Classes
{
    public class AddressInfo
    {
        public AddressInfo() { }

        public string Address { get; set; } = "";
        public string City { get; set; } = "";
        public string State { get; set; } = "";
        public string Zip { get; set; } = "";
        public string Country { get; set; } = "";

        public override string ToString()
        {
            return $"{Address};{City};{State};{Zip};{Country}";
        }

        public string ToStringNormal()
        {
            StringBuilder builder = new StringBuilder();
            if (Address.Length > 0)
            {
                builder.Append(Address);
                builder.Append(", ");
            }
            if (City.Length > 0)
            {
                builder.Append(City);
                builder.Append(", ");
            }
            if (State.Length > 0)
            {
                builder.Append(State);
                builder.Append(", ");
            }
            if (Zip.Length > 0)
            {
                builder.Append(Zip);
                builder.Append(", ");
            }
            if (Country.Length > 0)
            {
                builder.Append(Country);
            }
            return builder.ToString();
        }

        public static AddressInfo FromString(string address)
        {
            string[] split = address.Split(';');
            if (split.Length != 5) throw new ArgumentException();

            return new AddressInfo()
            {
                Address = split[0],
                City = split[1],
                State = split[2],
                Zip = split[3],
                Country = split[4]
            };
        }
    }
}
