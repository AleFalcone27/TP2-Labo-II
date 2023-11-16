namespace Entidades
{

    public class GestorSql
    {
        private static string connectionString;

        static GestorSql()
        {
            GestorSql.connectionString = "Server=ALE; Database=SistemaInterno;Trusted_Connection=True;";
        }


        public static string ConnectionString
        {
            get { return GestorSql.connectionString; }

        }

    }
}