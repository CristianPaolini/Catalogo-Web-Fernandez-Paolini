﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Negocio;

namespace Carrito_Compras
{
    public partial class Calcs : System.Web.UI.Page
    {
        public Articulo articuloSelec { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {

            List<Articulo> listaCarrito = (List<Articulo>)Session[Session.SessionID + "listaCarrito"];
            ArticuloNegocio negocio = new ArticuloNegocio();
            List<Articulo> listaAux;
            try
            {
                listaAux = negocio.listar();
                int idQuitar = Convert.ToInt32(Request.QueryString["idQuitar"]);
                articuloSelec = listaAux.Find(i => i.Id == idQuitar);

                if (listaCarrito == null)
                {
                    listaCarrito = new List<Articulo>();
                }
                if (Session["listaCarrito"] == null)
                {
                    Response.Redirect("CatalogoArticulos.aspx");
                }

                if(Request.QueryString["idQuitar"] != null)
                {
                    List<Articulo> listaArticulos = (List<Articulo>)Session["listaArtAgregados"];
                    listaCarrito = (List<Articulo>)Session["listaCarrito"];
                    listaCarrito.Remove(listaCarrito.Find(i => i.Id == idQuitar));
                    Session["listaCarrito"] = listaCarrito;
                    Response.Redirect("Carrito.aspx");
                }

                listaCarrito = (List<Articulo>)Session["listaCarrito"];

                
            }
            catch (Exception ex)
            {

                throw ex;
            }


        }
    }
}
           