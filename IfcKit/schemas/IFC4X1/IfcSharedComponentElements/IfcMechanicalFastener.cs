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

using BuildingSmart.IFC.IfcGeometricConstraintResource;
using BuildingSmart.IFC.IfcKernel;
using BuildingSmart.IFC.IfcMeasureResource;
using BuildingSmart.IFC.IfcProductExtension;
using BuildingSmart.IFC.IfcRepresentationResource;
using BuildingSmart.IFC.IfcSharedBldgElements;
using BuildingSmart.IFC.IfcStructuralAnalysisDomain;
using BuildingSmart.IFC.IfcUtilityResource;

namespace BuildingSmart.IFC.IfcSharedComponentElements
{
	[Guid("3f389407-9e81-4218-8102-56eb71651146")]
	public partial class IfcMechanicalFastener : IfcElementComponent
	{
		[DataMember(Order=0)] 
		[XmlAttribute]
		IfcPositiveLengthMeasure? _NominalDiameter;
	
		[DataMember(Order=1)] 
		[XmlAttribute]
		IfcPositiveLengthMeasure? _NominalLength;
	
		[DataMember(Order=2)] 
		[XmlAttribute]
		IfcMechanicalFastenerTypeEnum? _PredefinedType;
	
	
		public IfcMechanicalFastener()
		{
		}
	
		public IfcMechanicalFastener(IfcGloballyUniqueId __GlobalId, IfcOwnerHistory __OwnerHistory, IfcLabel? __Name, IfcText? __Description, IfcLabel? __ObjectType, IfcObjectPlacement __ObjectPlacement, IfcProductRepresentation __Representation, IfcIdentifier? __Tag, IfcPositiveLengthMeasure? __NominalDiameter, IfcPositiveLengthMeasure? __NominalLength, IfcMechanicalFastenerTypeEnum? __PredefinedType)
			: base(__GlobalId, __OwnerHistory, __Name, __Description, __ObjectType, __ObjectPlacement, __Representation, __Tag)
		{
			this._NominalDiameter = __NominalDiameter;
			this._NominalLength = __NominalLength;
			this._PredefinedType = __PredefinedType;
		}
	
		[Description("The nominal diameter describing the cross-section size of the fastener type.\r\n\r\n<" +
	    "blockquote class=\"change-ifc2x4\">\r\nIFC4 CHANGE&nbsp; Deprecated; the respective " +
	    "attribute of <em>IfcMechanicalFastenerType</em> should be used instead.\r\n</block" +
	    "quote>")]
		public IfcPositiveLengthMeasure? NominalDiameter { get { return this._NominalDiameter; } set { this._NominalDiameter = value;} }
	
		[Description("The nominal length describing the longitudinal dimensions of the fastener type.\r\n" +
	    "\r\n<blockquote class=\"change-ifc2x4\">\r\nIFC4 CHANGE&nbsp; Deprecated; the respecti" +
	    "ve attribute of <em>IfcMechanicalFastenerType</em> should be used instead.\r\n</bl" +
	    "ockquote>")]
		public IfcPositiveLengthMeasure? NominalLength { get { return this._NominalLength; } set { this._NominalLength = value;} }
	
		[Description("Subtype of mechanical fastener")]
		public IfcMechanicalFastenerTypeEnum? PredefinedType { get { return this._PredefinedType; } set { this._PredefinedType = value;} }
	
	
	}
	
}
