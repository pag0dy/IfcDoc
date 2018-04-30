// This file may be edited manually or auto-generated using IfcKit at www.buildingsmart-tech.org.
// IFC content is copyright (C) 1996-2018 BuildingSMART International Ltd.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Xml.Serialization;

using BuildingSmart.IFC.IfcGeometryResource;
using BuildingSmart.IFC.IfcMeasureResource;
using BuildingSmart.IFC.IfcUtilityResource;

namespace BuildingSmart.IFC.IfcKernel
{
	public partial class IfcTypeProduct : IfcTypeObject,
		BuildingSmart.IFC.IfcKernel.IfcProductSelect
	{
		[DataMember(Order = 0)] 
		[Description("List of unique representation maps. Each representation map describes a block definition of the shape of the product style. By providing more than one representation map, a multi-view block definition can be given.")]
		[MinLength(1)]
		public IList<IfcRepresentationMap> RepresentationMaps { get; protected set; }
	
		[DataMember(Order = 1)] 
		[XmlAttribute]
		[Description("The tag (or label) identifier at the particular type of a product, e.g. the article number (like the EAN). It is the identifier at the specific level.")]
		public IfcLabel? Tag { get; set; }
	
		[InverseProperty("RelatingProduct")] 
		[Description("Reference to the <em>IfcRelAssignsToProduct</em> relationship, by which other products, processes, controls, resources or actors (as subtypes of <em>IfcObjectDefinition</em>) can be related to this product type.  <blockquote class=\"change-ifc2x4\">IFC4 CHANGE&nbsp;  New inverse relationship.</blockquote>")]
		public ISet<IfcRelAssignsToProduct> ReferencedBy { get; protected set; }
	
	
		public IfcTypeProduct(IfcGloballyUniqueId __GlobalId, IfcOwnerHistory __OwnerHistory, IfcLabel? __Name, IfcText? __Description, IfcIdentifier? __ApplicableOccurrence, IfcPropertySetDefinition[] __HasPropertySets, IfcRepresentationMap[] __RepresentationMaps, IfcLabel? __Tag)
			: base(__GlobalId, __OwnerHistory, __Name, __Description, __ApplicableOccurrence, __HasPropertySets)
		{
			this.RepresentationMaps = new List<IfcRepresentationMap>(__RepresentationMaps);
			this.Tag = __Tag;
			this.ReferencedBy = new HashSet<IfcRelAssignsToProduct>();
		}
	
	
	}
	
}
