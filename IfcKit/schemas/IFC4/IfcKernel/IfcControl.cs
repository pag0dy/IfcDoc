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
using BuildingSmart.IFC.IfcExternalReferenceResource;
using BuildingSmart.IFC.IfcGeometricConstraintResource;
using BuildingSmart.IFC.IfcGeometricModelResource;
using BuildingSmart.IFC.IfcGeometryResource;
using BuildingSmart.IFC.IfcMeasureResource;
using BuildingSmart.IFC.IfcPresentationAppearanceResource;
using BuildingSmart.IFC.IfcProcessExtension;
using BuildingSmart.IFC.IfcPropertyResource;
using BuildingSmart.IFC.IfcRepresentationResource;
using BuildingSmart.IFC.IfcUtilityResource;

namespace BuildingSmart.IFC.IfcKernel
{
	[Guid("5cc95018-83bd-4c3b-ba54-1475cf5cbdb7")]
	public abstract partial class IfcControl : IfcObject
	{
		[DataMember(Order=0)] 
		[XmlAttribute]
		IfcIdentifier? _Identification;
	
		[InverseProperty("RelatingControl")] 
		ISet<IfcRelAssignsToControl> _Controls = new HashSet<IfcRelAssignsToControl>();
	
	
		[Description(@"<EPM-HTML>
	    An identifying designation given to a control
	    It is the identifier at the occurrence level. 
	    <blockquote class=""change-ifc2x4"">IFC4 CHANGE  Attribute unified by promoting from various subtypes of <em>IfcControl</em>.   </blockquote>
	</EPM-HTML>")]
		public IfcIdentifier? Identification { get { return this._Identification; } set { this._Identification = value;} }
	
		[Description("Reference to the relationship that associates the control to the object(s) being " +
	    "controlled.\r\n")]
		public ISet<IfcRelAssignsToControl> Controls { get { return this._Controls; } }
	
	
	}
	
}
