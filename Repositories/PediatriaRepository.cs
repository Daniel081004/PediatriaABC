using PediatriaABC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PediatriaABC.Repositories
{
    public class PediatriaRepository
    {
        Sql3775903Context context = new();
        public IEnumerable<Clientes> GetByAll()
        {
            return context.Clientes;
        }
        public Clientes? GetById(int id)
        {
            return context.Clientes.FirstOrDefault(x => x.Id == id);
        }

        public void Insert(Clientes cliente)
        {
            context.Add(cliente);
            context.SaveChanges();
        }
    }
}
