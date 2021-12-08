namespace SchsPolicySearch.Common
{
    public static class StringValidator
    {
        public static bool IsValidNumbericalIdentifier(this string s) => s.Length != 10 || s.All(c => c >= '0' && c <= '9');
    }
}