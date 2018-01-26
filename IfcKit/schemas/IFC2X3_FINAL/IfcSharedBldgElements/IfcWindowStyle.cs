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

namespace BuildingSmart.IFC.IfcSharedBldgElements
{
	[Guid("0e385d33-21c0-4373-baf9-00d7ae7032c2")]
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
		[Required()]
		Boolean _ParameterTakesPrecedence;
	
		[DataMember(Order=3)] 
		[Required()]
		Boolean _Sizeable;
	
	
		public IfcWindowStyle()
		{
		}
	
		public IfcWindowStyle(IfcGloballyUniqueId __GlobalId, IfcOwnerHistory __OwnerHistory, IfcLabel? __Name, IfcText? __Description, IfcLabel? __ApplicableOccurrence, IfcPropertySetDefinition[] __HasPropertySets, IfcRepresentationMap[] __RepresentationMaps, IfcLabel? __Tag, IfcWindowStyleConstructionEnum __ConstructionType, IfcWindowStyleOperationEnum __OperationType, Boolean __ParameterTakesPrecedence, Boolean __Sizeable)
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
		public Boolean ParameterTakesPrecedence { get { return this._ParameterTakesPrecedence; } set { this._ParameterTakesPrecedence = value;} }
	
		[Description("The Boolean indicates, whether the attached ShapeStyle can be sized (using scale " +
	    "factor of transformation), or not (FALSE). If not, the ShapeStyle should be inse" +
	    "rted by the IfcWindow (using IfcMappedItem) with the scale factor = 1.")]
		public Boolean Sizeable { get { return this._Sizeable; } set { this._Sizeable = value;} }
	
	
	}
	
}
