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

namespace BuildingSmart.IFC.IfcPropertyResource
{
	public abstract partial class IfcProperty
	{
		[DataMember(Order = 0)] 
		[XmlAttribute]
		[Description("Name for this property. This label is the significant name string that defines the semantic meaning for the property.")]
		[Required()]
		public IfcIdentifier Name { get; set; }
	
		[DataMember(Order = 1)] 
		[XmlAttribute]
		[Description("Informative text to explain the property.")]
		public IfcText? Description { get; set; }
	
		[InverseProperty("DependingProperty")] 
		[Description("The property on whose value that of another property depends.")]
		public ISet<IfcPropertyDependencyRelationship> PropertyForDependance { get; protected set; }
	
		[InverseProperty("DependantProperty")] 
		[Description("The relating property on which the value of the property depends.")]
		public ISet<IfcPropertyDependencyRelationship> PropertyDependsOn { get; protected set; }
	
		[InverseProperty("HasProperties")] 
		[Description("Reference to the IfcComplexProperty in which the IfcProperty is contained.")]
		[MaxLength(1)]
		public ISet<IfcComplexProperty> PartOfComplex { get; protected set; }
	
	
		protected IfcProperty(IfcIdentifier __Name, IfcText? __Description)
		{
			this.Name = __Name;
			this.Description = __Description;
			this.PropertyForDependance = new HashSet<IfcPropertyDependencyRelationship>();
			this.PropertyDependsOn = new HashSet<IfcPropertyDependencyRelationship>();
			this.PartOfComplex = new HashSet<IfcComplexProperty>();
		}
	
	
	}
	
}
