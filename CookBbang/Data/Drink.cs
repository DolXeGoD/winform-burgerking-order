using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookBbang
{
    public class Drink : Product
    {
        private string name;
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
                imgPath = Common.ProductRootPath + "DrinkImg/" + name.Replace(" ", string.Empty) + Common.ProductImgExtension;
                BigImgPath = Common.ProductRootPath + "DrinkBigImg/" + name.Replace(" ", string.Empty) + Common.ProductImgExtension;
            }
        }
    }
}
