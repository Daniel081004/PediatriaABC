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
        private string errores = "", vista = "";
        public string Vista
        {
            get { return vista; }
            set
            {
                vista = value;
                PropertyChanged?.Invoke(this, new(nameof(vista)));
            }
        }
        public string Errores
        {
            get { return errores; }
            set
            {
                errores = value;
                PropertyChanged?.Invoke(this,new(nameof(Errores)));
            }
        }
        public Clientes Cliente { get; set; } = new();
        public ICommand VerAgregarCommand { get; set; }
        public ICommand VerEditarCommand { get; set; }
        public ICommand VerEliminarCommand { get; set; }
        public ICommand AgregarCommand { get; set; }
        public ICommand EditarCommand { get; set; }
        public ICommand EliminarCommand { get; set; }
        public ICommand CancelarCommand { get; set; }
        public PediatriaViewModel()
        {
            VerAgregarCommand = new RelayCommand(VerAgregar);
            VerEditarCommand = new RelayCommand(VerEditar);
            VerEliminarCommand = new RelayCommand(VerEliminar);
            AgregarCommand = new RelayCommand(Agregar);
            EditarCommand = new RelayCommand(Editar);
            EliminarCommand = new RelayCommand(Eliminar);
            CancelarCommand = new RelayCommand(Cancelar);
        }

        private void Eliminar()
        {
            throw new NotImplementedException();
        }

        private void Editar()
        {
            throw new NotImplementedException();
        }

        private void VerEliminar()
        {
            throw new NotImplementedException();
        }

        private void VerEditar()
        {
            Vista = "Eliminar";
        }

        private void Cancelar()
        {
            Vista = "Home";
        }

        private void Agregar()
        {
            if (Cliente != null)
            {
                repository.Insert(Cliente, out errores);
                if (string.IsNullOrWhiteSpace(errores))
                {
                    Vista = "Home";
                }
            }
        }

        private void VerAgregar()
        {
            Vista = "Agregar";
            Cliente = new();
            Errores = "";
            PropertyChanged?.Invoke(this, new(nameof(Cliente)));
        }
        public event PropertyChangedEventHandler? PropertyChanged;
    }
}
