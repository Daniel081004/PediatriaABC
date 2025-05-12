using PediatriaABC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace PediatriaABC.Repositories
{
    public class PediatriaRepository
    {
        
        Sql3778435Context context = new();
        public IEnumerable<Clientes> GetAll()
        {
            return context.Clientes;
        }
        public Clientes? GetById(int id)
        {
            return context.Clientes.FirstOrDefault(x => x.Id == id);
        }

        public void Insert(Clientes cliente, out string Error)
        {
            if (Validar(cliente, out Error))
            {
                context.Add(cliente);
                context.SaveChanges();
            }
        }
        public void Update(Clientes cliente, out string Error)
        {
            if(Validar(cliente, out Error))
            {
                Clientes clienteEditar = context.Clientes.First(x => x.Id == cliente.Id);
                clienteEditar.NombreTutor = cliente.NombreTutor;
                clienteEditar.NombreHijo = cliente.NombreHijo;
                clienteEditar.FechaNacimientoHijo = cliente.FechaNacimientoHijo;
                clienteEditar.Telefono = cliente.Telefono;
                clienteEditar.Direccion = cliente.Direccion;
                clienteEditar.FechaRegistro = cliente.FechaRegistro;
                context.SaveChanges();
            }
        }
        public void Delete(Clientes cliente)
        {
            context.Clientes.Remove(cliente);
            context.SaveChanges();
        }
        bool Validar(Clientes Cliente, out string Errores)
        {
            Errores = "";
            var hoy = DateOnly.FromDateTime(DateTime.Today);
            var hace18Años = hoy.AddYears(-18);
            if (string.IsNullOrWhiteSpace(Cliente.NombreTutor))
            {
                Errores += "Escribe el nombre del tutor\n";
            }
            if (string.IsNullOrWhiteSpace(Cliente.NombreHijo))
            {
                Errores += "Escribe el nombre del hijo\n";
            }
            if (!string.IsNullOrWhiteSpace(Cliente.Telefono) && Regex.IsMatch(Cliente.Telefono, @"^\d{10}$"))
            {
                Errores += "Escribe un numero de telefono valido\n";
            }
            if (string.IsNullOrWhiteSpace(Cliente.Direccion))
            {
                Errores += "Escribe una direccion\n";
            }
            if (Cliente.FechaNacimientoHijo > hoy)
            {
                Errores += "La fecha de nacimiento no puede ser en el futuro\n";
            }
            if (Cliente.FechaNacimientoHijo <= hace18Años)
            {
                Errores += "El niño es mayor de edad\n";
            }

            if (string.IsNullOrWhiteSpace(Errores))
            {
                return true;
            }
            else
            {
                return false;
            }
        }   
    }
}
