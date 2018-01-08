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
using BuildingSmart.IFC.IfcKernel;
using BuildingSmart.IFC.IfcMaterialResource;
using BuildingSmart.IFC.IfcMeasureResource;
using BuildingSmart.IFC.IfcPresentationAppearanceResource;
using BuildingSmart.IFC.IfcPropertyResource;
using BuildingSmart.IFC.IfcQuantityResource;
using BuildingSmart.IFC.IfcRepresentationResource;
using BuildingSmart.IFC.IfcSharedBldgElements;
using BuildingSmart.IFC.IfcSharedBldgServiceElements;
using BuildingSmart.IFC.IfcSharedComponentElements;
using BuildingSmart.IFC.IfcSharedFacilitiesElements;
using BuildingSmart.IFC.IfcStructuralElementsDomain;

namespace BuildingSmart.IFC.IfcProductExtension
{
	[Guid("38e3c74b-486e-4323-980b-6375977d83ae")]
	public partial class IfcRelFillsElement : IfcRelConnects
	{
		[DataMember(Order=0)] 
		[XmlElement("IfcOpeningElement")]
		[Required()]
		IfcOpeningElement _RelatingOpeningElement;
	
		[DataMember(Order=1)] 
		[XmlElement("IfcElement")]
		[Required()]
		IfcElement _RelatedBuildingElement;
	
	
		[Description("Opening Element being filled by virtue of this relationship.\r\n")]
		public IfcOpeningElement RelatingOpeningElement { get { return this._RelatingOpeningElement; } set { this._RelatingOpeningElement = value;} }
	
		[Description(@"Reference to <strike>building</strike> element that occupies fully or partially the associated opening.
	<blockquote class=""change-ifc2x"">IFC2x CHANGE&nbsp; The data type has been changed from <em>IfcBuildingElement</em> to <em>IfcElement</em> with upward compatibility for file based exchange.</blockquote>")]
		public IfcElement RelatedBuildingElement { get { return this._RelatedBuildingElement; } set { this._RelatedBuildingElement = value;} }
	
	
	}
	
}
