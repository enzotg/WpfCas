using System;
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
using WpfCas.Models;
using WpfCas.ViewModels;
using WpfCas.Services;

namespace WpfCas
{
    /// <summary>
    /// Interaction logic for EquipoNuevo.xaml
    /// </summary>
    public partial class EquipoNuevo : UserControl
    {
        ApiService _apiSrv = new ApiService();
        EquipoNuevoViewModel _equipoNuevoViewModel;
        Spinner sp;            
        public EquipoNuevo()
        {
            InitializeComponent();

            _equipoNuevoViewModel = new EquipoNuevoViewModel();
            this.DataContext = _equipoNuevoViewModel;
                        
            GetAll();
            
        }

        private async void GetAll()
        {
            try
            {
                List<EquipoNuevoViewModel> lnuevo = (await _apiSrv.GetEquipos())
                    .Select(y => new EquipoNuevoViewModel
                    {
                        EquipoId = y.EquipoId,
                        MacAddress1 = y.MacAddress1,
                        MacAddress2 = y.MacAddress2,
                        Nombre = y.Nombre,
                        Pantalla = y.Pantalla,
                        Serial = y.Serial
                    }).ToList();

                _equipoNuevoViewModel.Equipos = new ObservableCollection<EquipoNuevoViewModel>(lnuevo);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, Name, MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private async void BtnAceptar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Equipo equipo = new Equipo();
                equipo.EquipoId = _equipoNuevoViewModel.EquipoId;
                equipo.MacAddress1 = _equipoNuevoViewModel.MacAddress1;
                equipo.MacAddress2 = _equipoNuevoViewModel.MacAddress2;
                equipo.Nombre = _equipoNuevoViewModel.Nombre;
                equipo.Pantalla = _equipoNuevoViewModel.Pantalla;
                equipo.Serial = _equipoNuevoViewModel.Serial;

                SpinnerIni();
                await _apiSrv.AltaEquipo(equipo);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally  {
                SpinnerFin();
            }
                        


        }

        private void SpinnerIni()
        {
            Grid g = (Grid)Application.Current.MainWindow.FindName("Contenido");
            sp = new Spinner();
            g.Children.Add(sp);
        }
        private void SpinnerFin()
        {
            Grid g = (Grid)Application.Current.MainWindow.FindName("Contenido");            
            g.Children.Remove(sp);
        }

    }
}
