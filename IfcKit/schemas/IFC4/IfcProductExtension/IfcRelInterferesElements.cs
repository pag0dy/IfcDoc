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
	[Guid("61792a4b-dbd0-4dd6-9d1d-5af75a4780a8")]
	public partial class IfcRelInterferesElements : IfcRelConnects
	{
		[DataMember(Order=0)] 
		[XmlElement("IfcElement")]
		[Required()]
		IfcElement _RelatingElement;
	
		[DataMember(Order=1)] 
		[XmlElement("IfcElement")]
		[Required()]
		IfcElement _RelatedElement;
	
		[DataMember(Order=2)] 
		[XmlElement("IfcConnectionGeometry")]
		IfcConnectionGeometry _InterferenceGeometry;
	
		[DataMember(Order=3)] 
		[XmlAttribute]
		IfcIdentifier? _InterferenceType;
	
		[DataMember(Order=4)] 
		[Required()]
		Boolean? _ImpliedOrder;
	
	
		[Description(@"<EPM-HTML>
	Reference to a subtype of <em>IfcElement</> that is the <em>RelatingElement</em> in the interference relationship. Depending on the value of <em>ImpliedOrder</em> the <em>RelatingElement</em> may carry the notion to be the element from which the interference geometry should be subtracted.
	</EPM-HTML>")]
		public IfcElement RelatingElement { get { return this._RelatingElement; } set { this._RelatingElement = value;} }
	
		[Description(@"<EPM-HTML>
	Reference to a subtype of <em>IfcElement</> that is the <em>RelatedElement</em> in the interference relationship. Depending on the value of <em>ImpliedOrder</em> the <em>RelatedElement</em> may carry the notion to be the element from which the interference geometry should not be subtracted.
	</EPM-HTML>")]
		public IfcElement RelatedElement { get { return this._RelatedElement; } set { this._RelatedElement = value;} }
	
		[Description(@"<EPM-HTML>
	The geometric shape representation of the interference geometry that is provided in the object coordinate system of the <em>RelatingElement</em> (mandatory) and in the object coordinate system of the <em>RelatedElement</em> (optionally).
	</EPM-HTML>")]
		public IfcConnectionGeometry InterferenceGeometry { get { return this._InterferenceGeometry; } set { this._InterferenceGeometry = value;} }
	
		[Description("<EPM-HTML>\r\nOptional identifier that describes the nature of the interference. Ex" +
	    "amples could include \'Clash\', \'ProvisionForVoid\', etc.\r\n</EPM-HTML>")]
		public IfcIdentifier? InterferenceType { get { return this._InterferenceType; } set { this._InterferenceType = value;} }
	
		[Description(@"<EPM-HTML>
	Logical value indicating whether the interference geometry should be subtracted from the <em>RelatingElement</em> (if TRUE), or whether it should be either subtracted from the <em>RelatingElement</em> or the <em>RelatedElement</em> (if FALSE), or whether no indication can be provided (if UNKNOWN).
	</EPM-HTML>")]
		public Boolean? ImpliedOrder { get { return this._ImpliedOrder; } set { this._ImpliedOrder = value;} }
	
	
	}
	
}
