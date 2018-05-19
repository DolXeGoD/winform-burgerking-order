using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookBbang
{
    //프로그램이 시작되자마자 Drink 모델로 DrinkData들을 모두 세팅해 List에 넣어둠.
    //ImgPath는 Name만 넘겨주면 Model에서 set해줌
    class DrinkData
    {
        public List<Drink> drinks = new List<Drink>
        {
            new Drink{EngName="AMERICANO (ICE/HOT)", Name="아메리카노", Subscribe="자연을 담은 버거킹 RA 인증커피", price=1500,
                nutrition = new Nutrition{Kcal="6", gram="227", protein="0", sodium="0", saccharid="0", fat="0", caffeine="85.3" }, Category="Drink"},
            new Drink{EngName="CAFE LATTE (ICE/HOT)", Name="카페라떼", Subscribe="자연을 담은 버거킹 RA 인증커피", price=2500,
                nutrition = new Nutrition{Kcal="151", gram="227", protein="2", sodium="85", saccharid="18", fat="4", caffeine="101.2" },Category="Drink" },
            new Drink{EngName="COCA-COLA", Name="코카콜라", Subscribe="코카-콜라로 더 짜릿하게!", price=1700,
                nutrition = new Nutrition{Kcal="150", gram="376", protein="0", sodium="15", saccharid="39.1", fat="0", caffeine="0" }, Category="Drink"},
            new Drink{EngName="COCA-COLA ZERO", Name="코카콜라제로", Subscribe="코카-콜라로 더 짜릿하게!", price=1700,
                nutrition = new Nutrition{Kcal="0", gram="376", protein="0", sodium="30", saccharid="0", fat="0", caffeine="0" }, Category="Drink"},
            new Drink{EngName="FANTA ORANGE", Name="환타 오렌지", Subscribe="톡 쏘는 상큼함!", price=1700,
                nutrition = new Nutrition{Kcal="188", gram="376", protein="0", sodium="15", saccharid="51.1", fat="0", caffeine="0" }, Category="Drink"},
            new Drink{EngName="SPRITE", Name="스프라이트", Subscribe="나를 깨우는 상쾌함!", price=1700,
                nutrition = new Nutrition{Kcal="165", gram="376", protein="0", sodium="23", saccharid="42.1", fat="0", caffeine="0" }, Category="Drink"},
            new Drink{EngName="HOT CHOCOLATE", Name="핫초코", Subscribe="달콤한 초코, 따뜻하게 즐기세요~", price=2000,
                nutrition = new Nutrition{Kcal="210", gram="227", protein="2", sodium="86", saccharid="23.0", fat="4", caffeine="0" }, Category="Drink"},
            new Drink{EngName="MINUTE MADE", Name="미닛메이드", Subscribe="오렌지의 신선함이 가득~", price=2500,
                nutrition = new Nutrition{Kcal="172", gram="350", protein="0", sodium="11", saccharid="36", fat="0", caffeine="0" }, Category="Drink"},
            new Drink{EngName="MINERAL WATER", Name="생수(순수)", Subscribe="깨끗하고 순수한 물", price=1200,
                nutrition = new Nutrition{Kcal="0", gram="0", protein="0", sodium="0", saccharid="0", fat="0", caffeine="0" }, Category="Drink"},
        };
    }
}       