
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Projecte.Model;
using Projecte.APIClient;
using Projecte.Entity;
using Projecte;



namespace Projecte
{
    /// <summary>
    /// Lógica de interacción para Pestanya2.xaml
    /// </summary>
    public partial class Pestanya2 : Window
    {
        MainWindow mainWindow;
        UsersApiClient api;
        // tasca edit;
        //UsersApiClient api;
        public Pestanya2(MainWindow mw, Tasca edit)
        {
            InitializeComponent();
            api = new UsersApiClient();
            refresh();

            if (edit != null)
            {
                //si estic editant la tasca carregaré les dades de tasca als camps
                txt_name.Text = edit.Name;
                txt_id.Text = edit.ID.ToString();
                txt_descripció.Text = edit.Descripcio;
                txt_data.SelectedDate = edit.Data;
                txt_data_1.SelectedDate = edit.Data1;
              //  combobox.SelectedItem = edit.

            }


            

            mainWindow = mw;
            

           // combobox.ItemsSource = await api.GetUsersAsync();

        }
        private async void refresh()
        {
            
            combobox.ItemsSource = await api.GetResponsablesAsync();
        }

        private async  void txt_afegirbuto_Click( object sender, RoutedEventArgs e)
        {
            Tasca oresp = new Tasca();
            oresp.ID = txt_id.CaretIndex;
            oresp.Name = txt_name.Text;
            responsable res = (responsable)combobox.SelectedItem;
          //  oresp.ResponsableTasca = res.Name;
            oresp.Descripcio = txt_descripció.Text;
            oresp.Data = DateTime.Parse(txt_data.Text);
            oresp.Data1 = DateTime.Parse(txt_data_1.Text);
            oresp.Estat = "todo";
            await api.AddAsync(oresp);
           
             mainWindow.refresh();
            refresh();
           txt_id.Clear();
           txt_name.Clear();
            txt_descripció.Clear();

           // refresh();
            mainWindow.refresh();
         //   combobox.ItemsSource = await api.GetResponsablesAsync();

            this.Close();
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

        private void listbox_1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
