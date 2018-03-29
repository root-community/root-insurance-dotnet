namespace RootSDK.Insurance.Models
{
    public class Gadget : IInsurable
    {
        public string Make { get; set; }
        public string Name { get; set; }
        public int Value { get; set; }
    }
}