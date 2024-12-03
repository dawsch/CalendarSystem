using System.Configuration;
using System.Data;
using System.Windows;

namespace calendar
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
        }
        public void ChangeTheme(Uri themeUri)
        {
            ResourceDictionary newTheme = new ResourceDictionary() { Source = themeUri };
            // Usuń istniejące motywy
            Resources.MergedDictionaries.Clear();
            // Dodaj nowy motyw
            Resources.MergedDictionaries.Add(newTheme);
        }
    }

}
