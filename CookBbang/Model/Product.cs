using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookBbang
{
   public class Product
   {
        public string EngName { get; set; }

        private string name;
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value; //Data에서 Name이 넘어오면 제품이름 공백 제거등 2차 처리를 하기 위해 private string name에 1차 저장  
                imgPath = Common.ProductRootPath + name.Replace(" ", string.Empty) + Common.ProductImgExtension;
                BigImgPath = Common.ProductRootPath + name.Replace(" ", string.Empty) + Common.ProductImgExtension;
            }
        }
        public string Subscribe { get; set; }
        public int price { get; set; }
        public Nutrition nutrition { get; set; }
        public string imgPath { get; set; }
        public string BigImgPath { get; set; }
        public string Category { get; set; }
   }
}
