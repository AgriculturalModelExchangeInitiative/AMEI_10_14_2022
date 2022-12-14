//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré par un outil.
//     Version du runtime :4.0.30319.42000
//
//     Les modifications apportées à ce fichier peuvent provoquer un comportement incorrect et seront perdues si
//     le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

/// 
/// This class was created from file C:\Users\mancealo\Documents\Sirius Quality\branches\TestSoil\Code\SiriusQuality-SoilTemperatureDomainClasses\XML\UNIMI.SoilT.Interfaces_States.xml
/// The tool used was: DCC - Domain Class Coder, http://components.biomamodelling.org/, DCC
/// 
/// Loic Manceau
/// loic.manceau@inra.fr
/// INRA
/// 
/// 
/// 5/8/2017 12:24:48 PM
/// 
namespace INRA.SiriusQualitySoilT.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Reflection;
    using CRA.ModelLayer.Core;
    using CRA.ModelLayer.ParametersManagement;
    
    
    /// <summary>States Domain class contains the accessors to values</summary>
    [Serializable()]
    public class States : ICloneable, IDomainClass
    {
        
        #region Private fields
        private double _maxTSoil;
        
        private double _minTSoil;
        
        private double[] _hourlySoilT = new double[24];
        #endregion
        
        #region Private field for properties
        private ParametersIO _parametersIO;
        #endregion
        
        #region Constructor
        /// <summary>No parameters constructor</summary>
        public States()
        {
            _parametersIO = new ParametersIO(this);
        }

        public States(States toCopy)
        {
            _parametersIO = new ParametersIO(this);
            _maxTSoil = toCopy._maxTSoil;
            _minTSoil = toCopy._minTSoil;

            for (int i = 0; i < 24; i++)
            {
                _hourlySoilT[i] = toCopy._hourlySoilT[i];
            }
        }

        #endregion
        
        #region Public properties
        /// <summary>Maximum Soil Temperature</summary>
        public double maxTSoil
        {
            get
            {
                return this._maxTSoil;
            }
            set
            {
                this._maxTSoil = value;
            }
        }
        
        /// <summary>Minimum Soil Temperature</summary>
        public double minTSoil
        {
            get
            {
                return this._minTSoil;
            }
            set
            {
                this._minTSoil = value;
            }
        }
        
        /// <summary>Hourly Soil Temperature</summary>
        public double[] hourlySoilT
        {
            get
            {
                return this._hourlySoilT;
            }
            set
            {
                this._hourlySoilT = value;
            }
        }
        #endregion
        
        #region IDomainClass members
        /// <summary>Domain Class description</summary>
        public virtual  string Description
        {
            get
            {
                return "State variables of SoilT";
            }
        }
        
        /// <summary>Domain Class URL</summary>
        public virtual  string URL
        {
            get
            {
                return "http://";
            }
        }
        
        /// <summary>Domain Class Properties</summary>
        public virtual IDictionary<string, PropertyInfo> PropertiesDescription
        {
            get
            {
                return _parametersIO.GetCachedProperties(typeof(IDomainClass));
            }
        }
        #endregion
        
        /// <summary>Clears the values of the properties of the domain class by using the default value for the type of each property (e.g '0' for numbers, 'the empty string' for strings, etc.)</summary>
        public virtual Boolean ClearValues()
        {
            _maxTSoil = default(System.Double);
            _minTSoil = default(System.Double);
            _hourlySoilT = new double[24];
            // Returns true if everything is ok
            return true;
        }
        
        #region Clone
        /// <summary>Implement ICloneable.Clone()</summary>
        public virtual Object Clone()
        {
            // Shallow copy by default
            IDomainClass myclass = (IDomainClass) this.MemberwiseClone();
            _parametersIO.PopulateClonedCopy(myclass);
            return myclass;
        }
        #endregion
    }
}
