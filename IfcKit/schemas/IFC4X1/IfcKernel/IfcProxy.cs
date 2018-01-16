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
	[Guid("c6b74ea4-3bfd-40f2-93bd-c648a95e3516")]
	public partial class IfcProxy : IfcProduct
	{
		[DataMember(Order=0)] 
		[XmlAttribute]
		[Required()]
		IfcObjectTypeEnum _ProxyType;
	
		[DataMember(Order=1)] 
		[XmlAttribute]
		IfcLabel? _Tag;
	
	
		[Description("High level (and only) semantic meaning attached to the IfcProxy, defining the bas" +
	    "ic construct type behind the Proxy, e.g. Product or Process.\r\n")]
		public IfcObjectTypeEnum ProxyType { get { return this._ProxyType; } set { this._ProxyType = value;} }
	
		[Description("The tag (or label) identifier at the particular instance of a product, e.g. the s" +
	    "erial number, or the position number. It is the identifier at the occurrence lev" +
	    "el.")]
		public IfcLabel? Tag { get { return this._Tag; } set { this._Tag = value;} }
	
	
	}
	
}
