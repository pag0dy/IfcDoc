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
	[Guid("cf235ade-9bdb-4c6d-affb-f537deaad8c1")]
	public partial class IfcRelAssignsToActor : IfcRelAssigns
	{
		[DataMember(Order=0)] 
		[Required()]
		IfcActor _RelatingActor;
	
		[DataMember(Order=1)] 
		IfcActorRole _ActingRole;
	
	
		[Description("Reference to the information about the actor. It comprises the information about " +
	    "the person or organization and its addresses.\r\n")]
		public IfcActor RelatingActor { get { return this._RelatingActor; } set { this._RelatingActor = value;} }
	
		[Description("Role of the actor played within the context of the assignment to the object(s).\r\n" +
	    "")]
		public IfcActorRole ActingRole { get { return this._ActingRole; } set { this._ActingRole = value;} }
	
	
	}
	
}
