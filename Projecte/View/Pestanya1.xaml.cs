using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Projecte.APIClient;
using Projecte.Model;
using Projecte.Entity;

namespace Projecte
{
    /// <summary>
    /// Lógica de interacción para Pestanya1.xaml
    /// </summary>
    public partial class Pestanya1 : Window
    {
        UsersApiClient api;
        responsable nom;
        public Pestanya1()
        {
            InitializeComponent();
            api = new UsersApiClient();

            refresh();

        }
        private async void refresh()
        {
            listbox_1.ItemsSource = await api.GetResponsablesAsync();
        }
       
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private async void Button_Click_1(object sender, RoutedEventArgs e)
        {

            refresh();
            responsable oresp = new responsable();
            oresp.Name = nom_entrat.Text;
            await api.AddAsync(oresp);
            listbox_1.ItemsSource = await api.GetResponsablesAsync();


            /*   try
               {
                   await api.UpdateAsync(nom);
                   this.Close();
               }
               catch (Exception ex)
               {
                   MessageBox.Show(ex.Message);
               }
            */







            nom_entrat.Clear();

        }

        public void TextBox_responsable_1(object sender, RoutedEventArgs e)
        {
            TextBox tb = (TextBox)sender;
            tb.Text = string.Empty;
            tb.GotFocus -= TextBox_responsable_1;
        }
        
        private async void butto_eliminar_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("¿Eliminar usuario seleccionado?", "Eliminar", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    //Agafem les dades del item seleccionat
                    responsable oresp = (responsable)listbox_1.SelectedItem;

                    //Eliminen usuari
                    await api.DeleteAsync(oresp.ID);

                    //Actualitzem dades del grid
                    refresh();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

        }

        private void nom_entrat_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void listbox_1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }


        /* public async void refresh()
{
    Mouse.OverrideCursor = System.Windows.Input.Cursors.Wait;
    listbox_1.ItemsSource = await api.UpdateAsync();
    Mouse.OverrideCursor = System.Windows.Input.Cursors.Arrow;
}
*/
    }
}
