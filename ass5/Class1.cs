using System;
using System.ComponentModel;
namespace ass5
{
    public struct Delivaryaddress
    {
        public string city;
        public string street;
        public int buildingnumber;

        public Delivaryaddress(string city, string street, int buildingnumber)
        {
            this.city = city;
            this.street = street;
            this.buildingnumber = buildingnumber;
        }
        public override string ToString()
        {
           return $"This order in {city} city,at {street} street,buildingnumber {buildingnumber}";
        }
    }
    public struct Shipman
    {
        private string trackingcode;
        private string description;
        private int weight;
        private decimal deliveryfee;
        public string Trackingcode
        {
            get
            {
                return trackingcode;
            }

        }

        public string descripe
        {
            get
            {
                return description;
            }
            set
            {
                description = string.IsNullOrWhiteSpace(value) ? description : value;
            }
        }
        public int Weight
        {
            get
            {
                return weight;
            }
            set
            {
                weight = value > 0 ? value : weight;
            }
        }
        public decimal del
        {
            get
            {
                return deliveryfee;
            }
            private set
            {
                deliveryfee = value > 0 ? value : deliveryfee;
            }
        }


        public decimal Estimate
        {
            get { return deliveryfee + (weight * 5); }
        }
        public Delivaryaddress destination { get; set; }
        public Shipman(string trackingcode)
        {
            this.trackingcode = string.IsNullOrWhiteSpace(trackingcode) ? "invalid" : trackingcode;
            description = "unknown";
            weight = 1;
            deliveryfee = 50;
        }
        public Shipman(string trackingcode, string description, int weight, int delivery, Delivaryaddress destination)
        {
            this.trackingcode = trackingcode;
            this.description = description;
            this.weight = weight;
            this.deliveryfee = delivery;
            this.destination = destination;
        }
        public Shipman(string trackingcode,string description,int weight)
        {
            this.trackingcode = trackingcode;
            this.description = description;
            this.weight = weight;
        }
        public void updatedeliveryfee(decimal newfee)
        {
            if (newfee > 0)
            {
                deliveryfee += newfee;
            }
        }
        public void printshipman()
        {
            Console.WriteLine($"the tracking code is:{trackingcode},the description of our order is:{description},the weight of the delivery is:{weight}");
        }
    }
        public struct DeliveryCenter
        {
            private Shipman[] shipment;
            public DeliveryCenter()
            {
                shipment = new Shipman[10];
            }
            public Shipman this[int pos]
            {
                get
                {
                    if (pos >= shipment.Length || pos < 0)
                    {
                        return default;
                    }
                    return shipment[pos];

                }
                set
                {
                    if (pos >= shipment.Length || pos < 0)
                    {
                        Console.WriteLine("nothing");
                    }
                    else
                    {
                        shipment[pos] = value;
                    }
                }
            }
            public Shipman this[string track]
            {

                get
                {
                    for (int i = 0; i < shipment.Length; i++)
                    {
                        if (shipment[i].Trackingcode == track)
                        {
                            return shipment[i];
                        }

                    }
                    return default;

                }

            }
            public bool addshipment(Shipman sh)
            {
                for (int i = 0; i < shipment.Length; i++)
                {
                    if (string.IsNullOrEmpty(shipment[i].Trackingcode))
                    {
                        shipment[i] = sh;
                        return true;
                    }
                    
                }
                return false;
        }
        
    }
    
}
