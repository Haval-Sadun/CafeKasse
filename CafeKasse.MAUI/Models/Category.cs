using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeKasse.MAUI.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }

        private string _image;
        public string Image
        {
            get => _image;
            set
            {
                _image = $"https://raw.githubusercontent.com/Haval-Sadun/CafeKasse/master/CafeKasse.API/wwwroot/images/categories/{value}";
            }
        }

    }
}
//public string Image { get; set; }
