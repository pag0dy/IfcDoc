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

using BuildingSmart.IFC.IfcGeometricConstraintResource;
using BuildingSmart.IFC.IfcGeometryResource;
using BuildingSmart.IFC.IfcKernel;
using BuildingSmart.IFC.IfcMeasureResource;
using BuildingSmart.IFC.IfcPresentationAppearanceResource;
using BuildingSmart.IFC.IfcProductExtension;
using BuildingSmart.IFC.IfcProfilePropertyResource;
using BuildingSmart.IFC.IfcRepresentationResource;
using BuildingSmart.IFC.IfcStructuralLoadResource;

namespace BuildingSmart.IFC.IfcStructuralAnalysisDomain
{
	[Guid("297f17bf-b2bb-4961-a224-dcc444a66eca")]
	public partial class IfcRelConnectsStructuralElement : IfcRelConnects
	{
		[DataMember(Order=0)] 
		[Required()]
		IfcElement _RelatingElement;
	
		[DataMember(Order=1)] 
		[Required()]
		IfcStructuralMember _RelatedStructuralMember;
	
	
		[Description("<EPM-HTML>\r\nThe physical element, representing a design or detailing part, that i" +
	    "s connected to the structural member as its (partial) analytical  idealization.\r" +
	    "\n</EPM-HTML>")]
		public IfcElement RelatingElement { get { return this._RelatingElement; } set { this._RelatingElement = value;} }
	
		[Description("<EPM-HTML>\r\nThe structural member that is associated with the element of which it" +
	    " represents the analytical idealization.\r\n</EPM-HTML>")]
		public IfcStructuralMember RelatedStructuralMember { get { return this._RelatedStructuralMember; } set { this._RelatedStructuralMember = value;} }
	
	
	}
	
}
