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
using BuildingSmart.IFC.IfcPropertyResource;

namespace BuildingSmart.IFC.IfcConstraintResource
{
	[Guid("3f93410d-c869-4422-b633-677daa7a5764")]
	public partial class IfcPropertyConstraintRelationship
	{
		[DataMember(Order=0)] 
		[Required()]
		IfcConstraint _RelatingConstraint;
	
		[DataMember(Order=1)] 
		[Required()]
		[MinLength(1)]
		ISet<IfcProperty> _RelatedProperties = new HashSet<IfcProperty>();
	
		[DataMember(Order=2)] 
		[XmlAttribute]
		IfcLabel? _Name;
	
		[DataMember(Order=3)] 
		[XmlAttribute]
		IfcText? _Description;
	
	
		public IfcPropertyConstraintRelationship()
		{
		}
	
		public IfcPropertyConstraintRelationship(IfcConstraint __RelatingConstraint, IfcProperty[] __RelatedProperties, IfcLabel? __Name, IfcText? __Description)
		{
			this._RelatingConstraint = __RelatingConstraint;
			this._RelatedProperties = new HashSet<IfcProperty>(__RelatedProperties);
			this._Name = __Name;
			this._Description = __Description;
		}
	
		[Description("The constraint that is to be related.")]
		public IfcConstraint RelatingConstraint { get { return this._RelatingConstraint; } set { this._RelatingConstraint = value;} }
	
		[Description("The properties to which a constraint is to be related.")]
		public ISet<IfcProperty> RelatedProperties { get { return this._RelatedProperties; } }
	
		[Description("A name used to identify or qualify the property constraint relationship.")]
		public IfcLabel? Name { get { return this._Name; } set { this._Name = value;} }
	
		[Description("A description that may apply additional information about a property constraint r" +
	    "elationship.")]
		public IfcText? Description { get { return this._Description; } set { this._Description = value;} }
	
	
	}
	
}
