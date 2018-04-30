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

using BuildingSmart.IFC.IfcExternalReferenceResource;
using BuildingSmart.IFC.IfcMeasureResource;

namespace BuildingSmart.IFC.IfcPropertyResource
{
	public partial class IfcPropertyDependencyRelationship : IfcResourceLevelRelationship
	{
		[DataMember(Order = 0)] 
		[XmlElement]
		[Description("The property on which the relationship depends.")]
		[Required()]
		public IfcProperty DependingProperty { get; set; }
	
		[DataMember(Order = 1)] 
		[XmlElement]
		[Description("The dependant property.")]
		[Required()]
		public IfcProperty DependantProperty { get; set; }
	
		[DataMember(Order = 2)] 
		[XmlAttribute]
		[Description("Expression that further describes the nature of the dependency relation.")]
		public IfcText? Expression { get; set; }
	
	
		public IfcPropertyDependencyRelationship(IfcLabel? __Name, IfcText? __Description, IfcProperty __DependingProperty, IfcProperty __DependantProperty, IfcText? __Expression)
			: base(__Name, __Description)
		{
			this.DependingProperty = __DependingProperty;
			this.DependantProperty = __DependantProperty;
			this.Expression = __Expression;
		}
	
	
	}
	
}
