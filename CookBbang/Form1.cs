using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;   
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace CookBbang
{
    public partial class Form1 : Form
    {
        //세트 제작 시 세 개가 다 선택되었는지 검사하는 변수.
        bool Burger_isSelected = false;
        bool Drink_isSelected = false;
        bool Side_isSelected = false;

        BurgerData burgerData = new BurgerData();
        DrinkData drinkData = new DrinkData();
        SideData sideData = new SideData();
        ProgressBar pgbar = new ProgressBar();

        Burger burgerForSet;
        Drink drinkForSet;
        Side sideForSet;

        //로컬 DB 연결 세팅
        static string strConn = "Server=localhost;Database=burger;Uid=root;Pwd=1234;";
        MySqlConnection conn = new MySqlConnection(strConn);

        int Index = 0; // 쓸 곳이 많아서 전역 변수, 쓰는 곳 : ListView에 아이템 추가할 때 & ProgressBar에서. 
        int PriceForDB;
        string NameForDB;

        public Form1()
        {
            InitializeComponent();
        }

        //onCreate
        private void Form1_Load(object sender, EventArgs e)
        {
            InitProduct();
            PanelClear();

            //버거 단품 메뉴 패널로 초기화면 세팅  
            menu_panel.Visible = true;
            menu_panel.BringToFront();
        }

        //제품을 눌렀을 때 발생하는 이벤트 함수.
        private void ListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListView listView = sender as ListView;

            if (listView.SelectedItems.Count > 0)
            {
                //선택된 제품의 Index를 key에 저장, 추후 해당 index의 버거 데이터를 불러오기 위함
                int key = listView.SelectedItems[0].ImageIndex;
                Console.WriteLine(key); //debug

                //단품 리스트 뷰
                if (listView.Name.Equals("WhopperListView")||listView.Name.Equals("GarlicBurgerListView") || listView.Name.Equals("BeefChickenListView") )
                {
                    Burger burger = burgerData.burgers[key];
                    //제품 세부사항 패널로 전환하는 함수
                    ShowBurgerData(burger);
                }

                else if (listView.Name.Equals("drink_ListView"))
                { 
                    Drink drink = drinkData.drinks[key];
                    //제품 세부사항 패널로 전환하는 함수
                    ShowDrinkData(drink);
                }

                else if (listView.Name.Equals("SideListView"))
                {
                    Side side = sideData.sides[key];
                    //제품 세부사항 패널로 전환하는 함수
                    ShowSideData(side);
                }

                //커스텀 세트 제작 리스트 뷰
                if (listView.Name.Equals("S_BurgerListView"))
                {
                    burgerForSet = burgerData.burgers[key];
                    Burger_isSelected = true;
                    B_NowSelected.Text = burgerForSet.Name;
                }
                if (listView.Name.Equals("S_DrinkListView"))
                {
                    drinkForSet = drinkData.drinks[key];
                    Drink_isSelected = true;
                    D_NowSelected.Text = drinkForSet.Name;
                }
                if (listView.Name.Equals("S_SideListView"))
                {
                    sideForSet = sideData.sides[key];
                    Side_isSelected = true;
                    S_NowSelected.Text = sideForSet.Name;
                }
            }
        }


        //세트 만들기 클릭 시 발생하는 함수
        private void btn_MakeSet_Click(object sender, EventArgs e) 
        {
           
            //세트 만들기에서 모두 선택이 되었는지 검사.
            if(Burger_isSelected == true && Drink_isSelected == true && Side_isSelected == true)
            {
                /*
                ===============
                Convert 함수를 따로 만들어 분리 요망.
                ===============
                 */
                double setForKcal = Convert.ToDouble(burgerForSet.nutrition.Kcal) + Convert.ToDouble(drinkForSet.nutrition.Kcal) + Convert.ToDouble(sideForSet.nutrition.Kcal);
                double setForGram = Convert.ToDouble(burgerForSet.nutrition.gram) + Convert.ToDouble(drinkForSet.nutrition.gram) + Convert.ToDouble(sideForSet.nutrition.gram);
                double setForProtein = Convert.ToDouble(burgerForSet.nutrition.protein) + Convert.ToDouble(drinkForSet.nutrition.protein) + Convert.ToDouble(sideForSet.nutrition.protein);
                double setForSodium = Convert.ToDouble(burgerForSet.nutrition.sodium) + Convert.ToDouble(drinkForSet.nutrition.sodium) + Convert.ToDouble(sideForSet.nutrition.sodium);
                double setForSaccharid = Convert.ToDouble(burgerForSet.nutrition.saccharid) + Convert.ToDouble(drinkForSet.nutrition.saccharid) + Convert.ToDouble(sideForSet.nutrition.saccharid);
                double setForFat = Convert.ToDouble(burgerForSet.nutrition.fat) + Convert.ToDouble(drinkForSet.nutrition.fat) + Convert.ToDouble(sideForSet.nutrition.fat);
                double setForCaffeine = Convert.ToDouble(drinkForSet.nutrition.caffeine);

                string setName = burgerForSet.Name + " 세트";
                int SetPrice = burgerForSet.price + drinkForSet.price + sideForSet.price;

                //선택된 세트의 세부사항 패널로 전환
                PanelClear();
                SetDetail_panel.Visible = true;
                SetDetail_panel.BringToFront();

                Set_EngName.Text = burgerForSet.EngName + " Set";
                Set_KrName.Text = setName;
                NameForDB = burgerForSet.EngName + " Set";
                Set_Sub.Text = burgerForSet.Subscribe;
                Set_Price.Text = Convert.ToString(SetPrice);
                PriceForDB = SetPrice;

                Set_BurgerPic.Image = Image.FromFile(burgerForSet.imgPath);
                Set_DrinkPic.Image = Image.FromFile(drinkForSet.imgPath);
                Set_SidePic.Image = Image.FromFile(sideForSet.imgPath);

                SNutrition_Kcal.Text = Convert.ToString(setForKcal);
                SNutrition_Gram.Text = Convert.ToString(setForGram);
                SNutrition_Protein.Text = Convert.ToString(setForProtein);
                SNutrition_Sodium.Text = Convert.ToString(setForSodium);
                SNutrition_Saccharid.Text = Convert.ToString(setForSaccharid);
                SNutrition_Fat.Text = Convert.ToString(setForFat);
                SNutrition_Caffeine.Text = Convert.ToString(setForCaffeine);
                
            }
            else //세 개중 하나라도 선택이 되지 않았을 시 예외처리
            {
                MessageBox.Show("메뉴 선택을 모두 완료한 후 다시 버튼을 눌러 주세요");
            }
        }


        //주문 확정 시
        private void Order_Click(object sender, EventArgs e)
        {
            nowMaking_panel.Visible = true;
            nowMaking_panel.BringToFront();

            new Thread(new ThreadStart(Thread_Progress)).Start();          
        }

        //대리자 선언
        delegate void DoProgressDelegt();
        delegate void ProgressImgDelegt(int i);

        //UI단을 건드리기 위한 쓰레드
        public void Thread_Progress()
        {
            const string ImgExtension = ".PNG";

            while (Index <= 110)    
            {
                //프로그레스바 Value에 따라 제작과정 이미지 다르게 삽입 
                if(Index % 20 == 0)
                {
                    this.Invoke(new ProgressImgDelegt(PutImgInProgress), Index);
                }
                    
                //프로그레스바 진행
                this.Invoke(new DoProgressDelegt(() => pgbar1.PerformStep()));
                Index++;
                Thread.Sleep(50);
            }
            //세트가 완성되었을 때
            if(Index > 109)
            {
                Index = 0;
                nowMaking_panel.Visible = false;
                Invoke(new DoProgressDelegt(() => pgbar1.Value = 0));
                SaveInDB();
            }
        }
        // Thread_Progress 쓰레드에서 PerformStep을 직접 실행하면 다른 작업이 멈추기 때문에 UI가 죽는다, 그렇기 때문에 대리자를 이용하여 PerformStep도 UI단 쓰레드에서 처리하도록 한다.


        //버거가 완성되었을 때 완성된 버거의 데이터를 주문완료 db에 추가하는 함수.
        public void SaveInDB()
        { 
            try
            {
                conn.Open();
                String sql = "INSERT INTO savedburger (price, orderedName) " +
                                "VALUES ('" + PriceForDB + "', '" + NameForDB + "')";

                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
                conn.Close();

                MessageBox.Show("DB SAVE SUCCESS");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }
            
        }

        // 세트 만드는 과정 이미지를 띄워줌, 마찬가지로 UI 단을 건드리기때문에 Thread_Progress에서 대리자로 실행해준다.
        public void PutImgInProgress(int Index)
        {
            const string ImgExtension = ".PNG";
            string ImgRoot = Common.ProductRootPath + "Burger_MakingImg/" + Index + ImgExtension;
            Making_Picture.Image = Image.FromFile(ImgRoot);          
        }

        private void Set_Remake_Click(object sender, EventArgs e)
        {
            MakeSet_panel.BringToFront();
        }


        //------- 세부사항 패널 통일 필요 2018.05.18
        //단품(사이드)클릭 시 실행되는 단품 세부사항 패널
        private void ShowSideData(Side side)
        {
            PanelClear();
            detail_panel.Visible = true;
            detail_panel.BringToFront();

            BurgerSide_EngName.Text = side.EngName;
            BurgerSide_KrName.Text = side.Name;
            BurgerSide_Price.Text = Convert.ToString(side.price);
            BurgerSide_Sub.Text = side.Subscribe;

            BNutrition_Kcal.Text = side.nutrition.Kcal;
            BNutrition_Gram.Text = side.nutrition.gram;
            BNutrition_Protein.Text = side.nutrition.protein;
            BNutrition_Sodium.Text = side.nutrition.sodium;
            BNutrition_Saccharid.Text = side.nutrition.saccharid;
            BNutrition_Fat.Text = side.nutrition.fat;

            BurgerSidePic.Image = Image.FromFile(side.BigImgPath);

            PriceForDB = side.price;
            NameForDB = side.EngName;
        }

        //단품(음료)클릭 시 실행되는 단품 세부사항 패널
        private void ShowDrinkData(Drink drink)
        {
            PanelClear();
            DrinkDetail_panel.Visible = true;

            DrinkDetail_panel.BringToFront();

            Drink_EngName.Text = drink.EngName;
            Drink_KrName.Text = drink.Name;
            Drink_Sub.Text = drink.Subscribe;
            Drink_Price.Text = Convert.ToString(drink.price);

            DNutrition_Kcal.Text = drink.nutrition.Kcal;
            DNutrition_Gram.Text = drink.nutrition.gram;
            DNutrition_Protein.Text = drink.nutrition.protein;
            DNutrition_Sodium.Text = drink.nutrition.sodium;
            DNutrition_Saccharid.Text = drink.nutrition.saccharid;
            DNutrition_Fat.Text = drink.nutrition.fat;
            DNutrition_Caffeine.Text = drink.nutrition.caffeine;

            DrinkPic.Image = Image.FromFile(drink.BigImgPath);

            PriceForDB = drink.price;
            NameForDB = drink.EngName;
        }

        //단품(버거)클릭 시 실행되는 단품 세부사항 패널
        private void ShowBurgerData(Burger burger)
        {

            //menu_panel.Visible = false;
            //detail_panel.Visible = true;
            PanelClear();
            detail_panel.Visible = true;

            detail_panel.BringToFront();

            BurgerSide_EngName.Text = burger.EngName;
            BurgerSide_KrName.Text = burger.Name;
            BurgerSide_Sub.Text = burger.Subscribe;
            BurgerSide_Price.Text = Convert.ToString(burger.price);
            //label_fat.Text = burger.nutrition.fat;

            BNutrition_Kcal.Text = burger.nutrition.Kcal;
            BNutrition_Gram.Text = burger.nutrition.gram;
            BNutrition_Protein.Text = burger.nutrition.protein;
            BNutrition_Sodium.Text = burger.nutrition.sodium;
            BNutrition_Saccharid.Text = burger.nutrition.saccharid;
            BNutrition_Fat.Text = burger.nutrition.fat;

            BurgerSidePic.Image = Image.FromFile(burger.BigImgPath);

            PriceForDB = burger.price;
            NameForDB = burger.EngName;
        }

        //제품 목록들을 디자인단(Listview)에 넣는 함수
        private void InitProduct()
        {
            //Burger Image List를 WhopperListview로 할당, LargeImageList의 크기로 설정
            WhopperListView.LargeImageList = BurgerImgList;
            //Burger Image List를 GarlicListview로 할당, LargeImageList의 크기로 설정
            GarlicBurgerListView.LargeImageList = BurgerImgList;
            //Burger Image List를 BeefChikenListview로 할당, LargeImageList의 크기로 설정
            BeefChickenListView.LargeImageList = BurgerImgList;
            S_BurgerListView.LargeImageList = BurgerImgList;
            
            //Drink Image List를 drink_ListView로 할당, LargeImageList의 크기로 설정
            drink_ListView.LargeImageList = DrinkImgList;
            S_DrinkListView.LargeImageList = DrinkImgList;

            //Side Image List를 SideListView로 할당, LargeImageList의 크기로 설정
            SideListView.LargeImageList = SideImgList;
            S_SideListView.LargeImageList = SideImgList;


            //버거를 ImageList에 추가
            //BurgerData 클래스의 burgers List를 처음부터 돔
            foreach (Burger burger in burgerData.burgers)
            {
                //해당 데이터의 카테고리가 와퍼일 때
                if (burger.Category == "Whopper")
                {
                    BurgerImgList.Images.Add(Image.FromFile(burger.imgPath));

                    ListViewItem lvItem = new ListViewItem();
                    ListViewItem lvItem_1 = new ListViewItem();
                    lvItem.ImageIndex = Index;
                    lvItem_1.ImageIndex = Index;

                    //단품 패널에 추가
                    WhopperListView.Items.Add(lvItem);
                    //세트 제작 패널에 추가
                    S_BurgerListView.Items.Add(lvItem_1);
                }
                //해당 데이터의 카테고리가 갈릭스테이크일 때
                else if (burger.Category == "GarlicSTK")
                {
                    BurgerImgList.Images.Add(Image.FromFile(burger.imgPath));

                    ListViewItem lvItem2 = new ListViewItem();
                    ListViewItem lvItem2_1 = new ListViewItem();
                    lvItem2.ImageIndex = Index;
                    lvItem2_1.ImageIndex = Index;

                    //단품 패널에 추가
                    GarlicBurgerListView.Items.Add(lvItem2);
                    //세트 제작 패널에 추가
                    S_BurgerListView.Items.Add(lvItem2_1);
                }
                //해당 데이터의 카테고리가 비프치킨일 때
                else if (burger.Category == "BeefChicken")
                {
                    BurgerImgList.Images.Add(Image.FromFile(burger.imgPath));

                    ListViewItem lvItem3 = new ListViewItem();
                    ListViewItem lvItem3_1 = new ListViewItem();
                    lvItem3.ImageIndex = Index;
                    lvItem3_1.ImageIndex = Index;

                    //단품 패널에 추가
                    BeefChickenListView.Items.Add(lvItem3);
                    //세트 제작 패널에 추가
                    S_BurgerListView.Items.Add(lvItem3_1);
                }
                Index++;
            }

            Index = 0;

            //드링크 추가
            foreach(Drink drink in drinkData.drinks)
            {
                
                DrinkImgList.Images.Add(Image.FromFile(drink.imgPath));

                ListViewItem drinkItem = new ListViewItem();
                ListViewItem drinkItem_1 = new ListViewItem();
                drinkItem.ImageIndex = Index;
                drinkItem_1.ImageIndex = Index;

                //단품 패널에 추가
                drink_ListView.Items.Add(drinkItem);
                //세트 제작 패널에 추가
                S_DrinkListView.Items.Add(drinkItem_1);

                Index++;
            }

            Index = 0;

            //사이드 추가
            foreach (Side side in sideData.sides)
            {
                SideImgList.Images.Add(Image.FromFile(side.imgPath));

                ListViewItem sideItem = new ListViewItem();
                ListViewItem sideItem_1 = new ListViewItem();
                sideItem.ImageIndex = Index;
                sideItem_1.ImageIndex = Index; 

                //단품 패널에 추가
                SideListView.Items.Add(sideItem);
                //세트 제작 패널에 추가
                S_SideListView.Items.Add(sideItem_1);

                Index++;
            }
        }

        //디자인 단.=========================================================================================

        public void PanelClear()
        {
            menu_panel.Visible = false;
            detail_panel.Visible = false;
            DrinkMenu_panel.Visible = false;
            DrinkDetail_panel.Visible = false;
            sidemenu_panel.Visible = false;
            SetDetail_panel.Visible = false;
            nowMaking_panel.Visible = false;
        }

        // 패널 자동 종속 문제 때문에 BringToFront 함수로 해결.

        public void BtnClear()
        {
            Burger_title.Load(@"images/LeftMenuImg/image1.png");
            Drink_title.Load(@"images/LeftMenuImg/drink_deactive.png");
            Side_title.Load(@"images/LeftMenuImg/side_nonactive.png");
            Set_title.Load(@"images/LeftMenuImg/set_nonactive.png");
        }

        private void whopper_btn_MouseHover(object sender, EventArgs e)
        {
            whopper_btn.BackColor = Color.FromArgb(255, 198, 5);
            whopper_btn.ForeColor = Color.FromArgb(179, 32, 17);
        }

        private void whopper_btn_MouseLeave(object sender, EventArgs e)
        {
            whopper_btn.BackColor = Color.FromArgb(179,32,17);
            whopper_btn.ForeColor = Color.FromArgb(255,198,5);
        }
        
        private void Burger_title_Click(object sender, EventArgs e)
        {
            BtnClear();
            PanelClear();
            menu_panel.BringToFront();
            Burger_title.Load(@"images/LeftMenuImg/image2.png");
            Burger_title.SizeMode = PictureBoxSizeMode.StretchImage;
            menu_panel.Visible = true;
        }   

        private void Drink_title_Click(object sender, EventArgs e)
        {
            BtnClear();
            PanelClear();
            DrinkMenu_panel.Visible = true;
            DrinkMenu_panel.BringToFront();
            Drink_title.Load(@"images/LeftMenuImg/drink_active.png");
            Drink_title.SizeMode = PictureBoxSizeMode.StretchImage;
            
        }

        private void Side_title_Click(object sender, EventArgs e)
        {
            BtnClear();
            PanelClear();
            sidemenu_panel.Visible = true;
            sidemenu_panel.BringToFront();
            Side_title.Load(@"images/LeftMenuImg/side_active.png");
            Side_title.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void Set_title_Click(object sender, EventArgs e)
        {
            BtnClear();
            PanelClear();
            MakeSet_panel.Visible = true;
            MakeSet_panel.BringToFront();
            Set_title.Load(@"images/LeftMenuImg/set_active.PNG");
            Set_title.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        
    }

}
