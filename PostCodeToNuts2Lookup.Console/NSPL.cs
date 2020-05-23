using System.Globalization;

namespace PostCodeToNuts2Lookup.Console
{
    public class NSPL
    {
        public string pcds { get; set; }
        public string nuts { get; set; }

        public override string ToString()
        {
            return $"Postcode: {pcds}, Lau2: {nuts}";
        }
    }
}