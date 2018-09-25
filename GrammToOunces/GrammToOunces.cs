namespace GrammToOunces
{
    public static class GrammToOuncesClass
    {
        private const double ChangeValueFromOuncesToGramm = 28.34952;
        private const double ChangeValueFromGrammToOunces = 0.03527396195;

        public static double GrammToOunces(double gramm)
        {
            return gramm * ChangeValueFromGrammToOunces;
        }

        public static double OuncesToGramm(double ounces)
        {
            return ounces * ChangeValueFromOuncesToGramm;
        }
    }
}
