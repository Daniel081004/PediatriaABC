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
        bool Validar()
        {
            Errores = "";
            var hoy = DateOnly.FromDateTime(DateTime.Today);
            var hace18Años = hoy.AddYears(-18);
            if (string.IsNullOrWhiteSpace(Cliente.NombreTutor))
            {
                Errores = "Escribe el nombre del tutor\n";
            }
            if (string.IsNullOrWhiteSpace(Cliente.NombreHijo))
            {
                Errores = "Escribe el nombre del hijo\n";
            }
            if (!string.IsNullOrWhiteSpace(Cliente.Telefono) && Regex.IsMatch(Cliente.Telefono, @"^\d{10}$"))
            {
                Errores = "Escribe un numero de telefono valido\n";
            }
            if (string.IsNullOrWhiteSpace(Cliente.Direccion))
            {
                Errores = "Escribe una direccion\n";
            }
            if(Cliente.FechaNacimientoHijo > hoy)
            {
                Errores = "La fecha de nacimiento no puede ser en el futuro\n";
            }
            if(Cliente.FechaNacimientoHijo <= hace18Años)
            {
                Errores = "El niño es mayor de edad\n";
            }

            if (string.IsNullOrWhiteSpace(Errores))
            {
                return true;
            }
            else
            {
                PropertyChanged?.Invoke(this, new(nameof(Errores)));
                return false;
            }
        }
        private void Agregar()
        {
            if(Cliente != null)
            {
                if (Validar())
                {
                    repository.Insert(Cliente);
                    Vista = "Home";
                    PropertyChanged?.Invoke(this,new(nameof(Vista)));
                }
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
