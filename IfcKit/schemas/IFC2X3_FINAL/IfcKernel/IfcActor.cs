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
	[Guid("4539d35c-fe44-4f6b-b7b2-db4abe00bb5f")]
	public partial class IfcActor : IfcObject
	{
		[DataMember(Order=0)] 
		[Required()]
		IfcActorSelect _TheActor;
	
		[InverseProperty("RelatingActor")] 
		ISet<IfcRelAssignsToActor> _IsActingUpon = new HashSet<IfcRelAssignsToActor>();
	
	
		[Description("Information about the actor.\r\n")]
		public IfcActorSelect TheActor { get { return this._TheActor; } set { this._TheActor = value;} }
	
		[Description("Reference to the relationship that associates the actor to an object.\r\n")]
		public ISet<IfcRelAssignsToActor> IsActingUpon { get { return this._IsActingUpon; } }
	
	
	}
	
}
