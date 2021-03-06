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
    public partial class CatEntities : ObjectContext
    {
        #region Constructores
    
        /// <summary>
        /// Inicializa un nuevo objeto CatEntities usando la cadena de conexión encontrada en la sección 'CatEntities' del archivo de configuración de la aplicación.
        /// </summary>
        public CatEntities() : base("name=CatEntities", "CatEntities")
        {
            this.ContextOptions.LazyLoadingEnabled = true;
            OnContextCreated();
        }
    
        /// <summary>
        /// Inicializar un nuevo objeto CatEntities.
        /// </summary>
        public CatEntities(string connectionString) : base(connectionString, "CatEntities")
        {
            this.ContextOptions.LazyLoadingEnabled = true;
            OnContextCreated();
        }
    
        /// <summary>
        /// Inicializar un nuevo objeto CatEntities.
        /// </summary>
        public CatEntities(EntityConnection connection) : base(connection, "CatEntities")
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
        public ObjectSet<Cate> Cate
        {
            get
            {
                if ((_Cate == null))
                {
                    _Cate = base.CreateObjectSet<Cate>("Cate");
                }
                return _Cate;
            }
        }
        private ObjectSet<Cate> _Cate;

        #endregion

        #region Métodos AddTo
    
        /// <summary>
        /// Método desusado para agregar un nuevo objeto al EntitySet Cate. Considere la posibilidad de usar el método .Add de la propiedad ObjectSet&lt;T&gt; asociada.
        /// </summary>
        public void AddToCate(Cate cate)
        {
            base.AddObject("Cate", cate);
        }

        #endregion

    }

    #endregion

    #region Entidades
    
    /// <summary>
    /// No hay documentación de metadatos disponible.
    /// </summary>
    [EdmEntityTypeAttribute(NamespaceName="catModel", Name="Cate")]
    [Serializable()]
    [DataContractAttribute(IsReference=true)]
    public partial class Cate : EntityObject
    {
        #region Método de generador
    
        /// <summary>
        /// Crear un nuevo objeto Cate.
        /// </summary>
        /// <param name="iD_Cate">Valor inicial de la propiedad ID_Cate.</param>
        public static Cate CreateCate(global::System.Int32 iD_Cate)
        {
            Cate cate = new Cate();
            cate.ID_Cate = iD_Cate;
            return cate;
        }

        #endregion

        #region Propiedades primitivas
    
        /// <summary>
        /// No hay documentación de metadatos disponible.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Int32 ID_Cate
        {
            get
            {
                return _ID_Cate;
            }
            set
            {
                if (_ID_Cate != value)
                {
                    OnID_CateChanging(value);
                    ReportPropertyChanging("ID_Cate");
                    _ID_Cate = StructuralObject.SetValidValue(value);
                    ReportPropertyChanged("ID_Cate");
                    OnID_CateChanged();
                }
            }
        }
        private global::System.Int32 _ID_Cate;
        partial void OnID_CateChanging(global::System.Int32 value);
        partial void OnID_CateChanged();
    
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
