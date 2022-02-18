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
using WpfCas.Services;
using WpfCas.ViewModels;

namespace WpfCas
{
    /// <summary>
    /// Interaction logic for EquipoLista.xaml
    /// </summary>
    public partial class EquipoLista : UserControl
    {
        ApiService _apiSrv = new ApiService();
        EquipoNuevoViewModel _equipoNuevoViewModel;

        public EquipoLista()
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Name, MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
