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
using BuildingSmart.IFC.IfcDateTimeResource;
using BuildingSmart.IFC.IfcExternalReferenceResource;
using BuildingSmart.IFC.IfcGeometricModelResource;
using BuildingSmart.IFC.IfcGeometryResource;
using BuildingSmart.IFC.IfcKernel;
using BuildingSmart.IFC.IfcMaterialResource;
using BuildingSmart.IFC.IfcMeasureResource;
using BuildingSmart.IFC.IfcPresentationAppearanceResource;
using BuildingSmart.IFC.IfcProductExtension;
using BuildingSmart.IFC.IfcPropertyResource;
using BuildingSmart.IFC.IfcRepresentationResource;

namespace BuildingSmart.IFC.IfcSharedBldgElements
{
	[Guid("8f561139-3792-4723-b343-700785092d40")]
	public partial class IfcSlab : IfcBuildingElement
	{
		[DataMember(Order=0)] 
		[XmlAttribute]
		IfcSlabTypeEnum? _PredefinedType;
	
	
		[Description(@"<EPM-HTML>
	Predefined generic type for a slab that is specified in an enumeration. There may be a property set given specifically for the predefined types.
	<blockquote class=""note"">NOTE&nbsp; The <em>PredefinedType</em> shall only be used, if no <em>IfcSlabType</em> is assigned, providing its own <em>IfcSlabType.PredefinedType</em>.</blockquote>
	<blockquote  class=""change-ifc2x"">IFC2x CHANGE The attribute has been changed into an OPTIONAL attribute.</blockquote>
	</EPM-HTML> ")]
		public IfcSlabTypeEnum? PredefinedType { get { return this._PredefinedType; } set { this._PredefinedType = value;} }
	
	
	}
	
}
