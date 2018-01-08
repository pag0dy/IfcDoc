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

using BuildingSmart.IFC.IfcActorResource;
using BuildingSmart.IFC.IfcConstraintResource;
using BuildingSmart.IFC.IfcExternalReferenceResource;
using BuildingSmart.IFC.IfcGeometricConstraintResource;
using BuildingSmart.IFC.IfcGeometricModelResource;
using BuildingSmart.IFC.IfcGeometryResource;
using BuildingSmart.IFC.IfcMeasureResource;
using BuildingSmart.IFC.IfcPresentationAppearanceResource;
using BuildingSmart.IFC.IfcPropertyResource;
using BuildingSmart.IFC.IfcRepresentationResource;
using BuildingSmart.IFC.IfcUtilityResource;

namespace BuildingSmart.IFC.IfcKernel
{
	[Guid("c0bc28d6-264e-4ba4-b40b-911c7ee80584")]
	public partial class IfcRelDefinesByProperties : IfcRelDefines
	{
		[DataMember(Order=0)] 
		[Required()]
		IfcPropertySetDefinition _RelatingPropertyDefinition;
	
	
		[Description("Reference to the property set definition for that object or set of objects.\r\n")]
		public IfcPropertySetDefinition RelatingPropertyDefinition { get { return this._RelatingPropertyDefinition; } set { this._RelatingPropertyDefinition = value;} }
	
	
	}
	
}
