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

using BuildingSmart.IFC.IfcApprovalResource;
using BuildingSmart.IFC.IfcConstraintResource;
using BuildingSmart.IFC.IfcExternalReferenceResource;
using BuildingSmart.IFC.IfcKernel;
using BuildingSmart.IFC.IfcMeasureResource;

namespace BuildingSmart.IFC.IfcPropertyResource
{
	public abstract partial class IfcProperty : IfcPropertyAbstraction
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
	
		[InverseProperty("HasProperties")] 
		[Description("Reference to the <em>IfcPropertySet</em> by which the <em>IfcProperty</em> is referenced.  <blockquote class=\"change-ifc2x4\">IFC4 CHANGE&nbsp; New inverse attribute to navigate from <em>IfcProperty</em> to <em>IfcPropertySet</em> with upward compatibility for file based exchange.</blockquote>")]
		public ISet<IfcPropertySet> PartOfPset { get; protected set; }
	
		[InverseProperty("DependingProperty")] 
		[Description("The property on whose value that of another property depends.")]
		public ISet<IfcPropertyDependencyRelationship> PropertyForDependance { get; protected set; }
	
		[InverseProperty("DependantProperty")] 
		[Description("The relating property on which the value of the property depends.")]
		public ISet<IfcPropertyDependencyRelationship> PropertyDependsOn { get; protected set; }
	
		[InverseProperty("HasProperties")] 
		[Description("Reference to the <em>IfcComplexProperty</em> in which the <em>IfcProperty</em> is contained.  <blockquote class=\"change-ifc2x4\">IFC4 CHANGE&nbsp; The cardinality has changed to 0..n to allow reuse of instances of <em>IfcProperty</em> in several <em>IfcComplexProperty</em> with upward compatibility for file based exchange.</blockquote>")]
		public ISet<IfcComplexProperty> PartOfComplex { get; protected set; }
	
		[InverseProperty("RelatedResourceObjects")] 
		[Description("User-defined constraints for the property.")]
		public ISet<IfcResourceConstraintRelationship> HasConstraints { get; protected set; }
	
		[InverseProperty("RelatedResourceObjects")] 
		[Description("User-defined approvals for the property.")]
		public ISet<IfcResourceApprovalRelationship> HasApprovals { get; protected set; }
	
	
		protected IfcProperty(IfcIdentifier __Name, IfcText? __Description)
		{
			this.Name = __Name;
			this.Description = __Description;
			this.PartOfPset = new HashSet<IfcPropertySet>();
			this.PropertyForDependance = new HashSet<IfcPropertyDependencyRelationship>();
			this.PropertyDependsOn = new HashSet<IfcPropertyDependencyRelationship>();
			this.PartOfComplex = new HashSet<IfcComplexProperty>();
			this.HasConstraints = new HashSet<IfcResourceConstraintRelationship>();
			this.HasApprovals = new HashSet<IfcResourceApprovalRelationship>();
		}
	
	
	}
	
}
