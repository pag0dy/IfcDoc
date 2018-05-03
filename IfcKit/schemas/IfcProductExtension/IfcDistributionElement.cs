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

using BuildingSmart.IFC.IfcGeometricConstraintResource;
using BuildingSmart.IFC.IfcKernel;
using BuildingSmart.IFC.IfcMeasureResource;
using BuildingSmart.IFC.IfcRepresentationResource;
using BuildingSmart.IFC.IfcSharedBldgElements;
using BuildingSmart.IFC.IfcStructuralAnalysisDomain;
using BuildingSmart.IFC.IfcUtilityResource;

namespace BuildingSmart.IFC.IfcProductExtension
{
	public partial class IfcDistributionElement : IfcElement
	{
		[InverseProperty("RelatedElement")] 
		[Description("Reference to the element to port connection relationship. The relationship then refers to the port which is contained in this element.    <blockquote class=\"change-ifc2x4\">  IFC4 CHANGE&nbsp; The inverse attribute is deprecated. Relationship to ports, contained within the <em>IfcDistributionElement</em> is now realized by the inverse relationship <em>NestedBy</em> referencing <em>IfcRelNests</em>.  </blockquote>")]
		public ISet<IfcRelConnectsPortToElement> HasPorts { get; protected set; }
	
	
		public IfcDistributionElement(IfcGloballyUniqueId __GlobalId, IfcOwnerHistory __OwnerHistory, IfcLabel? __Name, IfcText? __Description, IfcLabel? __ObjectType, IfcObjectPlacement __ObjectPlacement, IfcProductRepresentation __Representation, IfcIdentifier? __Tag)
			: base(__GlobalId, __OwnerHistory, __Name, __Description, __ObjectType, __ObjectPlacement, __Representation, __Tag)
		{
			this.HasPorts = new HashSet<IfcRelConnectsPortToElement>();
		}
	
	
	}
	
}
