namespace FirstLabWindowsFormsApp.Services
{
    public static class MathFunctions
    {

        public static double Fact(int x)
        {
            if (x <= 0) {
                return 1;
            }

            var result = 1;

            do
            {
                result *= x;
                x--;
            } while (x > 1);

            return result;

        }

    }
}