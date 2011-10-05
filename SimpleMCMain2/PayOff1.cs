using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace SimpleMCMain2
{
    public class PayOff
    {
        public enum OptionType { call, put };
        public PayOff(double strike, OptionType type)
        {
            this.strike_ = strike;
            this.type_ = type;        
        }
        public double Do(double spot)
        {
            double result = 0;
            switch(type_)
            {
                case OptionType.call : 
                    result = Math.Max(spot - strike_, 0);
                    break;
                case OptionType.put : 
                    result = Math.Max(strike_ - spot, 0);
                    break;
                default:
                    throw new Exception("Unknown Option Type");
            }

            return result;
        }
        
        private double strike_;
        private OptionType type_;
    }
}