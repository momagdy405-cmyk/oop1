using System.Runtime.CompilerServices;

namespace ass5
{
    internal class Program
    {

        static void Main(string[] args)
        {
            
            Delivaryaddress d1 = new Delivaryaddress("shubra","elter3a",190);
            Console.WriteLine(d1.ToString());
            Delivaryaddress d2 = d1;
            d2.city = "cairo";
            d2.street = "madinty";
            d2.buildingnumber = 20;
            Console.WriteLine(d1.ToString());


            DeliveryCenter dl = new DeliveryCenter();
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine($"shipment {i + 1} is:");
                string? trackingcode = Console.ReadLine();
                string? description = Console.ReadLine();
                int weight = int.Parse(Console.ReadLine());
                Shipman shipman = new Shipman(trackingcode,description,weight);
                dl.addshipment(shipman);
            }
            for(int i = 0; i < 3; i++)
            {
                dl[i].printshipman();
            }
            string ?trackingcoder = Console.ReadLine();
            if (string.IsNullOrEmpty(dl[trackingcoder].Trackingcode))
            {
                Console.WriteLine("shipment not found");
            }
            else
            {
                dl[trackingcoder].printshipman();
                
            }

        }
    }
}
