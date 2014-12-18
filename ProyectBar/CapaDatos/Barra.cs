using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CapaDatos
{
   public class Barra
    {
       private int ID_Barra;
       private string Nombre;

       public Barra()
       {
           ID_Barra = 0;
           Nombre = "";
       }

       public Barra(int ID_Barra, string Nombre)
       {
           this.ID_Barra = ID_Barra;
           this.Nombre = Nombre;
       }

       public int _ID_Barra
       {
           set { this.ID_Barra = value; }
           get { return ID_Barra; }
       }

       public string _Nombre
       {
           set { this.Nombre = value; }
           get { return Nombre; }
       }
    }
}
