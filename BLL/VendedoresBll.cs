using DataVentas.DAL;
using DataVentas.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataVentas.BLL
{
    public class VendedoresBll
    {
        public static bool Guardar(Vendedores vendedores)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                if (contexto.Vendedores.Add(vendedores) != null)
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


        public static Vendedores Buscar(int id)
        {
            Contexto contexto = new Contexto();
            Vendedores vendedores = new Vendedores();
            try
            {
                vendedores = contexto.Vendedores.Find(id);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return vendedores;
        }

        public static bool Modificar(Vendedores vendedores)
        {
            bool paso = false;
            Contexto contexto = new Contexto();
            try
            {
                contexto.Entry(vendedores).State = EntityState.Modified;
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

        public static bool Eliminar(int id)
        {
            bool paso = false;
            Contexto contexto = new Contexto();
            try
            {
                var eliminar = contexto.Vendedores.Find(id);
                contexto.Entry(eliminar).State = EntityState.Deleted;
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

        public static List<Vendedores> GetList(Expression<Func<Vendedores, bool>> vendedores)
        {
            List<Vendedores> lista = new List<Vendedores>();
            Contexto contexto = new Contexto();
            try
            {
                lista = contexto.Vendedores.Where(vendedores).ToList();
            }
            catch (Exception)
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
