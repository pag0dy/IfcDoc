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
	[Guid("72eec376-bbab-40d5-9342-93108c172713")]
	public partial class IfcRelAssignsToProduct : IfcRelAssigns
	{
		[DataMember(Order=0)] 
		[Required()]
		IfcProductSelect _RelatingProduct;
	
	
		[Description("<EPM-HTML>\r\nReference to the product or product type to which the objects are ass" +
	    "igned to.\r\n<blockquote class=\"change-ifc2x4\">IFC4 CHANGE Datatype expanded to in" +
	    "clude <em>IfcProduct</em> and <em>IfcTypeProduct</em>.</blockquote>\r\n</EPM-HTML>" +
	    "")]
		public IfcProductSelect RelatingProduct { get { return this._RelatingProduct; } set { this._RelatingProduct = value;} }
	
	
	}
	
}
