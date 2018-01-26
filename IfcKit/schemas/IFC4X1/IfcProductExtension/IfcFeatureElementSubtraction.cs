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
using BuildingSmart.IFC.IfcRepresentationResource;
using BuildingSmart.IFC.IfcSharedBldgElements;
using BuildingSmart.IFC.IfcStructuralAnalysisDomain;
using BuildingSmart.IFC.IfcUtilityResource;

namespace BuildingSmart.IFC.IfcProductExtension
{
	[Guid("c881faa0-78d9-40af-a83e-a4924a575869")]
	public abstract partial class IfcFeatureElementSubtraction : IfcFeatureElement
	{
		[InverseProperty("RelatedOpeningElement")] 
		IfcRelVoidsElement _VoidsElements;
	
	
		public IfcFeatureElementSubtraction()
		{
		}
	
		public IfcFeatureElementSubtraction(IfcGloballyUniqueId __GlobalId, IfcOwnerHistory __OwnerHistory, IfcLabel? __Name, IfcText? __Description, IfcLabel? __ObjectType, IfcObjectPlacement __ObjectPlacement, IfcProductRepresentation __Representation, IfcIdentifier? __Tag)
			: base(__GlobalId, __OwnerHistory, __Name, __Description, __ObjectType, __ObjectPlacement, __Representation, __Tag)
		{
		}
	
		[Description("Reference to the Voids Relationship that uses this Opening Element to create a vo" +
	    "id within an Element. The Opening Element can only be used to create a single vo" +
	    "id within a single Element.\r\n")]
		public IfcRelVoidsElement VoidsElements { get { return this._VoidsElements; } set { this._VoidsElements = value;} }
	
	
	}
	
}
