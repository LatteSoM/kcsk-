using SunCloud.View.Windows;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SunCloud
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            try
            {
                InitializeComponent();
                CurrCityTbx.Foreground = Brushes.White;
                CurrCityTbx.Text = "Ваш город";
                CurrCityTbx.GotFocus += CurrCityTbx_GotFocus;
                CurrCityTbx.LostFocus += CurrCityTbx_LostFocus;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }
        }

        // переход на окно с инфой о погоде в городе
        private void WhatWeatherBtn_Click(object sender, RoutedEventArgs e)
        {
            PrimaryWindow a = new PrimaryWindow();
            a.Show();
            
        }

        //Метод для перетаскивания окна
        private void DragWindow(object sender, MouseButtonEventArgs e)
        {
            try
            {
                DragMove();
            }
            catch (Exception)
            {
                //throw;
            }
        }

        private void CloseWindow(object sender, MouseButtonEventArgs e)
        {
            try
            {
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                //throw;
            }
        }

        //окно на фуллскрин. не доделан возврат к прошлому размеру по повторному нажатию. мне лень
        private void MaximizeWindow(object sender, MouseButtonEventArgs e)
        {
            try
            {
                this.WindowState = WindowState.Maximized;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                //throw;
            }
        }

        // сворачивание окна
        private void MinimizeWindow(object sender, MouseButtonEventArgs e)
        {
            try
            {
                this.WindowState = WindowState.Minimized;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                //throw;
            }
        }

        private void CurrCityTbx_TextChanged(object sender, TextChangedEventArgs e)
        {
            // показываем или скрываем кнопку очистки, в зависимости от содержимого TextBox
            if (string.IsNullOrWhiteSpace(CurrCityTbx.Text))
            {
                BtnClearTextBox.Visibility = Visibility.Collapsed;
            }
            else
            {
                BtnClearTextBox.Visibility = Visibility.Visible;
            }
        }

        private void CurrCityTbx_GotFocus(object sender, RoutedEventArgs e)
        {
            // если юзер нажимает на кнопку, очищаем хинт
            if (CurrCityTbx.Text == "Ваш город")
            {
                CurrCityTbx.Text = string.Empty;
                BtnClearTextBox.Visibility = Visibility.Visible;
            }
        }

        private void CurrCityTbx_LostFocus(object sender, RoutedEventArgs e)
        {
            // если текстбокс пустой, показываем хинт
            if (string.IsNullOrWhiteSpace(CurrCityTbx.Text))
            {
                CurrCityTbx.Text = "Ваш город";
                CurrCityTbx.Foreground = Brushes.White;
            }
        }

        private void BtnClearTextBox_Click(object sender, RoutedEventArgs e)
        {
            // очищаем текстбокс по кнопке
            CurrCityTbx.Text = string.Empty;
            BtnClearTextBox.Visibility = Visibility.Collapsed;
        }
    }
}
