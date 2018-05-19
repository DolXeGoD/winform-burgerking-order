using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookBbang
{
    public class Burger : Product
    {
        //경로 재설정
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
                imgPath = Common.ProductRootPath + "BurgerImg/" + name.Replace(" ", string.Empty) + Common.ProductImgExtension;
                BigImgPath = Common.ProductRootPath + "BurgerBigImg/" + name.Replace(" ", string.Empty) + Common.ProductImgExtension;
            }
        }
    }
}
