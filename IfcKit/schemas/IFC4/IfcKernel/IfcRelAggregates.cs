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
	[Guid("28ae0ad8-279b-405d-9aaf-cdf69a4da9d9")]
	public partial class IfcRelAggregates : IfcRelDecomposes
	{
		[DataMember(Order=0)] 
		[XmlElement("IfcObjectDefinition")]
		[Required()]
		IfcObjectDefinition _RelatingObject;
	
		[DataMember(Order=1)] 
		[Required()]
		ISet<IfcObjectDefinition> _RelatedObjects = new HashSet<IfcObjectDefinition>();
	
	
		[Description(@"<EPM-HTML>
	The object definition, either an object type or an object occurrence, that represents the aggregation. It is the whole within the whole/part relationship.
	
	<blockquote class=""change-ifc2x4"">IFC4 CHANGE&nbsp; The attribute has been demoted from the supertype <em>IfcRelDecomposes</em> and defines the non-ordered aggregation relationship.</blockquote>
	
	</EPM-HTML>")]
		public IfcObjectDefinition RelatingObject { get { return this._RelatingObject; } set { this._RelatingObject = value;} }
	
		[Description(@"<EPM-HTML>
	The object definitions, either object occurrences or object types, that are being aggregated. They are defined as the parts in the whole/part relationship. No order is implied between the parts.
	
	<blockquote class=""change-ifc2x4"">IFC4 CHANGE&nbsp; The attribute has been demoted from the supertype <em>IfcRelDecomposes</em> and defines the non-ordered set of parts within the aggregation.</blockquote>
	
	</EPM-HTML>
	")]
		public ISet<IfcObjectDefinition> RelatedObjects { get { return this._RelatedObjects; } }
	
	
	}
	
}
