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
	[Guid("4af5da7c-70c1-4f95-ac34-f4bab2f900e2")]
	public partial class IfcPropertyDependencyRelationship
	{
		[DataMember(Order=0)] 
		[Required()]
		IfcProperty _DependingProperty;
	
		[DataMember(Order=1)] 
		[Required()]
		IfcProperty _DependantProperty;
	
		[DataMember(Order=2)] 
		[XmlAttribute]
		IfcLabel? _Name;
	
		[DataMember(Order=3)] 
		[XmlAttribute]
		IfcText? _Description;
	
		[DataMember(Order=4)] 
		[XmlAttribute]
		IfcText? _Expression;
	
	
		public IfcPropertyDependencyRelationship()
		{
		}
	
		public IfcPropertyDependencyRelationship(IfcProperty __DependingProperty, IfcProperty __DependantProperty, IfcLabel? __Name, IfcText? __Description, IfcText? __Expression)
		{
			this._DependingProperty = __DependingProperty;
			this._DependantProperty = __DependantProperty;
			this._Name = __Name;
			this._Description = __Description;
			this._Expression = __Expression;
		}
	
		[Description("The property on which the relationship depends.")]
		public IfcProperty DependingProperty { get { return this._DependingProperty; } set { this._DependingProperty = value;} }
	
		[Description("The dependant property.")]
		public IfcProperty DependantProperty { get { return this._DependantProperty; } set { this._DependantProperty = value;} }
	
		[Description("Name of the relationship that provides additional meaning to the nature of the de" +
	    "pendency.")]
		public IfcLabel? Name { get { return this._Name; } set { this._Name = value;} }
	
		[Description("Additional description of the dependency.")]
		public IfcText? Description { get { return this._Description; } set { this._Description = value;} }
	
		[Description("Expression that further describes the nature of the dependency relation.")]
		public IfcText? Expression { get { return this._Expression; } set { this._Expression = value;} }
	
	
	}
	
}
