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
	[Guid("921a1a16-20f9-45bc-956b-62e09d80fa95")]
	public partial class IfcRelCoversBldgElements : IfcRelConnects
	{
		[DataMember(Order=0)] 
		[XmlElement("IfcElement")]
		[Required()]
		IfcElement _RelatingBuildingElement;
	
		[DataMember(Order=1)] 
		[Required()]
		ISet<IfcCovering> _RelatedCoverings = new HashSet<IfcCovering>();
	
	
		[Description("Relationship to the element that is covered. It includes building elements for co" +
	    "verings such as flooring or cladding, or distribution elements for coverings suc" +
	    "h as sleeving or wrapping.")]
		public IfcElement RelatingBuildingElement { get { return this._RelatingBuildingElement; } set { this._RelatingBuildingElement = value;} }
	
		[Description("Relationship to the set of coverings that are assigned to this element.\r\n")]
		public ISet<IfcCovering> RelatedCoverings { get { return this._RelatedCoverings; } }
	
	
	}
	
}
