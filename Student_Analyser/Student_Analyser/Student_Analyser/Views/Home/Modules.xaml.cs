using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Xml.Serialization;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Student_Analyser.Views.Home
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Modules : ContentPage
    {


        static List<Module> list = new List<Module>()
            {
                new Module (name:"SAD381", mark: 45, Module.ColorSelector(45), Module.GetReleventImage(45)),
                new Module (name:"SAD381", mark: 45,Module.ColorSelector(45),
                    Module.GetReleventImage(45)),
                new Module (name:"SAD381", mark: 65,Module.ColorSelector(65),
                Module.GetReleventImage(45)),
                new Module (name:"SAD381", mark: 55,Module.ColorSelector(55),
                    Module.GetReleventImage(55)),
                new Module (name:"SAD381", mark: 36,Module.ColorSelector(45),
                    Module.GetReleventImage(36)),
                new Module (name:"SAD381", mark: 80,Module.ColorSelector(45),
                Module.GetReleventImage(80)),
                new Module (name:"SAD381", mark: 45,Module.ColorSelector(45),
                Module.GetReleventImage(45)),
                new Module (name:"SAD381", mark: 45,Module.ColorSelector(45),
                Module.GetReleventImage(45)),
                new Module (name:"SAD381", mark: 45,Module.ColorSelector(45),
                Module.GetReleventImage(45)),
                new Module(name: "PRG381",mark: 66 ,Module.ColorSelector(70),
                    Module.GetReleventImage(66)),
                new Module(name: "PRG381",mark: 50,Module.ColorSelector(70),
                    Module.GetReleventImage(50)),
                new Module(name: "PRG381",mark: 32 ,Module.ColorSelector(70),
                    Module.GetReleventImage(32)),
                new Module(name: "PRG381",mark: 45 ,Module.ColorSelector(70),
                    Module.GetReleventImage(45)),
                new Module(name: "PRG381",mark: 90 ,Module.ColorSelector(70),
                    Module.GetReleventImage(90)),
                new Module(name: "PRG381",mark: 70,Module.ColorSelector(70),
                    Module.GetReleventImage(70)),
                new Module(name: "PRG381",mark: 70,Module.ColorSelector(70), Module.GetReleventImage(70)),
                new Module(name: "PRG381",mark: 70,Module.ColorSelector(70), Module.GetReleventImage(70))
            };
        public Modules()
        {
            InitializeComponent();

            //Sample code
            listOfModules.FindByName<ListView>("listOfModules");
           
            listOfModules.ItemsSource = list;
            
           // listOfModules.BindingContext = list;
        }

        /// <summary>
        /// Sample class
        /// </summary>
        public class Module
        {
            public Module(string name, int mark)
            {
                Name = name;
                Mark = mark;
            }

            public Module(string name, int mark, Color color)
            {
                Name = name;
                Mark = mark;
                Color = color;
            }

            public Module(string name, int mark, Color color, string path)
            {
                Name = name;
                Path = path;
                Mark = mark;
                Color = color;
            }
            public Module()
            {
                ViewDetailsCommand = new Command(() => Details(GetIndex()));
            }
            public string Name { get; set; }
            public string Path { get; set; }
            public int Mark { get; set; }
            public Color Color { get; set; }

            public override string ToString()
            {
                return string.Format("{0} \n {1}", Name, Mark);
            }

            public static Color ColorSelector(int item)
            {
                Color color = new Color();
       
                if (item >= 50)
                {
                    color = Color.Green;
                }
                else
                { 
                    color = Color.Red;
                }
                return color;

            }
            public static string GetReleventImage(int mark)
            {
                string path = "";
                if(mark >= 80)
                {
                    path = "excellent_arrow.png";
                }
                else if(mark >= 70 && mark <= 79)
                {
                    path = "good_arrow.png";
                }
                else if (mark >= 60 && mark <= 69)
                {
                    path = "promising_arrow.png";
                }
                else if (mark >= 50 && mark <= 59)
                {
                    path = "just_safe_arrow.png";
                }
                else if (mark >= 45 && mark < 49)
                {
                    path = "failing_arrow.png";
                }
                else
                {
                    path = "in_danger_arrow.png";
                }
                return path;
            }

            [XmlIgnore]
            public ICommand ViewDetailsCommand { private set; get; }

            public static string Details(int module)
            {
                return "Module: " + list[module].Name + "\nMark: " + list[module].Mark;
            }
            public int GetIndex()
            {
                return 4;
            }
        }
    }
}