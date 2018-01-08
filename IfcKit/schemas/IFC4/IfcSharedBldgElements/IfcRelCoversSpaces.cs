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
	[Guid("d7038275-a6b7-4293-86c1-f69337a29534")]
	public partial class IfcRelCoversSpaces : IfcRelConnects
	{
		[DataMember(Order=0)] 
		[XmlElement("IfcSpace")]
		[Required()]
		IfcSpace _RelatingSpace;
	
		[DataMember(Order=1)] 
		[Required()]
		ISet<IfcCovering> _RelatedCoverings = new HashSet<IfcCovering>();
	
	
		[Description(@"<EPM-HTML>
	Relationship to the space object that is covered.
	<blockquote class=""change-ifc2x4"">IFC4 CHANGE&nbsp; The attribute name has been changed from <em>RelatedSpace</em> to <em>RelatingSpace</em> with upward compatibility for file based exchange.</blockquote>
	</EPM-HTML>")]
		public IfcSpace RelatingSpace { get { return this._RelatingSpace; } set { this._RelatingSpace = value;} }
	
		[Description("<EPM-HTML>\r\nRelationship to the set of coverings covering that cover surfaces of " +
	    "this space.\r\n<EPM-HTML>\r\n")]
		public ISet<IfcCovering> RelatedCoverings { get { return this._RelatedCoverings; } }
	
	
	}
	
}
