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
using BuildingSmart.IFC.IfcApprovalResource;
using BuildingSmart.IFC.IfcConstraintResource;
using BuildingSmart.IFC.IfcCostResource;
using BuildingSmart.IFC.IfcDateTimeResource;
using BuildingSmart.IFC.IfcExternalReferenceResource;
using BuildingSmart.IFC.IfcKernel;
using BuildingSmart.IFC.IfcMaterialResource;
using BuildingSmart.IFC.IfcMeasureResource;
using BuildingSmart.IFC.IfcUtilityResource;

namespace BuildingSmart.IFC.IfcPropertyResource
{
	[Guid("0b79cf26-1901-47e3-beed-cf836b1c598d")]
	public partial class IfcPropertyDependencyRelationship : IfcResourceLevelRelationship
	{
		[DataMember(Order=0)] 
		[XmlElement]
		[Required()]
		IfcProperty _DependingProperty;
	
		[DataMember(Order=1)] 
		[XmlElement]
		[Required()]
		IfcProperty _DependantProperty;
	
		[DataMember(Order=2)] 
		[XmlAttribute]
		IfcText? _Expression;
	
	
		[Description("The property on which the relationship depends.")]
		public IfcProperty DependingProperty { get { return this._DependingProperty; } set { this._DependingProperty = value;} }
	
		[Description("The dependant property.")]
		public IfcProperty DependantProperty { get { return this._DependantProperty; } set { this._DependantProperty = value;} }
	
		[Description("Expression that further describes the nature of the dependency relation.")]
		public IfcText? Expression { get { return this._Expression; } set { this._Expression = value;} }
	
	
	}
	
}
