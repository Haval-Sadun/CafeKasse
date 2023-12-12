namespace CafeKasse.MAUI.Models
{
    public class Item
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        private string _image;
        public string Image
        {
            get => _image;
            set
            {
                _image = $"https://raw.githubusercontent.com/Haval-Sadun/CafeKasse/master/CafeKasse.API/wwwroot/images/items/{value}";
            }
        }

        public double Price { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }

    }
}
