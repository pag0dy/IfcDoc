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

using BuildingSmart.IFC.IfcMeasureResource;

namespace BuildingSmart.IFC.IfcPropertyResource
{
	[Guid("f331e745-a4d0-4fa4-90fb-3b8200920cd6")]
	public abstract partial class IfcProperty
	{
		[DataMember(Order=0)] 
		[XmlAttribute]
		[Required()]
		IfcIdentifier _Name;
	
		[DataMember(Order=1)] 
		[XmlAttribute]
		IfcText? _Description;
	
		[InverseProperty("DependingProperty")] 
		ISet<IfcPropertyDependencyRelationship> _PropertyForDependance = new HashSet<IfcPropertyDependencyRelationship>();
	
		[InverseProperty("DependantProperty")] 
		ISet<IfcPropertyDependencyRelationship> _PropertyDependsOn = new HashSet<IfcPropertyDependencyRelationship>();
	
		[InverseProperty("HasProperties")] 
		[MaxLength(1)]
		ISet<IfcComplexProperty> _PartOfComplex = new HashSet<IfcComplexProperty>();
	
	
		public IfcProperty()
		{
		}
	
		public IfcProperty(IfcIdentifier __Name, IfcText? __Description)
		{
			this._Name = __Name;
			this._Description = __Description;
		}
	
		[Description("Name for this property. This label is the significant name string that defines th" +
	    "e semantic meaning for the property.")]
		public IfcIdentifier Name { get { return this._Name; } set { this._Name = value;} }
	
		[Description("Informative text to explain the property.")]
		public IfcText? Description { get { return this._Description; } set { this._Description = value;} }
	
		[Description("The property on whose value that of another property depends.")]
		public ISet<IfcPropertyDependencyRelationship> PropertyForDependance { get { return this._PropertyForDependance; } }
	
		[Description("The relating property on which the value of the property depends.")]
		public ISet<IfcPropertyDependencyRelationship> PropertyDependsOn { get { return this._PropertyDependsOn; } }
	
		[Description("Reference to the IfcComplexProperty in which the IfcProperty is contained.")]
		public ISet<IfcComplexProperty> PartOfComplex { get { return this._PartOfComplex; } }
	
	
	}
	
}
