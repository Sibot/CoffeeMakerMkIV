namespace CofeeMakerMkIV.Services
{
    public class FilterService
    {
        public bool HasFilter { get; set; }

        public FilterService(bool addFilter = false)
        {
            if (addFilter)
            {
                this.HasFilter = true;
            }
        }
    }
}
