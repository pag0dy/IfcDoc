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
	[Guid("2749c418-fb5d-400d-92ce-0c491a55cbd7")]
	public partial class IfcRelConnectsElements : IfcRelConnects
	{
		[DataMember(Order=0)] 
		[XmlElement("IfcConnectionGeometry")]
		IfcConnectionGeometry _ConnectionGeometry;
	
		[DataMember(Order=1)] 
		[XmlElement("IfcElement")]
		[Required()]
		IfcElement _RelatingElement;
	
		[DataMember(Order=2)] 
		[XmlElement("IfcElement")]
		[Required()]
		IfcElement _RelatedElement;
	
	
		[Description("The geometric shape representation of the connection geometry that is provided in" +
	    " the object coordinate system of the <em>RelatingElement</em> (mandatory) and in" +
	    " the object coordinate system of the <em>RelatedElement</em> (optionally).")]
		public IfcConnectionGeometry ConnectionGeometry { get { return this._ConnectionGeometry; } set { this._ConnectionGeometry = value;} }
	
		[Description("Reference to a subtype of <em>IfcElement</em> that is connected by the connection" +
	    " relationship in the role of <em>RelatingElement</em>.\r\n")]
		public IfcElement RelatingElement { get { return this._RelatingElement; } set { this._RelatingElement = value;} }
	
		[Description("Reference to a subtype of <em>IfcElement</em> that is connected by the connection" +
	    " relationship in the role of <em>RelatedElement</em>.")]
		public IfcElement RelatedElement { get { return this._RelatedElement; } set { this._RelatedElement = value;} }
	
	
	}
	
}
