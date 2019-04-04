using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Reflection;
using Plugins;
using System.Drawing;

namespace oop_3
{
    public partial class Form1 : Form
    {
        List<Car> carList = new List<Car>();
        List<string> connectedPlugins = new List<string>();

        private Car car         = new Car(10, 200);
        private Car sportCar    = new SportCar(3, 210, 280);
        private Car truckCar    = new TruckCar(8, 40, 50, 35);
        private Car familyCar   = new FamilyCar(3, 60, 8, 6);
        private Car audi        = new AudiR8(2, 225, 240, 120);
        private Car volkswagen  = new Volkswagen(4, 50, 5, 5, 2000);
        private Car belarus520  = new Belarus520(3, 30, 30, 25);

        private Serializer ser = new Serializer();

        public Form1()
        {
            InitializeComponent();
        }

        Car changingClass;

        private Car getClassByIndex(int inputIndex)
        {
            switch (inputIndex)
            {
                case 0:
                    return car;
                case 1:
                    return sportCar;
                case 2:
                    return familyCar;
                case 3:
                    return truckCar;
                case 4:
                    return audi;
                case 5:
                    return volkswagen;
                case 6:
                    return belarus520;
            }
            return null; 
        }

        private void cbClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            void inputProperties(ComboBox cb)
            {
                cb.Items.Clear();

                foreach (PropertyInfo prop in Serializer.getPropsArr<Car>(changingClass))
                {
                    cb.Items.Add($"{prop.Name}");
                }
            }

            changingClass = getClassByIndex(cbClass.SelectedIndex);

            inputProperties(cbProperty);
        }

        private void btnChangeValue_Click(object sender, EventArgs e)
        {
            int newValue;
            try
            {
                newValue = int.Parse(tbNewValueForProperty.Text);
                Car.update(cbProperty.SelectedIndex, newValue, changingClass);
            }
            catch (FormatException)
            {
                tbNewValueForProperty.Text = "incorrect int..";
                return;
            }
        }

        private void pushToList()
        {
            void inputList(CheckBox cb, int index, ref List<Car> list, ref Car obj)
            {
                if (cb.Checked)
                {
                    if (obj == null)
                    {
                        obj = getClassByIndex(index);
                    }
                    list.Add(obj);
                }
            }

            carList.Clear();

            inputList(cbCarAdd, 0, ref carList, ref car);
            inputList(cbSportCarAdd, 1, ref carList, ref sportCar);
            inputList(cbFamilyCarAdd, 2, ref carList, ref familyCar);
            inputList(cbTruckCarAdd, 3, ref carList, ref truckCar);
            inputList(cbAudiAdd, 4, ref carList, ref audi);
            inputList(cbVolkswagenAdd, 5, ref carList, ref volkswagen);
            inputList(cbBelarusAdd, 6, ref carList, ref belarus520);
        }

        
        private void btnSerializeText_Click(object sender, EventArgs e)
        {
            pushToList();
            var serializedClasses = "STATUS:\n===\nFiles added :";
            foreach (var workingClass in carList)
            {
                var fileName = $"{workingClass.GetType().Name}.txt";
                ser.Serialize(fileName, workingClass);
                serializedClasses += $"\n{fileName}";
            }
            statusLabel.Text = serializedClasses;
        }

        private void btnDeserialize_Click(object sender, EventArgs e)
        {
            var createdClasses = "STATUS:\n===\nObject created :";
            List<Car> tmpList = new List<Car>();
            foreach (var workingClass in carList)
            {
                var fileName = $"{workingClass.GetType().Name}.txt";
                Car newObj = (Car)ser.Deserialize(fileName);
                tmpList.Add(newObj);
                createdClasses += $"\n{fileName.Substring(0, fileName.Length - 4)}";
            }
            carList = tmpList;
            statusLabel.Text = createdClasses;
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            var statusMsg = "";
            try
            {
                foreach (PropertyInfo prop in Serializer.getPropsArr<Car>(changingClass))
                {
                    statusMsg += $"{prop.Name} : {prop.GetValue(changingClass).ToString()}\n";
                }
                statusMsg = $"{statusMsg}";
            }
            catch
            {
                statusMsg = $"Error of reading..";
            }
            statusLabel.Text = $"STATUS : \n===\n{statusMsg}";
        }

        private void LoadPlugin_Click(object sender, EventArgs e)
        {
            void addImg(string imgUrl)
            {
                try
                {
                    pbPluginImg.Image = Image.FromFile(imgUrl);
                }
                catch
                {
                    pbPluginImg.Image = Image.FromFile("\\\\Mac\\Home\\Desktop\\4 sem\\ООТПиСП\\oop-3\\media\\error.png");
                }
            }

            OpenFileDialog op = new OpenFileDialog();
            if (op.ShowDialog() == DialogResult.OK)
            {
                int index = op.FileName.LastIndexOf('\\');
                string fn = op.FileName.Substring(index + 1);

                if (connectedPlugins.Contains(fn))
                {
                    MessageBox.Show("Plugin is already connected..");
                    return;
                }

                Assembly.LoadFrom(op.FileName);
                foreach (Assembly asm in AppDomain.CurrentDomain.GetAssemblies())
                {
                    foreach (Type type in asm.GetTypes())
                    {
                        if (fn.Equals("PluginTesla.dll") && type.Name.Equals("PluginTesla"))
                        {
                            PluginTeslaInterface tesla = Activator.CreateInstance(type) as PluginTeslaInterface;
                            if (tesla != null)
                            {
                                lblAdeddPlugins.Text += $"\n{tesla.PluginName()}";
                                addImg(tesla.returnImgUrl());
                                tesla.ShowInfo();
                                connectedPlugins.Add(fn);
                                return;
                            }
                        }
                        if (fn.Equals("PluginBMW.dll") && type.Name.Equals("PluginBMW"))
                        {
                            PluginBMWinterface bmw = Activator.CreateInstance(type) as PluginBMWinterface;
                            if (bmw != null)
                            {
                                lblAdeddPlugins.Text += $"\n{bmw.returnName()}";
                                addImg(bmw.returnImgUrl());
                                bmw.ShowInfo();
                                connectedPlugins.Add(fn);
                                return;
                            }
                        }
                    }
                }
            }
            MessageBox.Show("incorect *.dll");
        }
    }
}
