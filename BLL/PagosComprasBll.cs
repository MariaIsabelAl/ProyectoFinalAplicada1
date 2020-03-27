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
    public class PagosComprasBll
    {
        public static bool Guardar(PagosCompras pagoscompras)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                if (contexto.PagosCompras.Add(pagoscompras) != null)
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


        public static PagosCompras Buscar(int id)
        {
            Contexto contexto = new Contexto();
            PagosCompras pagoscompras = new PagosCompras();
            try
            {
                pagoscompras = contexto.PagosCompras.Find(id);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return pagoscompras;
        }

        public static bool Modificar(PagosCompras pagoscompras)
        {
            bool paso = false;
            Contexto contexto = new Contexto();
            try
            {
                contexto.Entry(pagoscompras).State = EntityState.Modified;
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
                var eliminar = contexto.PagosCompras.Find(id);
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

        public static List<PagosCompras> GetList(Expression<Func<PagosCompras, bool>> pagoscompras)
        {
            List<PagosCompras> lista = new List<PagosCompras>();
            Contexto contexto = new Contexto();
            try
            {
                lista = contexto.PagosCompras.Where(pagoscompras).ToList();
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
