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
    public partial class PedidoEntities : ObjectContext
    {
        #region Constructores
    
        /// <summary>
        /// Inicializa un nuevo objeto PedidoEntities usando la cadena de conexión encontrada en la sección 'PedidoEntities' del archivo de configuración de la aplicación.
        /// </summary>
        public PedidoEntities() : base("name=PedidoEntities", "PedidoEntities")
        {
            this.ContextOptions.LazyLoadingEnabled = true;
            OnContextCreated();
        }
    
        /// <summary>
        /// Inicializar un nuevo objeto PedidoEntities.
        /// </summary>
        public PedidoEntities(string connectionString) : base(connectionString, "PedidoEntities")
        {
            this.ContextOptions.LazyLoadingEnabled = true;
            OnContextCreated();
        }
    
        /// <summary>
        /// Inicializar un nuevo objeto PedidoEntities.
        /// </summary>
        public PedidoEntities(EntityConnection connection) : base(connection, "PedidoEntities")
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
        public ObjectSet<Pedido> Pedido
        {
            get
            {
                if ((_Pedido == null))
                {
                    _Pedido = base.CreateObjectSet<Pedido>("Pedido");
                }
                return _Pedido;
            }
        }
        private ObjectSet<Pedido> _Pedido;

        #endregion

        #region Métodos AddTo
    
        /// <summary>
        /// Método desusado para agregar un nuevo objeto al EntitySet Pedido. Considere la posibilidad de usar el método .Add de la propiedad ObjectSet&lt;T&gt; asociada.
        /// </summary>
        public void AddToPedido(Pedido pedido)
        {
            base.AddObject("Pedido", pedido);
        }

        #endregion

    }

    #endregion

    #region Entidades
    
    /// <summary>
    /// No hay documentación de metadatos disponible.
    /// </summary>
    [EdmEntityTypeAttribute(NamespaceName="ProyectoBarModel", Name="Pedido")]
    [Serializable()]
    [DataContractAttribute(IsReference=true)]
    public partial class Pedido : EntityObject
    {
        #region Método de generador
    
        /// <summary>
        /// Crear un nuevo objeto Pedido.
        /// </summary>
        /// <param name="iD_Pedido">Valor inicial de la propiedad ID_Pedido.</param>
        public static Pedido CreatePedido(global::System.Int32 iD_Pedido)
        {
            Pedido pedido = new Pedido();
            pedido.ID_Pedido = iD_Pedido;
            return pedido;
        }

        #endregion

        #region Propiedades primitivas
    
        /// <summary>
        /// No hay documentación de metadatos disponible.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Int32 ID_Pedido
        {
            get
            {
                return _ID_Pedido;
            }
            set
            {
                if (_ID_Pedido != value)
                {
                    OnID_PedidoChanging(value);
                    ReportPropertyChanging("ID_Pedido");
                    _ID_Pedido = StructuralObject.SetValidValue(value);
                    ReportPropertyChanged("ID_Pedido");
                    OnID_PedidoChanged();
                }
            }
        }
        private global::System.Int32 _ID_Pedido;
        partial void OnID_PedidoChanging(global::System.Int32 value);
        partial void OnID_PedidoChanged();
    
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
        public global::System.String Garzon
        {
            get
            {
                return _Garzon;
            }
            set
            {
                OnGarzonChanging(value);
                ReportPropertyChanging("Garzon");
                _Garzon = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("Garzon");
                OnGarzonChanged();
            }
        }
        private global::System.String _Garzon;
        partial void OnGarzonChanging(global::System.String value);
        partial void OnGarzonChanged();

        #endregion

    
    }

    #endregion

    
}