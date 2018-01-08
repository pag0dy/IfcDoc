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
	[Guid("a833ffe8-a590-4380-90b8-dd32167b36f6")]
	public partial class IfcRelNests : IfcRelDecomposes
	{
		[DataMember(Order=0)] 
		[XmlElement("IfcObjectDefinition")]
		[Required()]
		IfcObjectDefinition _RelatingObject;
	
		[DataMember(Order=1)] 
		[Required()]
		IList<IfcObjectDefinition> _RelatedObjects = new List<IfcObjectDefinition>();
	
	
		[Description(@"<EPM-HTML>
	The object definition, either an non-product object type or a non-product object occurrence, that represents the nest. It is the whole within the whole/part relationship.
	
	<blockquote class=""change-ifc2x4"">IFC4 CHANGE&nbsp; The attribute has been demoted from the supertype <em>IfcRelDecomposes</em> and defines the ordered nesting relationship.</blockquote>
	
	</EPM-HTML>")]
		public IfcObjectDefinition RelatingObject { get { return this._RelatingObject; } set { this._RelatingObject = value;} }
	
		[Description(@"<EPM-HTML>
	The object definitions, either non-product object occurrences or non-product object types, that are being nestes. They are defined as the parts in the ordered whole/part relationship -  i.e. there is an implied order among the parts expressed by the position within the list of <em>RelatedObjects</em>.
	
	<blockquote class=""change-ifc2x4"">IFC4 CHANGE&nbsp; The attribute has been demoted from the supertype <em>IfcRelDecomposes</em> and defines the ordered set of parts within the nest.</blockquote>
	
	</EPM-HTML>
	")]
		public IList<IfcObjectDefinition> RelatedObjects { get { return this._RelatedObjects; } }
	
	
	}
	
}
