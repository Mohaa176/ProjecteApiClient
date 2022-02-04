using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Projecte.Model;
using Projecte.APIClient;




namespace Projecte
{
    /// <summary>
    /// Lógica de interacción para editarr.xaml
    /// </summary>
    public partial class editarr : Window
    {
        UsersApiClient api;
        Tasca otasca;
        public editarr(MainWindow mw, Tasca editar)
        {
            InitializeComponent();
            
            this.DataContext = editar;

            if (editar != null)
            {
                //si estic editant la tasca carregaré les dades de tasca als camps
                txt_name.Text = editar.Name;
                txt_id.Text = editar.ID.ToString();
                txt_descripció.Text = editar.Descripcio;
                txt_data.SelectedDate = editar.Data;
                txt_data_1.SelectedDate = editar.Data1;
                //  combobox.SelectedItem = edit.

            }

           // combobox.ItemsSource = ResponsableService.GetAll();
           

        }

        public void TextBox_txt_id(object sender, RoutedEventArgs e)
        {
            TextBox tb = (TextBox)sender;
            tb.Text = string.Empty;
            tb.GotFocus -= TextBox_txt_id;
        }
        public void TextBox_txt_descripció(object sender, RoutedEventArgs e)
        {
            TextBox tb = (TextBox)sender;
            tb.Text = string.Empty;
            tb.GotFocus -= TextBox_txt_descripció;
        }
        public void TextBox_txt_responsable(object sender, RoutedEventArgs e)
        {
            TextBox tb = (TextBox)sender;
            tb.Text = string.Empty;
            tb.GotFocus -= TextBox_txt_responsable;
        }
        public void TextBox_txt_data(object sender, RoutedEventArgs e)
        {
            TextBox tb = (TextBox)sender;
            tb.Text = string.Empty;
            tb.GotFocus -= TextBox_txt_data;
        }

        private async void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
               // await api.UpdateAsync(otasca);
                
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
/*
        public async void refresh()
        {
            Mouse.OverrideCursor = System.Windows.Input.Cursors.Wait;
           // txt_id.Text = await api.UpdateAsync(otasca);
            Mouse.OverrideCursor = System.Windows.Input.Cursors.Arrow;
        }
*/
    }
}