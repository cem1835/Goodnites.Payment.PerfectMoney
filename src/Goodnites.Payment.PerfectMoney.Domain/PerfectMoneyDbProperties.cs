namespace Goodnites.Payment.PerfectMoney
{
    public static class PerfectMoneyDbProperties
    {
        public static string DbTablePrefix { get; set; } = "PerfectMoney";

        public static string DbSchema { get; set; } = null;

        public const string ConnectionStringName = "PerfectMoney";
    }
}
