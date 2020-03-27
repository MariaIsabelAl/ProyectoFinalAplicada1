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
    public class PagosVentasBll
    {
        public static bool Guardar(PagosVentas pagosventas)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                if (contexto.PagosVentas.Add(pagosventas) != null)
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


        public static PagosVentas Buscar(int id)
        {
            Contexto contexto = new Contexto();
            PagosVentas pagosventas = new PagosVentas();
            try
            {
                pagosventas = contexto.PagosVentas.Find(id);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return pagosventas;
        }

        public static bool Modificar(PagosVentas pagosventas)
        {
            bool paso = false;
            Contexto contexto = new Contexto();
            try
            {
                contexto.Entry(pagosventas).State = EntityState.Modified;
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
                var eliminar = contexto.PagosVentas.Find(id);
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

        public static List<PagosVentas> GetList(Expression<Func<PagosVentas, bool>> pagosventas)
        {
            List<PagosVentas> lista = new List<PagosVentas>();
            Contexto contexto = new Contexto();
            try
            {
                lista = contexto.PagosVentas.Where(pagosventas).ToList();
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
