using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
using Projecte.Model;
using Projecte.APIClient;


namespace Projecte
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        //MainWindow mainWindow;
       UsersApiClient api;
       

        public MainWindow()
        {
            InitializeComponent();
            // DbContext.Up();
            api = new UsersApiClient();
            refresh();
        }



        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //textbox_1.ItemsSource = tasca_1.Text;
            Pestanya2 pestanya2 = new Pestanya2(this, null);
            pestanya2.ShowDialog();

            //Tasca tasc = new Tasca();
            //tasc.Name = tasca_1.Text;
            //TascaService.Add(tasc);
            refresh();


            // textbox_1.Items.Add(tasca_1.Text);

        }
        public void TextBox_tasca_1(object sender, RoutedEventArgs e)
        {
            TextBox tb = (TextBox)sender;
            tb.Text = string.Empty;
            tb.GotFocus -= TextBox_tasca_1;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
           
            Pestanya1 pestanya1 = new Pestanya1();
            pestanya1.ShowDialog();

        }

        private async void Button_Click1(object sender, RoutedEventArgs e)
        {
            if(MessageBox.Show("¿Eliminar usuario seleccionado?", "Eliminar", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)


            if (textbox_1.SelectedItem!=null)
            {
                int index = textbox_1.SelectedIndex;
                Tasca tb = (Tasca)textbox_1.Items[index];
                await api.DeleteTascaAsync(tb.ID);
            }

            if (textbox_2.SelectedItem != null)
            {
                int index = textbox_2.SelectedIndex;
                Tasca tb = (Tasca)textbox_2.Items[index];
                await api.DeleteTascaAsync(tb.ID);
            }


            if (textbox_3.SelectedItem != null)
            {
                int index = textbox_3.SelectedIndex;
                Tasca tb = (Tasca)textbox_3.Items[index];
                await api.DeleteTascaAsync(tb.ID);
            }

            refresh();
            
        }

        private void textbox_2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
        public async void refresh()
        {
            //HAURIA DE SER GETUPDATE (PREG. PROFE)
            //textbox_1.ItemsSource = await api.GetUsersAsync(); //textbox_2.ItemsSource = TascaService.GetAll("to do");
            //textbox_2.ItemsSource = await api.GetUsersAsync();
            //textbox_3.ItemsSource = await api.GetUsersAsync();

            
            textbox_1.ItemsSource = await api.GetTascatodoAsync();
            textbox_2.ItemsSource = await api.GetTascadoingAsync();
            textbox_3.ItemsSource = await api.GetTascadoneAsync();
        }

        private async void button_endarrere_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int index = textbox_2.SelectedIndex;
                Tasca tb = (Tasca)textbox_2.Items[index];

                tb.Estat = "todo";
                await api.UpdateAsync(tb);
                refresh();
            }
            catch (Exception)
            {
                MessageBox.Show("No puedes hacer esto crack", "Error");
            }
        

    }

        private async void button_endavant_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                int index = textbox_1.SelectedIndex;
                Tasca tb = (Tasca)textbox_1.Items[index];

                tb.Estat = "doing";
                await api.UpdateAsync(tb);
                refresh();
            }

            catch (Exception)
            {
                MessageBox.Show("No puedes hacer esto crack", "Error");
            }


        }

        private void EditUser(object sender, RoutedEventArgs e)
        {
            

            if (textbox_1.SelectedItem != null)
            {
                Tasca oTasca = (Tasca)textbox_1.SelectedItem;
                editarr p = new editarr(this, oTasca);
                p.ShowDialog();
            }

            if (textbox_2.SelectedItem != null)
            {
                Tasca oTasca = (Tasca)textbox_2.SelectedItem;
                editarr p = new editarr(this, oTasca);
                p.ShowDialog();
            }


            if (textbox_3.SelectedItem != null)
            {
                Tasca oTasca = (Tasca)textbox_3.SelectedItem;
                editarr p = new editarr(this, oTasca);
                p.ShowDialog();
            }
            refresh();
        }

        private async void Button_Click_2(object sender, RoutedEventArgs e)
        {
            try
            {
                int index = textbox_3.SelectedIndex;
                Tasca tb = (Tasca)textbox_3.Items[index];

                tb.Estat = "doing";
                await api.UpdateAsync(tb);
                refresh();
            }

            catch (Exception)
            {
                MessageBox.Show("No puedes hacer esto crack", "Error");
            }
        }

        private  async void button_endavant2_Click(object sender, RoutedEventArgs e)
        {
            try {


                int index = textbox_2.SelectedIndex;
                Tasca tb = (Tasca)textbox_2.Items[index];

                tb.Estat = "done";
                await api.UpdateAsync(tb);
                refresh();
            }

             catch (Exception)
            {
                MessageBox.Show("No puedes hacer esto crack", "Error");
            }
        }
    }

}
      /*  private void Window_ContentRendered(object sender, EventArgs e)
        {
            //Obtenim la llista des d'on s'ha polsat 
            ListBox parent = (ListBox)sender;
            dragSource = parent;
            //Obtenim l'element seleccionat
            object data = GetDataFromListBox(dragSource, e.GetPosition(parent));

            if (data != null)
            {
                DragDrop.DoDragDrop(parent, data, DragDropEffects.Move);
            }
        }

        private object GetDataFromListBox(ListBox dragSource, object p)
        {
            throw new NotImplementedException();
        }

        private void ListBox_Drop(object sender, DragEventArgs e)
        {
            ListBox parent = (ListBox)sender;
            object data = e.Data.GetData(typeof(string));
            ((IList)dragSource.ItemsSource).Remove(data);
            ((IList)parent.ItemsSource).Add(data);
        }
    }

    }

*/