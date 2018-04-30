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

using BuildingSmart.IFC.IfcMeasureResource;
using BuildingSmart.IFC.IfcPropertyResource;

namespace BuildingSmart.IFC.IfcConstraintResource
{
	public partial class IfcPropertyConstraintRelationship
	{
		[DataMember(Order = 0)] 
		[Description("The constraint that is to be related.")]
		[Required()]
		public IfcConstraint RelatingConstraint { get; set; }
	
		[DataMember(Order = 1)] 
		[Description("The properties to which a constraint is to be related.")]
		[Required()]
		[MinLength(1)]
		public ISet<IfcProperty> RelatedProperties { get; protected set; }
	
		[DataMember(Order = 2)] 
		[XmlAttribute]
		[Description("A name used to identify or qualify the property constraint relationship.")]
		public IfcLabel? Name { get; set; }
	
		[DataMember(Order = 3)] 
		[XmlAttribute]
		[Description("A description that may apply additional information about a property constraint relationship.")]
		public IfcText? Description { get; set; }
	
	
		public IfcPropertyConstraintRelationship(IfcConstraint __RelatingConstraint, IfcProperty[] __RelatedProperties, IfcLabel? __Name, IfcText? __Description)
		{
			this.RelatingConstraint = __RelatingConstraint;
			this.RelatedProperties = new HashSet<IfcProperty>(__RelatedProperties);
			this.Name = __Name;
			this.Description = __Description;
		}
	
	
	}
	
}
