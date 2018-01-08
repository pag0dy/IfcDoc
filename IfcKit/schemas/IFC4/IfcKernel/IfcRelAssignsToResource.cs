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
	[Guid("8e3fe369-7b2f-42e1-ba03-10771a673e88")]
	public partial class IfcRelAssignsToResource : IfcRelAssigns
	{
		[DataMember(Order=0)] 
		[Required()]
		IfcResourceSelect _RelatingResource;
	
	
		[Description("<EPM-HTML>\r\nReference to the resource to which the objects are assigned to.\r\n<blo" +
	    "ckquote class=\"change-ifc2x4\">IFC4 CHANGE Datatype expanded to include <em>IfcRe" +
	    "source</em> and <em>IfcTypeResource</em>.</blockquote>\r\n</EPM-HTML>")]
		public IfcResourceSelect RelatingResource { get { return this._RelatingResource; } set { this._RelatingResource = value;} }
	
	
	}
	
}
