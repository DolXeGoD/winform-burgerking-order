using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookBbang
{
    class Side : Product
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
                imgPath = Common.ProductRootPath + "SideImg/" + name.Replace(" ", string.Empty) + Common.ProductImgExtension;
                BigImgPath = Common.ProductRootPath + "SideBigImg/" + name.Replace(" ", string.Empty) + Common.ProductImgExtension;
            }
        }
    }
}
