using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CapaDatos
{
   public class Bodega_Central
    {
       private int ID_BodegaCentral;
       private int ingrediente;
       private int cantidad;

       public Bodega_Central()
       {
           this.ID_BodegaCentral = 0;
           this.ingrediente = 0;
           this.cantidad = 0;
       }

       public Bodega_Central(int ID_BodegaCentral, int ingrediente, int cantidad)
       {
           this.ID_BodegaCentral = ID_BodegaCentral;
           this.ingrediente = ingrediente;
           this.cantidad = cantidad;
       }

       public int _ID_BodegaCentral
       {
           set { this.ID_BodegaCentral = value; }
           get { return ID_BodegaCentral; }
       }

       public int _ingrediente
       {
           set { this.ingrediente = value; }
           get { return ingrediente; }
       }

       public int _cantidad
       {
           set { this.cantidad = value; }
           get { return cantidad; }
       }
    }
}
