using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net;
using System.Windows;
using System.Windows.Media;

namespace lolapitestwpf
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private string apikey = "?api_key=RGAPI-B1F0AC0F-8798-418B-B4A4-A2A9A1F1EAC2";
        private string name = "";
        private string region = "";
        private string id = "";
        private string[] reglist = { "BR1","EUN1","EUW1","JP1","KR","LA1","LA2","NA1","OC1","PBE1","RU","TR1" };

        private Dictionary<string, string> Summoner;
        private dynamic currentGameInfo;


        private string dlBasicInfoJson(string region, string jsonadd1, string jsonadd2)
        {
            WebClient client = new WebClient();
            return client.DownloadString("https://" + region + jsonadd1 + region + jsonadd2 + name + apikey);
        }

        private string dlCurrentGameJson(string jsonadd)
        {
            WebClient client = new WebClient();
            return client.DownloadString("https://" + region + jsonadd + reglist[regionPicker.SelectedIndex] + "/" + id + apikey);
        }

        private void getBasicInfo()
        {
            string summonerInfo = dlBasicInfoJson(region, ".api.pvp.net/api/lol/", "/v1.4/summoner/by-name/");
            summonerInfo = summonerInfo.Remove(0, 4 + name.Length);
            summonerInfo = summonerInfo.Remove(summonerInfo.Length - 1);
            Summoner = JsonConvert.DeserializeObject<Dictionary<string, string>>(summonerInfo);
            id = Summoner["id"];
        }

        private void setBasicInfo()
        {
            idLbl.Content = "ID: " + id;
            nameLbl.Content = "Name: " + Summoner["name"];
            levelLbl.Content = "Level: " + Summoner["summonerLevel"];
            summonerIcon.Source = (ImageSource)new ImageSourceConverter().ConvertFromString("http://ddragon.leagueoflegends.com/cdn/6.15.1/img/profileicon/" + Summoner["profileIconId"] + ".png");
        }
        
        private void getCurrentInfo()
        {
            string currentGameInfoJ = dlCurrentGameJson(".api.pvp.net/observer-mode/rest/consumer/getSpectatorGameInfo/");
            currentGameInfo = JsonConvert.DeserializeObject(currentGameInfoJ);
        }

        private void setCurrentInfo()
        {
            getCurrentInfo();
            gameMod.Content = currentGameInfo.gameMode;
            gameTyp.Content = currentGameInfo.gameType;
            var mapId = currentGameInfo.mapId;
            gameMap.Content = mapId;
        }

        private void updateUI()
        {
            setBasicInfo();
        }

        private void setSummoner()
        {
            name = nameBox.Text;
            region = regionPicker.Text.ToLower();
            
        }

        private void doMagic(object sender, RoutedEventArgs e)
        {
            setSummoner();
            getBasicInfo();
            updateUI();
        }

        private void getCurrentGame(object sender, RoutedEventArgs e)
        {
            setCurrentInfo();
        }
    }
}