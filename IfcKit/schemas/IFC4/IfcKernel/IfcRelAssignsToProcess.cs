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
	[Guid("61204dbc-e9f6-40ab-aaaf-0c7f854fa124")]
	public partial class IfcRelAssignsToProcess : IfcRelAssigns
	{
		[DataMember(Order=0)] 
		[Required()]
		IfcProcess _RelatingProcess;
	
		[DataMember(Order=1)] 
		IfcMeasureWithUnit _QuantityInProcess;
	
	
		[Description("Reference to the process to which the objects are assigned to.\r\n")]
		public IfcProcess RelatingProcess { get { return this._RelatingProcess; } set { this._RelatingProcess = value;} }
	
		[Description("Quantity of the object specific for the operation by this process.")]
		public IfcMeasureWithUnit QuantityInProcess { get { return this._QuantityInProcess; } set { this._QuantityInProcess = value;} }
	
	
	}
	
}
