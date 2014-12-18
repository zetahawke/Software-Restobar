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
    public partial class Medio_PagoEntities : ObjectContext
    {
        #region Constructores
    
        /// <summary>
        /// Inicializa un nuevo objeto Medio_PagoEntities usando la cadena de conexión encontrada en la sección 'Medio_PagoEntities' del archivo de configuración de la aplicación.
        /// </summary>
        public Medio_PagoEntities() : base("name=Medio_PagoEntities", "Medio_PagoEntities")
        {
            this.ContextOptions.LazyLoadingEnabled = true;
            OnContextCreated();
        }
    
        /// <summary>
        /// Inicializar un nuevo objeto Medio_PagoEntities.
        /// </summary>
        public Medio_PagoEntities(string connectionString) : base(connectionString, "Medio_PagoEntities")
        {
            this.ContextOptions.LazyLoadingEnabled = true;
            OnContextCreated();
        }
    
        /// <summary>
        /// Inicializar un nuevo objeto Medio_PagoEntities.
        /// </summary>
        public Medio_PagoEntities(EntityConnection connection) : base(connection, "Medio_PagoEntities")
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
        public ObjectSet<Medio_Pago> Medio_Pago
        {
            get
            {
                if ((_Medio_Pago == null))
                {
                    _Medio_Pago = base.CreateObjectSet<Medio_Pago>("Medio_Pago");
                }
                return _Medio_Pago;
            }
        }
        private ObjectSet<Medio_Pago> _Medio_Pago;

        #endregion

        #region Métodos AddTo
    
        /// <summary>
        /// Método desusado para agregar un nuevo objeto al EntitySet Medio_Pago. Considere la posibilidad de usar el método .Add de la propiedad ObjectSet&lt;T&gt; asociada.
        /// </summary>
        public void AddToMedio_Pago(Medio_Pago medio_Pago)
        {
            base.AddObject("Medio_Pago", medio_Pago);
        }

        #endregion

    }

    #endregion

    #region Entidades
    
    /// <summary>
    /// No hay documentación de metadatos disponible.
    /// </summary>
    [EdmEntityTypeAttribute(NamespaceName="Medio_PagoModel", Name="Medio_Pago")]
    [Serializable()]
    [DataContractAttribute(IsReference=true)]
    public partial class Medio_Pago : EntityObject
    {
        #region Método de generador
    
        /// <summary>
        /// Crear un nuevo objeto Medio_Pago.
        /// </summary>
        /// <param name="iD_Medio">Valor inicial de la propiedad ID_Medio.</param>
        public static Medio_Pago CreateMedio_Pago(global::System.Int32 iD_Medio)
        {
            Medio_Pago medio_Pago = new Medio_Pago();
            medio_Pago.ID_Medio = iD_Medio;
            return medio_Pago;
        }

        #endregion

        #region Propiedades primitivas
    
        /// <summary>
        /// No hay documentación de metadatos disponible.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Int32 ID_Medio
        {
            get
            {
                return _ID_Medio;
            }
            set
            {
                if (_ID_Medio != value)
                {
                    OnID_MedioChanging(value);
                    ReportPropertyChanging("ID_Medio");
                    _ID_Medio = StructuralObject.SetValidValue(value);
                    ReportPropertyChanged("ID_Medio");
                    OnID_MedioChanged();
                }
            }
        }
        private global::System.Int32 _ID_Medio;
        partial void OnID_MedioChanging(global::System.Int32 value);
        partial void OnID_MedioChanged();
    
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

        #endregion

    
    }

    #endregion

    
}