using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleMCMain2
{
    class SimpleMC
    {
        public static double SimpleMonteCarlo2(PayOff payoff,
                                double expiry,
                                double spot,
                                double vol,
                                double r,
                                ulong number_of_paths)
        {
            double variance = vol * vol * expiry;
            double root_variance = Math.Sqrt(variance);
            double moved_spot = spot * Math.Exp(r * expiry - 0.5 * variance);

            double this_spot;
            double running_sum = 0;
            for (ulong i = 0; i < number_of_paths; i++)
            {
                double this_gaussian = MyRandom.GetOneGaussianByBoxMuller();
                this_spot = moved_spot * Math.Exp(root_variance * this_gaussian);
                running_sum += payoff.Do(this_spot);
            }
            return Math.Exp(-r * expiry) * (running_sum / number_of_paths);
        }

    }
}
