namespace LibrarySystem
{
    public class FineCalculator : IFineCalculator
    {
        public double CalculateFine(int daysLate)
        {
            return daysLate * 2; // 2 per day
        }
    }
}