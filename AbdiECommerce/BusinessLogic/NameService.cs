namespace BusinessLogic
{
    namespace BusinessLogic
    {
        public class NameService
        {
            NorthWindContext context;
            public NameService()
            {
                context = new NorthWindContext();
            }
            public string GetName(int id)
            {

                var p = context.Products.FirstOrDefault(p => p.ProductId == id);
                if (p == null) return "";
                return p.ProductName;

            }

        }
    }
}
