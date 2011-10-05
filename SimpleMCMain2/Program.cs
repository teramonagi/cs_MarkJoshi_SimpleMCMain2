using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleMCMain2
{
    class Program
    {
        static void Main(string[] args)
        {
            //parameters
            double expiry = 1.0;
            double strike = 50.0;
            double spot = 49.0;
            double vol = 0.2;
            double r = 0.01;
            
            //input number of montecarlo paths
            ulong number_of_paths = 10000;
            Console.Write("Enter number of montecarlo paths : ");
            number_of_paths = ulong.Parse(Console.ReadLine());

            //create payoff object
            PayOff call_payoff = new PayOff(strike, PayOff.OptionType.call);
            PayOff put_payoff  = new PayOff(strike, PayOff.OptionType.put);

            //montecarlo simulation & output result
            double result = SimpleMC.SimpleMonteCarlo2(call_payoff, expiry, spot, vol, r, number_of_paths);
            Console.WriteLine("the call price is " + result.ToString());
            
            result = SimpleMC.SimpleMonteCarlo2(put_payoff, expiry, spot, vol, r, number_of_paths);
            Console.WriteLine("the put price is " + result.ToString());

        }
    }
}
