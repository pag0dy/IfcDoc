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

using BuildingSmart.IFC.IfcGeometricConstraintResource;
using BuildingSmart.IFC.IfcKernel;
using BuildingSmart.IFC.IfcMeasureResource;
using BuildingSmart.IFC.IfcRepresentationResource;
using BuildingSmart.IFC.IfcUtilityResource;

namespace BuildingSmart.IFC.IfcProductExtension
{
	[Guid("032e8ec4-b702-496b-b1c7-582032fc9a31")]
	public abstract partial class IfcPort : IfcProduct
	{
		[InverseProperty("RelatingPort")] 
		[MaxLength(1)]
		ISet<IfcRelConnectsPortToElement> _ContainedIn = new HashSet<IfcRelConnectsPortToElement>();
	
		[InverseProperty("RelatedPort")] 
		[MaxLength(1)]
		ISet<IfcRelConnectsPorts> _ConnectedFrom = new HashSet<IfcRelConnectsPorts>();
	
		[InverseProperty("RelatingPort")] 
		[MaxLength(1)]
		ISet<IfcRelConnectsPorts> _ConnectedTo = new HashSet<IfcRelConnectsPorts>();
	
	
		public IfcPort()
		{
		}
	
		public IfcPort(IfcGloballyUniqueId __GlobalId, IfcOwnerHistory __OwnerHistory, IfcLabel? __Name, IfcText? __Description, IfcLabel? __ObjectType, IfcObjectPlacement __ObjectPlacement, IfcProductRepresentation __Representation)
			: base(__GlobalId, __OwnerHistory, __Name, __Description, __ObjectType, __ObjectPlacement, __Representation)
		{
		}
	
		[Description(@"Reference to the element to port connection relationship. The relationship then refers to the element in which this port is contained.
	<blockquote class=""change-ifc2x4"">
	IFC4 CHANGE&nbsp; The cardinality has been changed from 1:1 to 0:1.
	IFC4 DEPRECATION&nbsp; The inverse relationship is deprecated for fixed ports due to deprecation of <em>IfcRelConnectsPortToElement</em> for this usage. Use inverse relationship <em>Nests</em> instead.
	</blockquote>
	")]
		public ISet<IfcRelConnectsPortToElement> ContainedIn { get { return this._ContainedIn; } }
	
		[Description("Reference to a port that is connected by the objectified relationship.")]
		public ISet<IfcRelConnectsPorts> ConnectedFrom { get { return this._ConnectedFrom; } }
	
		[Description("Reference to the port connection relationship. The relationship then refers to th" +
	    "e other port to which this port is connected.")]
		public ISet<IfcRelConnectsPorts> ConnectedTo { get { return this._ConnectedTo; } }
	
	
	}
	
}
