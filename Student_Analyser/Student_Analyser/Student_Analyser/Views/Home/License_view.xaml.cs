using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Student_Analyser.Views.Home
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class License_view : ContentPage
    {
        public License_view()
        {
            InitializeComponent();
            BindingContext = LoadText(GetAssembly());
        }

        /// <summary>
        /// Reads the text from the text file in the specified assembly
        /// </summary>
        /// <param name="assembly"></param>
        /// <returns></returns>
        private string LoadText(Assembly assembly)
        {
            //To replace with proper license text
            Stream stream = assembly.GetManifestResourceStream("Student_Analyser.LICENSES.txt");


            using (var reader = new StreamReader(stream))
            {
                string text = reader.ReadToEnd();
                return text;
            }
        }

        /// <summary>
        /// Gets the application assembly.
        /// </summary>
        /// <returns>Assembly</returns>
        private Assembly GetAssembly()
        {
            var assembly = IntrospectionExtensions.GetTypeInfo(typeof(License_view)).Assembly;

            return assembly;
        }
    }
}