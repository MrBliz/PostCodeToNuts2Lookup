namespace PostCodeToNuts2Lookup.Console
{
    public class Data
    {
        public string PostCode { get; set; }
        public string Lau2 { get; set; }
        public string Code { get; set; }

        public override string ToString()
        {
            return $"PostCode: {PostCode}, Lau2: {Lau2}, Nuts2: {Code}";
        } 
    }
}