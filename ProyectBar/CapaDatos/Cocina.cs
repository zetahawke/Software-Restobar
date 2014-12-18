using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CapaDatos
{
   public class Cocina
    {
       private int ID_Cocina;
       private string Nombre;

       public Cocina()
       {
           ID_Cocina = 0;
           Nombre = "";
       }

       public Cocina(int ID_Cocina, string Nombre)
       {
           this.ID_Cocina = ID_Cocina;
           this.Nombre = Nombre;
       }

       public int _ID_Cocina
       {
           set { this.ID_Cocina = value; }
           get { return ID_Cocina; }
       }

       public string _Nombre
       {
           set { this.Nombre = value; }
           get { return Nombre; }
       }
    }
}
