namespace RedArbor.Employees.DAL.Data
{
    public static class DBInitializer
    {
        public static void Initialize(EFContext context)
        {
            context.Database.EnsureCreated();
        }
    }
}
