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
    public class ComprasBll
    {
        public static bool Guardar(Compras compras)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                if (contexto.Compras.Add(compras) != null)
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

        public static Compras Buscar(int id)
        {
            Contexto contexto = new Contexto();
            Compras compras = new Compras();

            try
            {
                compras = contexto.Compras.Include(x => x.CompraDetalle)
                    .Where(p => p.CompraId == id)
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

            return compras;
        }
        public static bool Modificar(Compras compras)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                contexto.Database.ExecuteSqlRaw($"Delete FROM ComprasDetalles Where CompraId={compras.CompraId}");
                foreach (var anterior in compras.CompraDetalle)
                {
                    contexto.Entry(anterior).State = EntityState.Added;
                }
                contexto.Entry(compras).State = EntityState.Modified;
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
                var eliminar = contexto.Compras.Find(id);
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




        public static List<Compras> GetList(Expression<Func<Compras, bool>> compras) 
        {
            List<Compras> lista = new List<Compras>();
            Contexto contexto = new Contexto();
            try
            {
                lista = contexto.Compras.Where(compras).ToList();
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
