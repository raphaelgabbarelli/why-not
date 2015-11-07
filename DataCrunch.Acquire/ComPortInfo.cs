namespace DataCrunch.Acquire
{
    public class ComPortInfo
    {
        public string PortDescription { get; set; }

        public override string ToString()
        {
            return PortDescription;
        }
    }
}
