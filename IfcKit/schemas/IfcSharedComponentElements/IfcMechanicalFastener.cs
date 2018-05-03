// This file may be edited manually or auto-generated using IfcKit at www.buildingsmart-tech.org.
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
	public partial class IfcMechanicalFastener : IfcElementComponent
	{
		[DataMember(Order = 0)] 
		[XmlAttribute]
		[Description("The nominal diameter describing the cross-section size of the fastener type.  <blockquote class=\"deprecated\">Deprecated in IFC4</blockquote>")]
		public IfcPositiveLengthMeasure? NominalDiameter { get; set; }
	
		[DataMember(Order = 1)] 
		[XmlAttribute]
		[Description("The nominal length describing the longitudinal dimensions of the fastener type.  <blockquote class=\"deprecated\">Deprecated in IFC4</blockquote>")]
		public IfcPositiveLengthMeasure? NominalLength { get; set; }
	
		[DataMember(Order = 2)] 
		[XmlAttribute]
		[Description("Subtype of mechanical fastener")]
		public IfcMechanicalFastenerTypeEnum? PredefinedType { get; set; }
	
	
		public IfcMechanicalFastener(IfcGloballyUniqueId __GlobalId, IfcOwnerHistory __OwnerHistory, IfcLabel? __Name, IfcText? __Description, IfcLabel? __ObjectType, IfcObjectPlacement __ObjectPlacement, IfcProductRepresentation __Representation, IfcIdentifier? __Tag, IfcPositiveLengthMeasure? __NominalDiameter, IfcPositiveLengthMeasure? __NominalLength, IfcMechanicalFastenerTypeEnum? __PredefinedType)
			: base(__GlobalId, __OwnerHistory, __Name, __Description, __ObjectType, __ObjectPlacement, __Representation, __Tag)
		{
			this.NominalDiameter = __NominalDiameter;
			this.NominalLength = __NominalLength;
			this.PredefinedType = __PredefinedType;
		}
	
	
	}
	
}
