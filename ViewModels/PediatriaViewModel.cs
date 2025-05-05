using CommunityToolkit.Mvvm.Input;
using PediatriaABC.Models;
using PediatriaABC.Repositories;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PediatriaABC.ViewModels
{
    public class PediatriaViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<Clientes> ListaClientes { get; set; } = new();
        PediatriaRepository repository = new();
        public string Vista { get; set; } = "Home";
        public string Errores { get; set; } = "";
        public Clientes Cliente { get; set; } = new();
        public ICommand VerAgregarCommand { get; set; }
        public ICommand AgregarCommand { get; set; }
        public ICommand CancelarCommand { get; set; }
        public PediatriaViewModel()
        {
            VerAgregarCommand = new RelayCommand(VerAgregar);
            AgregarCommand = new RelayCommand(Agregar);
            CancelarCommand = new RelayCommand(Cancelar);
        }

        private void Cancelar()
        {
            Vista = "Home";
            PropertyChanged?.Invoke(this, new(nameof(Vista)));
            PropertyChanged?.Invoke(this, new(nameof(ListaClientes)));
        }

        private void Agregar()
        {
            if (Cliente != null)
            {
                repository.Insert(Cliente, Errores);
                Vista = "Home";
                PropertyChanged?.Invoke(this, new(nameof(Vista)));
            }
        }

        private void VerAgregar()
        {
            Vista = "Agregar";
            Cliente = new();
            Errores = "";
            PropertyChanged?.Invoke(this,new(nameof(Vista)));
            PropertyChanged?.Invoke(this, new(nameof(Cliente)));
            PropertyChanged?.Invoke(this, new(nameof(Errores)));
        }

        public event PropertyChangedEventHandler? PropertyChanged;
    }
}
