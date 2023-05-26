namespace WebApExample.Data
{
    public class DBInit
    {
        public static void Init(Context context)
        {
            context.Database.EnsureCreated();
        }
    }
}
