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

using BuildingSmart.IFC.IfcCostResource;
using BuildingSmart.IFC.IfcMeasureResource;

namespace BuildingSmart.IFC.IfcConstraintResource
{
	public partial class IfcReference :
		BuildingSmart.IFC.IfcCostResource.IfcAppliedValueSelect,
		BuildingSmart.IFC.IfcConstraintResource.IfcMetricValueSelect
	{
		[DataMember(Order = 0)] 
		[XmlAttribute]
		[Description("Optional identifier of the entity or type such as 'IfcMaterialLayerSet'. For entity, type, or select-based references within a collection, this resolves the reference to such type.   If omitted, the type is assumed to be the same as the declared referencing attribute.    <blockquote class=\"example\">EXAMPLE&nbsp; <i>IfcRelAssociatesMaterial</i>.<i>RelatingMaterial</i> may be resolved to <i>IfcMaterialLayerSet</i>.</blockquote>")]
		public IfcIdentifier? TypeIdentifier { get; set; }
	
		[DataMember(Order = 1)] 
		[XmlAttribute]
		[Description("Optionally identifies a direct or inverse attribute within an entity such as 'MaterialLayers'.   If <i>TypeIdentifier</i> is specified and refers to an entity, the attribute must exist within the referenced entity.  A null value indicates a reference to the type or entity itself, such as for indicating that the type of a value must match a specified constraint.  ")]
		public IfcIdentifier? AttributeIdentifier { get; set; }
	
		[DataMember(Order = 2)] 
		[XmlAttribute]
		[Description("Optionally identifies an instance within a collection according to name.  If the instance has an attribute called 'Name', such attribute is used for comparison; otherwise the first STRING-based attribute of the entity is used.    <blockquote class=\"example\">EXAMPLE&nbsp; <i>IfcRoot</i>-based entities such as <i>IfcPropertySet</i> use the <i>Name</i> attribute; <i>IfcRepresentation</i> entities use the <i>RepresentationIdentifier</i> attribute.</blockquote>")]
		public IfcLabel? InstanceName { get; set; }
	
		[DataMember(Order = 3)] 
		[XmlAttribute]
		[Description("Optionally identifies an instance within a collection according to position starting at 1.  For referencing single-level collections, this attribute contains a single member; for referencing multi-level collections, then this LIST attribute contains multiple members starting from the outer-most index.")]
		[MinLength(1)]
		public IList<IfcInteger> ListPositions { get; protected set; }
	
		[DataMember(Order = 4)] 
		[XmlElement]
		[Description("Optional reference to an inner value for ENTITY, SELECT, SET, or LIST attributes.  A path may be formed by linking <i>IfcReference</i> instances together.  <blockquote class=\"example\">EXAMPLE&nbsp; A material layer thickness may be referenced using several instances:   #1=IFCREFERENCE($,'IfcSlab','HasAssociations',#2);   #2=IFCREFERENCE($,'IfcMaterialLayerSet','MaterialLayers',#3);   #3=IFCREFERENCE('Core','IfcMaterialLayer','LayerThickness',$);   </blockquote>")]
		public IfcReference InnerReference { get; set; }
	
	
		public IfcReference(IfcIdentifier? __TypeIdentifier, IfcIdentifier? __AttributeIdentifier, IfcLabel? __InstanceName, IfcInteger[] __ListPositions, IfcReference __InnerReference)
		{
			this.TypeIdentifier = __TypeIdentifier;
			this.AttributeIdentifier = __AttributeIdentifier;
			this.InstanceName = __InstanceName;
			this.ListPositions = new List<IfcInteger>(__ListPositions);
			this.InnerReference = __InnerReference;
		}
	
	
	}
	
}
