// This file was automatically generated from IFCDOC at www.buildingsmart-tech.org.
// IFC content is copyright (C) 1996-2018 BuildingSMART International Ltd.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Xml.Serialization;

using BuildingSmart.IFC.IfcGeometryResource;
using BuildingSmart.IFC.IfcKernel;
using BuildingSmart.IFC.IfcMeasureResource;
using BuildingSmart.IFC.IfcUtilityResource;

namespace BuildingSmart.IFC.IfcArchitectureDomain
{
	[Guid("db2eb89c-05a5-4166-8f16-149189ed3bfa")]
	public partial class IfcWindowStyle : IfcTypeProduct
	{
		[DataMember(Order=0)] 
		[XmlAttribute]
		[Required()]
		IfcWindowStyleConstructionEnum _ConstructionType;
	
		[DataMember(Order=1)] 
		[XmlAttribute]
		[Required()]
		IfcWindowStyleOperationEnum _OperationType;
	
		[DataMember(Order=2)] 
		[XmlAttribute]
		[Required()]
		IfcBoolean _ParameterTakesPrecedence;
	
		[DataMember(Order=3)] 
		[XmlAttribute]
		[Required()]
		IfcBoolean _Sizeable;
	
	
		public IfcWindowStyle()
		{
		}
	
		public IfcWindowStyle(IfcGloballyUniqueId __GlobalId, IfcOwnerHistory __OwnerHistory, IfcLabel? __Name, IfcText? __Description, IfcIdentifier? __ApplicableOccurrence, IfcPropertySetDefinition[] __HasPropertySets, IfcRepresentationMap[] __RepresentationMaps, IfcLabel? __Tag, IfcWindowStyleConstructionEnum __ConstructionType, IfcWindowStyleOperationEnum __OperationType, IfcBoolean __ParameterTakesPrecedence, IfcBoolean __Sizeable)
			: base(__GlobalId, __OwnerHistory, __Name, __Description, __ApplicableOccurrence, __HasPropertySets, __RepresentationMaps, __Tag)
		{
			this._ConstructionType = __ConstructionType;
			this._OperationType = __OperationType;
			this._ParameterTakesPrecedence = __ParameterTakesPrecedence;
			this._Sizeable = __Sizeable;
		}
	
		[Description("Type defining the basic construction and material type of the window.")]
		public IfcWindowStyleConstructionEnum ConstructionType { get { return this._ConstructionType; } set { this._ConstructionType = value;} }
	
		[Description("Type defining the general layout and operation of the window style. ")]
		public IfcWindowStyleOperationEnum OperationType { get { return this._OperationType; } set { this._OperationType = value;} }
	
		[Description(@"The Boolean value reflects, whether the parameter given in the attached lining and panel properties exactly define the geometry (TRUE), or whether the attached style shape take precedence (FALSE). In the last case the parameter have only informative value.")]
		public IfcBoolean ParameterTakesPrecedence { get { return this._ParameterTakesPrecedence; } set { this._ParameterTakesPrecedence = value;} }
	
		[Description("The Boolean indicates, whether the attached ShapeStyle can be sized (using scale " +
	    "factor of transformation), or not (FALSE). If not, the ShapeStyle should be inse" +
	    "rted by the IfcWindow (using IfcMappedItem) with the scale factor = 1.")]
		public IfcBoolean Sizeable { get { return this._Sizeable; } set { this._Sizeable = value;} }
	
	
	}
	
}
