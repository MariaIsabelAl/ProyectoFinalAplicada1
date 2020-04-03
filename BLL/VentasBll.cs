using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using DataVentas.DAL;
using DataVentas.Entidades;
using System.Linq.Expressions;
using System.Linq;

namespace DataVentas.BLL
{
    public class VentasBll
    {
        public static bool Guardar(Ventas ventas)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                if (contexto.Ventas.Add(ventas) != null)
                    paso = contexto.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return paso;
        }

        public static Ventas Buscar(int id)
        {
            Contexto contexto = new Contexto();
            Ventas ventas = new Ventas();

            try
            {
                ventas = contexto.Ventas.Include(x => x.VentaDetalle)
                    .Where(p => p.VentaId == id)
                    .SingleOrDefault();

            }
            catch
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return ventas;
        }
        public static bool Modificar(Ventas ventas)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                contexto.Database.ExecuteSqlRaw($"DELETE FROM VentasDetalles Where VentaId = {ventas.VentaId}");
                foreach (var anterior in ventas.VentaDetalle)
                {
                    contexto.Entry(anterior).State = EntityState.Added;
                }
                
                contexto.Entry(ventas).State = EntityState.Modified;
                paso = (contexto.SaveChanges() > 0);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return paso;

        }

        public static bool Eliminar(int id)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                var eliminar = contexto.Ventas.Find(id);
                contexto.Entry(eliminar).State = EntityState.Deleted;

                paso = (contexto.SaveChanges() > 0);
            }
            catch
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return paso;
        }




        public static List<Ventas> GetList(Expression<Func<Ventas, bool>> ventas)
        {
            List<Ventas> lista = new List<Ventas>();
            Contexto contexto = new Contexto();
            try
            {
                lista = contexto.Ventas.Where(ventas).ToList();
            }
            catch
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return lista;
        }
    }
}
