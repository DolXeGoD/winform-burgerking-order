using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookBbang
{
    public class BurgerData
    {
            public List<Burger> burgers = new List<Burger>
            {
                //와퍼    -- -- -- -- -- --
                new Burger{EngName="TONG SHRIMP WHOPPER JR",Name="통새우와퍼주니어",Subscribe="직화 방식으로 구운 100% 순쇠고기 패티에 갈릭페퍼 통새우와 스파이시 토마토소스가 더해진 프리미엄 버거"
                ,price =4600, nutrition = new Nutrition{Kcal="381",gram="162",protein="12",sodium="522",saccharid="5",fat="7",caffeine="0"},Category="Whopper"},
                new Burger{EngName="TONG SHRIMP STEAK BURGER",Name="통새우스테이크버거",Subscribe="직화 방식으로 구운 프리미엄 스테이크 패티에 갈릭페퍼 통새우와 고소한 치즈, 스파이시토마토소스가 더해진 프리미엄 버거",price = 7600,nutrition = new Nutrition{Kcal="839",gram="348",protein="37",sodium="1437",saccharid="5",fat="19",caffeine="0"},Category="Whopper"},
                new Burger{EngName="TONG SHRIMP WHOPPER",Name="통새우와퍼",Subscribe="직화 방식으로 구운 100% 순쇠고기 패티에 갈릭페퍼 통새우와 스파이시토마토소스가 더해진 프리미엄 버거",price =6500,nutrition = new Nutrition{Kcal="741",gram="328",protein="34",sodium="984",saccharid="5",fat="15",caffeine="0"},Category="Whopper"},
                new Burger{EngName="WHOPPER",Name="와퍼",Subscribe="불에 직접 구운 순 쇠고기 패티에 싱싱한 야채가 한가득~ 버거킹의 대표 메뉴!",price =5600,nutrition = new Nutrition{Kcal="619",gram="278",protein="29",sodium="809",saccharid="10.5",fat="13",caffeine="0"},Category="Whopper"},
                new Burger{EngName="BULGOGI WHOPPER",Name="불고기와퍼",Subscribe="불에 직접 구운 순 쇠고기 패티가 들어간 와퍼에 달콤한 불고기 소스까지!",price =5600,nutrition = new Nutrition{Kcal="682",gram="278",protein="28",sodium="912",saccharid="5.7",fat="14",caffeine="0"},Category="Whopper"},
                new Burger{EngName="QUATTRO CHEEZE WHOPPER",Name="콰트로치즈와퍼",Subscribe="진짜 불맛을 즐겨라, 4가지 고품격 치즈와 불에 직접 구운 와퍼 패티의 만남!",price =6500,nutrition = new Nutrition{Kcal="769",gram="309",protein="40",sodium="1051",saccharid="6.2",fat="20",caffeine="0"},Category="Whopper"},
                new Burger{EngName="CHEEZE WHOPPER",Name="치즈와퍼",Subscribe="불에 직접 구운 순 쇠고기 패티가 들어간 와퍼에 고소한 치즈까지!",price =6200,nutrition = new Nutrition{Kcal="716",gram="303",protein="33",sodium="1288",saccharid="7.1",fat="16",caffeine="0"},Category="Whopper"},
                new Burger{EngName="WHOPPER JR",Name="와퍼주니어",Subscribe="불에 직접 구운 순 쇠고기 패티가 들어간 와퍼의 주니어 버전~ 작지만 꽉 찼다!",price =4000,nutrition = new Nutrition{Kcal="399",gram="158",protein="17",sodium="570",saccharid="4.6",fat="8",caffeine="0"},Category="Whopper"},
                new Burger{EngName="BULGOGI WHOPPER JR",Name="불고기와퍼주니어",Subscribe="불에 직접 구운 순 쇠고기 패티가 들어간 와퍼주니어에 달콤한 불고기 소스까지!",price =4000,nutrition = new Nutrition{Kcal="380",gram="158",protein="18",sodium="523",saccharid="3.6",fat="8",caffeine="0"},Category="Whopper"},
                new Burger{EngName="QUATTRO CHEEZE WHOPPER JR",Name="콰트로치즈와퍼주니어",Subscribe="진짜 불맛을 즐겨라, 4가지 고품격 치즈와 불에 직접 구운 와퍼 패티의 만남!",price =4600,nutrition = new Nutrition{Kcal="446",gram="173",protein="21",sodium="631",saccharid="3.1",fat="10",caffeine="0"},Category="Whopper"},
                new Burger{EngName="CHEEZE WHOPPER JR",Name="치즈와퍼주니어",Subscribe="불에 직접 구운 순 쇠고기 패티가 들어간 와퍼주니어에 고소한 치즈 추가!",price =4300,nutrition = new Nutrition{Kcal="438",gram="170",protein="19",sodium="771",saccharid="4.8",fat="10",caffeine="0"},Category="Whopper"},
                //와퍼 끝 -- -- -- -- -- --
               
                //갈릭스테이크    -- -- -- -- -- --
                new Burger{EngName="GARLIC STEAK BURGER",Name="갈릭스테이크버거",Subscribe="두툼한 스테이크 패티, 향긋한 갈릭, 달콤한 볶음 양파의 맛있는 조화!",price =6700,nutrition = new Nutrition{Kcal="637",gram="295",protein="36",sodium="1142",saccharid="8.9",fat="15",caffeine="0"},Category="GarlicSTK"},
                //갈릭스테이크 끝 -- -- -- -- -- --
                
                //비프앤치킨    -- -- -- -- -- --
                new Burger{EngName="BLT NEW ORLEANS CHICKEN BURGER",Name="BLT뉴올리언스치킨버거",Subscribe="두툼한 치킨 통가슴살에 베이컨과 치즈,양상추,토마토,잠발라야 시즈닝을 더한 새로운 매콤한 치킨버거",price =5700,nutrition = new Nutrition{Kcal="860",gram="319",protein="34",sodium="1480",saccharid="9.1",fat="13",caffeine="0"},Category="BeefChicken"},
                new Burger{EngName="NEW ORLEANS CHICKEN BURGER",Name="뉴올리언스치킨버거",Subscribe="두툼한 치킨 통가슴살에 잠발라야 시즈닝을 더한 새로운 매콤한 치킨버거",price =4500,nutrition = new Nutrition{Kcal="798",gram="282",protein="30",sodium="1407",saccharid="2.8",fat="10",caffeine="0"},Category="BeefChicken"},
                new Burger{EngName="2000 CHICKEN BURGER",Name="2000 치킨버거",Subscribe="신선한 양상추와 바삭한 치킨패티의 만남!",price =2000,nutrition = new Nutrition{Kcal="461",gram="160",protein="12",sodium="810",saccharid="2",fat="7",caffeine="0"},Category="BeefChicken"  },
                new Burger{EngName="2000 CHEEZE BURGER",Name="2000 치즈버거",Subscribe="달콤 상큼한 스위트사우전 소스, 신선한토마토와 고소한 치즈의 조화!",price =2000,nutrition = new Nutrition{Kcal="432",gram="172",protein="17",sodium="640",saccharid="8.4",fat="8",caffeine="0"},Category="BeefChicken" },

                new Burger{EngName="BLT LONG CHICKEN BURGER",Name="BLT롱치킨버거",Subscribe="바삭한 베이컨과 신선한 야채 그리고 담백한 롱~ 치킨패티의 완벽한 조화!",price =4900,nutrition = new Nutrition{Kcal="642",gram="269",protein="28",sodium="1217",saccharid="3",fat="6",caffeine="0"},Category="BeefChicken" },
                new Burger{EngName="LONG KING",Name="롱 킹",Subscribe="100% 순쇠고기 패티가 두 장! 달콤 상큼한 스위트 사우전드 소스의 완벽한 조화",price =5900,nutrition = new Nutrition{Kcal="545",gram="230",protein="24",sodium="983",saccharid="9.2",fat="9",caffeine="0"},Category="BeefChicken" },
                
                //사라짐
                //new Burger{EngName="X-TRA CRUNCH CHICKEN",Name="XTRA 크런치 치킨버거",Subscribe="매콤한 치킨, 바삭한 옥수수, 그리고 신선한 토마토와 아삭한 피클까지! ",price ="4,700",nutrition = new Nutrition{Kcal="740",gram="279",protein="22(39)",sodium="1050(52)",saccharid="5.4",fat="5(35)",caffeine="0"},Category="BeefChicken" },
                //new Burger{EngName="CR0UNCH CHICKEND",Name="크런치치킨",Subscribe="매콤한 치킨과 바삭한 옥수수의 조화, 크런치치킨 ",price ="4,300",nutrition = new Nutrition{Kcal="731",gram="225",protein="22(39)",sodium="1049(52)",saccharid="3.4",fat="5(35)",caffeine="0"},Category="BeefChicken" },

                new Burger{EngName="ORIGINAL LONG CHICKEN BURGER",Name="오리지날 롱 치킨 버거",Subscribe="담백한 치킨 패티에 부드러운 마요네즈 소스와 싱싱한 야채가 듬뿍~ ",price =4400,nutrition = new Nutrition{Kcal="517",gram="210",protein="25",sodium="1100",saccharid="5.7",fat="5.5",caffeine="0"},Category="BeefChicken" },
                new Burger{EngName="CHEEZE BURGER",Name="치즈버거",Subscribe="불에 구운 쇠고기 패티와 사르르 치즈까지, 작지만 알차다! ",price =3000,nutrition = new Nutrition{Kcal="366",gram="133",protein="19",sodium="752",saccharid="5.9",fat="9",caffeine="0"},Category="BeefChicken" },
                new Burger{EngName="BULGOGI BURGER",Name="불고기버거",Subscribe="달콤한 불고기소스를 더한 실속 만점의 버거. 크기는 깜찍, 맛은 어메이징! ",price =3000,nutrition = new Nutrition{Kcal="371",gram="140",protein="17",sodium="432",saccharid="9.9",fat="8",caffeine="0"},Category="BeefChicken" },
                new Burger{EngName="HAMBURGER",Name="햄버거",Subscribe="불에 구운 소고기 패티가 쏙~ 실속 있게 즐긴다! ",price =2700,nutrition = new Nutrition{Kcal="306",gram="121",protein="17",sodium="513",saccharid="6.3",fat="6",caffeine="0"},Category="BeefChicken" }
                //비프앤치킨 끝 -- -- -- -- -- --
            };
    }
}
