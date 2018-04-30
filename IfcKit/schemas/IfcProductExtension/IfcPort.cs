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
using BuildingSmart.IFC.IfcUtilityResource;

namespace BuildingSmart.IFC.IfcProductExtension
{
	public abstract partial class IfcPort : IfcProduct
	{
		[InverseProperty("RelatingPort")] 
		[Description("Reference to the element to port connection relationship. The relationship then refers to the element in which this port is contained.  <blockquote class=\"change-ifc2x4\">  IFC4 CHANGE&nbsp; The cardinality has been changed from 1:1 to 0:1.  IFC4 DEPRECATION&nbsp; The inverse relationship is deprecated for fixed ports due to deprecation of <em>IfcRelConnectsPortToElement</em> for this usage. Use inverse relationship <em>Nests</em> instead.  </blockquote>  ")]
		[MaxLength(1)]
		public ISet<IfcRelConnectsPortToElement> ContainedIn { get; protected set; }
	
		[InverseProperty("RelatedPort")] 
		[Description("Reference to a port that is connected by the objectified relationship.")]
		[MaxLength(1)]
		public ISet<IfcRelConnectsPorts> ConnectedFrom { get; protected set; }
	
		[InverseProperty("RelatingPort")] 
		[Description("Reference to the port connection relationship. The relationship then refers to the other port to which this port is connected.")]
		[MaxLength(1)]
		public ISet<IfcRelConnectsPorts> ConnectedTo { get; protected set; }
	
	
		protected IfcPort(IfcGloballyUniqueId __GlobalId, IfcOwnerHistory __OwnerHistory, IfcLabel? __Name, IfcText? __Description, IfcLabel? __ObjectType, IfcObjectPlacement __ObjectPlacement, IfcProductRepresentation __Representation)
			: base(__GlobalId, __OwnerHistory, __Name, __Description, __ObjectType, __ObjectPlacement, __Representation)
		{
			this.ContainedIn = new HashSet<IfcRelConnectsPortToElement>();
			this.ConnectedFrom = new HashSet<IfcRelConnectsPorts>();
			this.ConnectedTo = new HashSet<IfcRelConnectsPorts>();
		}
	
	
	}
	
}
