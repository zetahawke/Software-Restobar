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
    public partial class CategoEntities : ObjectContext
    {
        #region Constructores
    
        /// <summary>
        /// Inicializa un nuevo objeto CategoEntities usando la cadena de conexión encontrada en la sección 'CategoEntities' del archivo de configuración de la aplicación.
        /// </summary>
        public CategoEntities() : base("name=CategoEntities", "CategoEntities")
        {
            this.ContextOptions.LazyLoadingEnabled = true;
            OnContextCreated();
        }
    
        /// <summary>
        /// Inicializar un nuevo objeto CategoEntities.
        /// </summary>
        public CategoEntities(string connectionString) : base(connectionString, "CategoEntities")
        {
            this.ContextOptions.LazyLoadingEnabled = true;
            OnContextCreated();
        }
    
        /// <summary>
        /// Inicializar un nuevo objeto CategoEntities.
        /// </summary>
        public CategoEntities(EntityConnection connection) : base(connection, "CategoEntities")
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
        public ObjectSet<Categorias> Categorias
        {
            get
            {
                if ((_Categorias == null))
                {
                    _Categorias = base.CreateObjectSet<Categorias>("Categorias");
                }
                return _Categorias;
            }
        }
        private ObjectSet<Categorias> _Categorias;

        #endregion

        #region Métodos AddTo
    
        /// <summary>
        /// Método desusado para agregar un nuevo objeto al EntitySet Categorias. Considere la posibilidad de usar el método .Add de la propiedad ObjectSet&lt;T&gt; asociada.
        /// </summary>
        public void AddToCategorias(Categorias categorias)
        {
            base.AddObject("Categorias", categorias);
        }

        #endregion

    }

    #endregion

    #region Entidades
    
    /// <summary>
    /// No hay documentación de metadatos disponible.
    /// </summary>
    [EdmEntityTypeAttribute(NamespaceName="CategoModel", Name="Categorias")]
    [Serializable()]
    [DataContractAttribute(IsReference=true)]
    public partial class Categorias : EntityObject
    {
        #region Método de generador
    
        /// <summary>
        /// Crear un nuevo objeto Categorias.
        /// </summary>
        /// <param name="iD_Categoria">Valor inicial de la propiedad ID_Categoria.</param>
        public static Categorias CreateCategorias(global::System.Int32 iD_Categoria)
        {
            Categorias categorias = new Categorias();
            categorias.ID_Categoria = iD_Categoria;
            return categorias;
        }

        #endregion

        #region Propiedades primitivas
    
        /// <summary>
        /// No hay documentación de metadatos disponible.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Int32 ID_Categoria
        {
            get
            {
                return _ID_Categoria;
            }
            set
            {
                if (_ID_Categoria != value)
                {
                    OnID_CategoriaChanging(value);
                    ReportPropertyChanging("ID_Categoria");
                    _ID_Categoria = StructuralObject.SetValidValue(value);
                    ReportPropertyChanged("ID_Categoria");
                    OnID_CategoriaChanged();
                }
            }
        }
        private global::System.Int32 _ID_Categoria;
        partial void OnID_CategoriaChanging(global::System.Int32 value);
        partial void OnID_CategoriaChanged();
    
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