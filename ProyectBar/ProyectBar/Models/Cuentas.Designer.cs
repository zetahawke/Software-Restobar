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
    public partial class CuentasEntities : ObjectContext
    {
        #region Constructores
    
        /// <summary>
        /// Inicializa un nuevo objeto CuentasEntities usando la cadena de conexión encontrada en la sección 'CuentasEntities' del archivo de configuración de la aplicación.
        /// </summary>
        public CuentasEntities() : base("name=CuentasEntities", "CuentasEntities")
        {
            this.ContextOptions.LazyLoadingEnabled = true;
            OnContextCreated();
        }
    
        /// <summary>
        /// Inicializar un nuevo objeto CuentasEntities.
        /// </summary>
        public CuentasEntities(string connectionString) : base(connectionString, "CuentasEntities")
        {
            this.ContextOptions.LazyLoadingEnabled = true;
            OnContextCreated();
        }
    
        /// <summary>
        /// Inicializar un nuevo objeto CuentasEntities.
        /// </summary>
        public CuentasEntities(EntityConnection connection) : base(connection, "CuentasEntities")
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
        public ObjectSet<Cuenta> Cuenta
        {
            get
            {
                if ((_Cuenta == null))
                {
                    _Cuenta = base.CreateObjectSet<Cuenta>("Cuenta");
                }
                return _Cuenta;
            }
        }
        private ObjectSet<Cuenta> _Cuenta;

        #endregion

        #region Métodos AddTo
    
        /// <summary>
        /// Método desusado para agregar un nuevo objeto al EntitySet Cuenta. Considere la posibilidad de usar el método .Add de la propiedad ObjectSet&lt;T&gt; asociada.
        /// </summary>
        public void AddToCuenta(Cuenta cuenta)
        {
            base.AddObject("Cuenta", cuenta);
        }

        #endregion

    }

    #endregion

    #region Entidades
    
    /// <summary>
    /// No hay documentación de metadatos disponible.
    /// </summary>
    [EdmEntityTypeAttribute(NamespaceName="cuentasModel", Name="Cuenta")]
    [Serializable()]
    [DataContractAttribute(IsReference=true)]
    public partial class Cuenta : EntityObject
    {
        #region Método de generador
    
        /// <summary>
        /// Crear un nuevo objeto Cuenta.
        /// </summary>
        /// <param name="iD_Cuenta">Valor inicial de la propiedad ID_Cuenta.</param>
        public static Cuenta CreateCuenta(global::System.Int32 iD_Cuenta)
        {
            Cuenta cuenta = new Cuenta();
            cuenta.ID_Cuenta = iD_Cuenta;
            return cuenta;
        }

        #endregion

        #region Propiedades primitivas
    
        /// <summary>
        /// No hay documentación de metadatos disponible.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Int32 ID_Cuenta
        {
            get
            {
                return _ID_Cuenta;
            }
            set
            {
                if (_ID_Cuenta != value)
                {
                    OnID_CuentaChanging(value);
                    ReportPropertyChanging("ID_Cuenta");
                    _ID_Cuenta = StructuralObject.SetValidValue(value);
                    ReportPropertyChanged("ID_Cuenta");
                    OnID_CuentaChanged();
                }
            }
        }
        private global::System.Int32 _ID_Cuenta;
        partial void OnID_CuentaChanging(global::System.Int32 value);
        partial void OnID_CuentaChanged();
    
        /// <summary>
        /// No hay documentación de metadatos disponible.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<global::System.Int32> Mesa
        {
            get
            {
                return _Mesa;
            }
            set
            {
                OnMesaChanging(value);
                ReportPropertyChanging("Mesa");
                _Mesa = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("Mesa");
                OnMesaChanged();
            }
        }
        private Nullable<global::System.Int32> _Mesa;
        partial void OnMesaChanging(Nullable<global::System.Int32> value);
        partial void OnMesaChanged();
    
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
