using AbdiHotelConsole.Data;


namespace AbdiHotelConsole
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var app = new Application();
            app.Run();

            var rec = new Reception();
            rec.ReceptionMenu();
        }
    }
}
