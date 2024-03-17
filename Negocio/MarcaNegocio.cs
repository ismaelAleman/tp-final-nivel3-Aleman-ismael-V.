﻿using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class MarcaNegocio
    {
        AccesoDato dato = new AccesoDato();

        public List<Marca> listaMarcas()
        {
            List<Marca> listaMarc = new List<Marca>();



            try
            {
                dato.hacerConsulta("select Id, Descripcion from Marcas ");
                dato.ejecutarLectura();

                while (dato.Lector.Read())
                {
                    Marca aux = new Marca();
                    aux.Id = (int)dato.Lector["Id"];
                    aux.Descripcion = (String)dato.Lector["Descripcion"];

                    listaMarc.Add(aux);
                }

                return listaMarc;
            }
            catch (Exception)
            {

                throw;
            }

            finally { dato.cerrarConexion(); }




        }


        public void agregarMarca(String descripcion)
        {

            try
            {
                dato.hacerConsulta("insert into MARCAS (Descripcion) values (@Descripcion); ");
                dato.setearParametros("@Descripcion", descripcion);
                dato.ejecutarAccion();


            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally { dato.cerrarConexion(); }

        }

        public void eliminarMarca(int id)
        {
            try
            {
                if (id != 0)
                {
                    dato.hacerConsulta("delete from MARCAS where id = @id ");
                    dato.setearParametros("@id", id);
                    dato.ejecutarAccion();

                }


            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally { dato.cerrarConexion(); }

        }

        public void modificarMarca(Marca marca)
        {
            try
            {
                dato.hacerConsulta(" update Marcas set Descripcion = @Descripcion where id= @id");
                dato.setearParametros("@Descripcion",marca.Descripcion) ;
                dato.setearParametros("id ", marca.Id);
                dato.ejecutarAccion();

            }
            catch (Exception)
            {

                throw;
            }
            finally { dato.cerrarConexion() ; }
        }


    }
}
