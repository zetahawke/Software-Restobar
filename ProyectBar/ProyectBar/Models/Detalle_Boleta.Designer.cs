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
    public partial class Detalle_BoletaEntities : ObjectContext
    {
        #region Constructores
    
        /// <summary>
        /// Inicializa un nuevo objeto Detalle_BoletaEntities usando la cadena de conexión encontrada en la sección 'Detalle_BoletaEntities' del archivo de configuración de la aplicación.
        /// </summary>
        public Detalle_BoletaEntities() : base("name=Detalle_BoletaEntities", "Detalle_BoletaEntities")
        {
            this.ContextOptions.LazyLoadingEnabled = true;
            OnContextCreated();
        }
    
        /// <summary>
        /// Inicializar un nuevo objeto Detalle_BoletaEntities.
        /// </summary>
        public Detalle_BoletaEntities(string connectionString) : base(connectionString, "Detalle_BoletaEntities")
        {
            this.ContextOptions.LazyLoadingEnabled = true;
            OnContextCreated();
        }
    
        /// <summary>
        /// Inicializar un nuevo objeto Detalle_BoletaEntities.
        /// </summary>
        public Detalle_BoletaEntities(EntityConnection connection) : base(connection, "Detalle_BoletaEntities")
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
        public ObjectSet<DetalleBoleta> DetalleBoleta
        {
            get
            {
                if ((_DetalleBoleta == null))
                {
                    _DetalleBoleta = base.CreateObjectSet<DetalleBoleta>("DetalleBoleta");
                }
                return _DetalleBoleta;
            }
        }
        private ObjectSet<DetalleBoleta> _DetalleBoleta;

        #endregion

        #region Métodos AddTo
    
        /// <summary>
        /// Método desusado para agregar un nuevo objeto al EntitySet DetalleBoleta. Considere la posibilidad de usar el método .Add de la propiedad ObjectSet&lt;T&gt; asociada.
        /// </summary>
        public void AddToDetalleBoleta(DetalleBoleta detalleBoleta)
        {
            base.AddObject("DetalleBoleta", detalleBoleta);
        }

        #endregion

    }

    #endregion

    #region Entidades
    
    /// <summary>
    /// No hay documentación de metadatos disponible.
    /// </summary>
    [EdmEntityTypeAttribute(NamespaceName="DetalleBoletaModel", Name="DetalleBoleta")]
    [Serializable()]
    [DataContractAttribute(IsReference=true)]
    public partial class DetalleBoleta : EntityObject
    {
        #region Método de generador
    
        /// <summary>
        /// Crear un nuevo objeto DetalleBoleta.
        /// </summary>
        /// <param name="iD_Detalle">Valor inicial de la propiedad ID_Detalle.</param>
        public static DetalleBoleta CreateDetalleBoleta(global::System.Int32 iD_Detalle)
        {
            DetalleBoleta detalleBoleta = new DetalleBoleta();
            detalleBoleta.ID_Detalle = iD_Detalle;
            return detalleBoleta;
        }

        #endregion

        #region Propiedades primitivas
    
        /// <summary>
        /// No hay documentación de metadatos disponible.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Int32 ID_Detalle
        {
            get
            {
                return _ID_Detalle;
            }
            set
            {
                if (_ID_Detalle != value)
                {
                    OnID_DetalleChanging(value);
                    ReportPropertyChanging("ID_Detalle");
                    _ID_Detalle = StructuralObject.SetValidValue(value);
                    ReportPropertyChanged("ID_Detalle");
                    OnID_DetalleChanged();
                }
            }
        }
        private global::System.Int32 _ID_Detalle;
        partial void OnID_DetalleChanging(global::System.Int32 value);
        partial void OnID_DetalleChanged();
    
        /// <summary>
        /// No hay documentación de metadatos disponible.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<global::System.Int32> total
        {
            get
            {
                return _total;
            }
            set
            {
                OntotalChanging(value);
                ReportPropertyChanging("total");
                _total = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("total");
                OntotalChanged();
            }
        }
        private Nullable<global::System.Int32> _total;
        partial void OntotalChanging(Nullable<global::System.Int32> value);
        partial void OntotalChanged();
    
        /// <summary>
        /// No hay documentación de metadatos disponible.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<global::System.Int32> Cuenta
        {
            get
            {
                return _Cuenta;
            }
            set
            {
                OnCuentaChanging(value);
                ReportPropertyChanging("Cuenta");
                _Cuenta = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("Cuenta");
                OnCuentaChanged();
            }
        }
        private Nullable<global::System.Int32> _Cuenta;
        partial void OnCuentaChanging(Nullable<global::System.Int32> value);
        partial void OnCuentaChanged();
    
        /// <summary>
        /// No hay documentación de metadatos disponible.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String descripcion
        {
            get
            {
                return _descripcion;
            }
            set
            {
                OndescripcionChanging(value);
                ReportPropertyChanging("descripcion");
                _descripcion = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("descripcion");
                OndescripcionChanged();
            }
        }
        private global::System.String _descripcion;
        partial void OndescripcionChanging(global::System.String value);
        partial void OndescripcionChanged();
    
        /// <summary>
        /// No hay documentación de metadatos disponible.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<global::System.Int32> Boleta
        {
            get
            {
                return _Boleta;
            }
            set
            {
                OnBoletaChanging(value);
                ReportPropertyChanging("Boleta");
                _Boleta = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("Boleta");
                OnBoletaChanged();
            }
        }
        private Nullable<global::System.Int32> _Boleta;
        partial void OnBoletaChanging(Nullable<global::System.Int32> value);
        partial void OnBoletaChanged();

        #endregion

    
    }

    #endregion

    
}
