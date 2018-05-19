using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookBbang
{
    //프로그램이 시작되자마자 Side 모델로 SideData들을 모두 세팅해 List에 넣어둠.
    //ImgPath는 Name만 넘겨주면 Model에서 set해줌
    class SideData
    {
        public List<Side> sides = new List<Side>
        {
            new Side{EngName="COCONUT SHRIMP", Name="코코넛쉬림프", Subscribe="바삭한 코코넛 옷을 입은 탱글한 통새우", price=2800,
                nutrition =new Nutrition{Kcal="81", gram="57", protein="6",sodium="177",saccharid="1.7",fat="0.9"}, Category="Side"},

            new Side{EngName="TENDER KING", Name="텐더킹", Subscribe="부드러운 닭 안심살에 잠발라야 시즈닝의 매콤함이 더해지다!", price=2000,
                nutrition =new Nutrition{Kcal="211", gram="80", protein="15",sodium="542",saccharid="0.8",fat="2"}, Category="Side"},

            new Side{EngName="CHICKEN FRIES", Name="치킨프라이", Subscribe="어니언과 갈릭의 향긋한 풍미, 달콤 바삭한 치킨프라이", price=2000,
                nutrition =new Nutrition{Kcal="232", gram="84", protein="16",sodium="357",saccharid="0.1",fat="4"}, Category="Side"},

            new Side{EngName="CHEEZE FRIES", Name="치즈프라이", Subscribe="바삭한 프렌치프라이에 고소한 치즈가 듬뿍!", price=2500,
                nutrition =new Nutrition{Kcal="440", gram="139", protein="12",sodium="447",saccharid="1.8",fat="8"}, Category="Side"},

            new Side{EngName="FRENCH FRIES", Name="프렌치프라이", Subscribe="세계 최고의 감자만 엄선해서 버거킹만의 비법으로 바삭하게!", price=1600,
                nutrition =new Nutrition{Kcal="285", gram="102", protein="4",sodium="326",saccharid="0.3",fat="3"}, Category="Side"},

            new Side{EngName="ONION RING", Name="어니언링", Subscribe="오직 버거킹에서만 즐길 수 있다! 어니언의 맛있는 변신! ", price=2000,
                nutrition =new Nutrition{Kcal="332", gram="91", protein="5",sodium="476",saccharid="2.5",fat="3"}, Category="Side"},

            new Side{EngName="NUGGET KING", Name="너겟킹", Subscribe="바삭~ 촉촉~ 한입에 쏙 부드러운 너겟킹!", price=2000,
                nutrition =new Nutrition{Kcal="139", gram="78", protein="6",sodium="289",saccharid="0.4",fat="2"}, Category="Side"},

            new Side{EngName="CUP ICECREAM", Name="컵아이스크림", Subscribe="부드러운 아이스크림이 한 컵 가득", price=600,
                nutrition =new Nutrition{Kcal="154", gram="110", protein="2",sodium="50",saccharid="16.9",fat="7"}, Category="Side"},

            new Side{EngName="VANILLA SUNDAE", Name="바닐라선데", Subscribe="향긋한 바닐라 향 때문에 더 맛있다!", price=1500,
                nutrition =new Nutrition{Kcal="210", gram="150", protein="3",sodium="68",saccharid="23",fat="9"}, Category="Side"},

            new Side{EngName="STRAWBERRY SUNDAE", Name="딸기선데", Subscribe="딸기맛의 상큼함이 살아있어요!", price=1500,
                nutrition =new Nutrition{Kcal="261", gram="163", protein="3",sodium="70",saccharid="35.3",fat="11"}, Category="Side"},

            new Side{EngName="CHOCOLATE SUNDAE", Name="초코선데", Subscribe="달콤하고 진한 초코의 맛!", price=1500,
                nutrition =new Nutrition{Kcal="264", gram="175", protein="2",sodium="81",saccharid="37.8",fat="7"}, Category="Side"},

            new Side{EngName="CORN SALADE", Name="콘샐러드", Subscribe="달콤한 옥수수와 싱싱한 야채의 어울림", price=1600,
                nutrition =new Nutrition{Kcal="189", gram="105", protein="2",sodium="226",saccharid="6.3",fat="1"}, Category="Side"},
        };
    }
}
