namespace FirstLabWindowsFormsApp.Services
{
    public static class MathFunctions
    {

        public static long Fact(long n)
        {
            if (n == 0)
                return 1;

            return n * Fact(n - 1);
        }

    }
}