using System.Windows.Forms;

namespace PluginTesla
{
    public class PluginTesla : Plugins.PluginTeslaInterface
    {
        private readonly string Name = "Tesla";
        private readonly int Age = 10;
        private readonly int Speed = 200;
        private readonly string ImgUrl = "\\\\Mac\\Home\\Desktop\\4 sem\\ООТПиСП\\oop-3\\media\\tesla.jpeg";

        public string PluginName()
        {
            return this.Name;
        }

        public void ShowInfo()
        {
            var resLine = $"Plugin Info:\nName = {this.Name}\nAge = {this.Age}\nSpeed = {this.Speed}";
            MessageBox.Show(resLine);
        }

        public string returnImgUrl()
        {
            return this.ImgUrl;
        }
    }
}
