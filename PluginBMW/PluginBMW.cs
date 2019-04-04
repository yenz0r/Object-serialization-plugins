using System.Windows.Forms;

namespace PluginBMW
{
    public class PluginBMW : Plugins.PluginBMWinterface
    {
        private readonly string Name = "BMW";
        private readonly string ProductionPlace = "Germany";
        private readonly string DataOfProdaction = "02.10.2018";
        private readonly string ImgUrl = "\\\\Mac\\Home\\Desktop\\4 sem\\ООТПиСП\\oop-3\\media\\bmw.jpeg";

        public string returnName()
        {
            return this.Name;
        }

        public void ShowInfo()
        {
            var resLine = $"Plugin Info:\nName = {this.Name}\nMade by {this.ProductionPlace}\nMade in {this.DataOfProdaction}";
            MessageBox.Show(resLine);
        }

        public string returnImgUrl()
        {
            return this.ImgUrl;
        }
    }
}
