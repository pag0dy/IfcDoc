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
using BuildingSmart.IFC.IfcDateTimeResource;
using BuildingSmart.IFC.IfcExternalReferenceResource;
using BuildingSmart.IFC.IfcGeometricConstraintResource;
using BuildingSmart.IFC.IfcGeometricModelResource;
using BuildingSmart.IFC.IfcGeometryResource;
using BuildingSmart.IFC.IfcKernel;
using BuildingSmart.IFC.IfcMaterialResource;
using BuildingSmart.IFC.IfcMeasureResource;
using BuildingSmart.IFC.IfcPresentationAppearanceResource;
using BuildingSmart.IFC.IfcProfilePropertyResource;
using BuildingSmart.IFC.IfcPropertyResource;
using BuildingSmart.IFC.IfcQuantityResource;
using BuildingSmart.IFC.IfcRepresentationResource;
using BuildingSmart.IFC.IfcSharedBldgElements;
using BuildingSmart.IFC.IfcSharedBldgServiceElements;
using BuildingSmart.IFC.IfcStructuralAnalysisDomain;
using BuildingSmart.IFC.IfcStructuralElementsDomain;

namespace BuildingSmart.IFC.IfcProductExtension
{
	[Guid("6039b15a-9b36-4f5f-9d66-2c80b0c6ccb9")]
	public abstract partial class IfcPort : IfcProduct
	{
		[InverseProperty("RelatingPort")] 
		IfcRelConnectsPortToElement _ContainedIn;
	
		[InverseProperty("RelatedPort")] 
		ISet<IfcRelConnectsPorts> _ConnectedFrom = new HashSet<IfcRelConnectsPorts>();
	
		[InverseProperty("RelatingPort")] 
		ISet<IfcRelConnectsPorts> _ConnectedTo = new HashSet<IfcRelConnectsPorts>();
	
	
		[Description("Reference to the element to port connection relationship. The relationship then r" +
	    "efers to the element in which this port is contained.\r\n")]
		public IfcRelConnectsPortToElement ContainedIn { get { return this._ContainedIn; } set { this._ContainedIn = value;} }
	
		[Description("Reference to a port that is connected by the objectified relationship.")]
		public ISet<IfcRelConnectsPorts> ConnectedFrom { get { return this._ConnectedFrom; } }
	
		[Description("Reference to the port connection relationship. The relationship then refers to th" +
	    "e other port to which this port is connected.")]
		public ISet<IfcRelConnectsPorts> ConnectedTo { get { return this._ConnectedTo; } }
	
	
	}
	
}
