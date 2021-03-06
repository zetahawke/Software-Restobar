﻿//------------------------------------------------------------------------------
// <auto-generated>
//    Este código se generó a partir de una plantilla.
//
//    Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//    Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.ComponentModel;
using System.Data.EntityClient;
using System.Data.Objects;
using System.Data.Objects.DataClasses;
using System.Linq;
using System.Runtime.Serialization;
using System.Xml.Serialization;

[assembly: EdmSchemaAttribute()]
namespace ProyectBar.Models
{
    #region Contextos
    
    /// <summary>
    /// No hay documentación de metadatos disponible.
    /// </summary>
    public partial class SectorEntities : ObjectContext
    {
        #region Constructores
    
        /// <summary>
        /// Inicializa un nuevo objeto SectorEntities usando la cadena de conexión encontrada en la sección 'SectorEntities' del archivo de configuración de la aplicación.
        /// </summary>
        public SectorEntities() : base("name=SectorEntities", "SectorEntities")
        {
            this.ContextOptions.LazyLoadingEnabled = true;
            OnContextCreated();
        }
    
        /// <summary>
        /// Inicializar un nuevo objeto SectorEntities.
        /// </summary>
        public SectorEntities(string connectionString) : base(connectionString, "SectorEntities")
        {
            this.ContextOptions.LazyLoadingEnabled = true;
            OnContextCreated();
        }
    
        /// <summary>
        /// Inicializar un nuevo objeto SectorEntities.
        /// </summary>
        public SectorEntities(EntityConnection connection) : base(connection, "SectorEntities")
        {
            this.ContextOptions.LazyLoadingEnabled = true;
            OnContextCreated();
        }
    
        #endregion
    
        #region Métodos parciales
    
        partial void OnContextCreated();
    
        #endregion
    
        #region Propiedades de ObjectSet
    
        /// <summary>
        /// No hay documentación de metadatos disponible.
        /// </summary>
        public ObjectSet<Sector> Sector
        {
            get
            {
                if ((_Sector == null))
                {
                    _Sector = base.CreateObjectSet<Sector>("Sector");
                }
                return _Sector;
            }
        }
        private ObjectSet<Sector> _Sector;

        #endregion

        #region Métodos AddTo
    
        /// <summary>
        /// Método desusado para agregar un nuevo objeto al EntitySet Sector. Considere la posibilidad de usar el método .Add de la propiedad ObjectSet&lt;T&gt; asociada.
        /// </summary>
        public void AddToSector(Sector sector)
        {
            base.AddObject("Sector", sector);
        }

        #endregion

    }

    #endregion

    #region Entidades
    
    /// <summary>
    /// No hay documentación de metadatos disponible.
    /// </summary>
    [EdmEntityTypeAttribute(NamespaceName="SectorModel", Name="Sector")]
    [Serializable()]
    [DataContractAttribute(IsReference=true)]
    public partial class Sector : EntityObject
    {
        #region Método de generador
    
        /// <summary>
        /// Crear un nuevo objeto Sector.
        /// </summary>
        /// <param name="iD_Sector">Valor inicial de la propiedad ID_Sector.</param>
        public static Sector CreateSector(global::System.Int32 iD_Sector)
        {
            Sector sector = new Sector();
            sector.ID_Sector = iD_Sector;
            return sector;
        }

        #endregion

        #region Propiedades primitivas
    
        /// <summary>
        /// No hay documentación de metadatos disponible.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Int32 ID_Sector
        {
            get
            {
                return _ID_Sector;
            }
            set
            {
                if (_ID_Sector != value)
                {
                    OnID_SectorChanging(value);
                    ReportPropertyChanging("ID_Sector");
                    _ID_Sector = StructuralObject.SetValidValue(value);
                    ReportPropertyChanged("ID_Sector");
                    OnID_SectorChanged();
                }
            }
        }
        private global::System.Int32 _ID_Sector;
        partial void OnID_SectorChanging(global::System.Int32 value);
        partial void OnID_SectorChanged();
    
        /// <summary>
        /// No hay documentación de metadatos disponible.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String nombre
        {
            get
            {
                return _nombre;
            }
            set
            {
                OnnombreChanging(value);
                ReportPropertyChanging("nombre");
                _nombre = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("nombre");
                OnnombreChanged();
            }
        }
        private global::System.String _nombre;
        partial void OnnombreChanging(global::System.String value);
        partial void OnnombreChanged();

        #endregion

    
    }

    #endregion

    
}
