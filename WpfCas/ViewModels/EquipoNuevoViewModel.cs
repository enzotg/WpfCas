using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfCas.ViewModels
{
    public class EquipoNuevoViewModel : ObservableObject
    {        
        private long equipoId;
        private string nombre;
        private string macAddress1;
        private string macAddress2;
        private string serial;
        private string pantalla;

        public long EquipoId
        {
            get { return equipoId; }
            set { equipoId = value; OnPropertyChanged(); }
        }

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; OnPropertyChanged(); }
        }

        public string MacAddress1
        {
            get { return macAddress1; }
            set { macAddress1 = value; OnPropertyChanged(); }
        }
        public string MacAddress2
        {
            get { return macAddress2; }
            set { macAddress2 = value; OnPropertyChanged(); }
        }
        public string Serial
        {
            get { return serial; }
            set { serial = value; OnPropertyChanged(); }
        }

        public string Pantalla
        {
            get { return pantalla; }
            set { pantalla = value; OnPropertyChanged(); }
        }

        private ObservableCollection<EquipoNuevoViewModel> equipos;
        public ObservableCollection<EquipoNuevoViewModel> Equipos
        {
            get { return equipos; }
            set
            {
                equipos = value;
                OnPropertyChanged();
            }
        }

    }
}
