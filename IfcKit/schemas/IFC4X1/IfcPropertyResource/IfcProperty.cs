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

using BuildingSmart.IFC.IfcApprovalResource;
using BuildingSmart.IFC.IfcConstraintResource;
using BuildingSmart.IFC.IfcExternalReferenceResource;
using BuildingSmart.IFC.IfcKernel;
using BuildingSmart.IFC.IfcMeasureResource;

namespace BuildingSmart.IFC.IfcPropertyResource
{
	[Guid("911b51d0-e3e7-45db-a881-520360ded638")]
	public abstract partial class IfcProperty : IfcPropertyAbstraction
	{
		[DataMember(Order=0)] 
		[XmlAttribute]
		[Required()]
		IfcIdentifier _Name;
	
		[DataMember(Order=1)] 
		[XmlAttribute]
		IfcText? _Description;
	
		[InverseProperty("HasProperties")] 
		ISet<IfcPropertySet> _PartOfPset = new HashSet<IfcPropertySet>();
	
		[InverseProperty("DependingProperty")] 
		ISet<IfcPropertyDependencyRelationship> _PropertyForDependance = new HashSet<IfcPropertyDependencyRelationship>();
	
		[InverseProperty("DependantProperty")] 
		ISet<IfcPropertyDependencyRelationship> _PropertyDependsOn = new HashSet<IfcPropertyDependencyRelationship>();
	
		[InverseProperty("HasProperties")] 
		ISet<IfcComplexProperty> _PartOfComplex = new HashSet<IfcComplexProperty>();
	
		[InverseProperty("RelatedResourceObjects")] 
		ISet<IfcResourceConstraintRelationship> _HasConstraints = new HashSet<IfcResourceConstraintRelationship>();
	
		[InverseProperty("RelatedResourceObjects")] 
		ISet<IfcResourceApprovalRelationship> _HasApprovals = new HashSet<IfcResourceApprovalRelationship>();
	
	
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
	
		[Description(@"Reference to the <em>IfcPropertySet</em> by which the <em>IfcProperty</em> is referenced.
	<blockquote class=""change-ifc2x4"">IFC4 CHANGE&nbsp; New inverse attribute to navigate from <em>IfcProperty</em> to <em>IfcPropertySet</em> with upward compatibility for file based exchange.</blockquote>")]
		public ISet<IfcPropertySet> PartOfPset { get { return this._PartOfPset; } }
	
		[Description("The property on whose value that of another property depends.")]
		public ISet<IfcPropertyDependencyRelationship> PropertyForDependance { get { return this._PropertyForDependance; } }
	
		[Description("The relating property on which the value of the property depends.")]
		public ISet<IfcPropertyDependencyRelationship> PropertyDependsOn { get { return this._PropertyDependsOn; } }
	
		[Description(@"Reference to the <em>IfcComplexProperty</em> in which the <em>IfcProperty</em> is contained.
	<blockquote class=""change-ifc2x4"">IFC4 CHANGE&nbsp; The cardinality has changed to 0..n to allow reuse of instances of <em>IfcProperty</em> in several <em>IfcComplexProperty</em> with upward compatibility for file based exchange.</blockquote>")]
		public ISet<IfcComplexProperty> PartOfComplex { get { return this._PartOfComplex; } }
	
		[Description("User-defined constraints for the property.")]
		public ISet<IfcResourceConstraintRelationship> HasConstraints { get { return this._HasConstraints; } }
	
		[Description("User-defined approvals for the property.")]
		public ISet<IfcResourceApprovalRelationship> HasApprovals { get { return this._HasApprovals; } }
	
	
	}
	
}
