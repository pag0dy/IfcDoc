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
using BuildingSmart.IFC.IfcControlExtension;
using BuildingSmart.IFC.IfcDateTimeResource;
using BuildingSmart.IFC.IfcExternalReferenceResource;
using BuildingSmart.IFC.IfcGeometricConstraintResource;
using BuildingSmart.IFC.IfcGeometryResource;
using BuildingSmart.IFC.IfcKernel;
using BuildingSmart.IFC.IfcMaterialPropertyResource;
using BuildingSmart.IFC.IfcMaterialResource;
using BuildingSmart.IFC.IfcMeasureResource;
using BuildingSmart.IFC.IfcPresentationAppearanceResource;
using BuildingSmart.IFC.IfcProductExtension;
using BuildingSmart.IFC.IfcProfileResource;
using BuildingSmart.IFC.IfcPropertyResource;
using BuildingSmart.IFC.IfcTimeSeriesResource;

namespace BuildingSmart.IFC.IfcSharedBldgServiceElements
{
	[Guid("ad545ffd-432b-4bf8-8746-16d492c4ee6d")]
	public partial class IfcDistributionControlElement : IfcDistributionElement
	{
		[DataMember(Order=0)] 
		[XmlAttribute]
		IfcIdentifier? _ControlElementId;
	
		[InverseProperty("RelatedControlElements")] 
		ISet<IfcRelFlowControlElements> _AssignedToFlowElement = new HashSet<IfcRelFlowControlElements>();
	
	
		[Description("The ControlElement Point Identification assigned to this control element by the B" +
	    "uilding Automation System.\r\n")]
		public IfcIdentifier? ControlElementId { get { return this._ControlElementId; } set { this._ControlElementId = value;} }
	
		[Description("Reference through the relationship object to related distribution flow elements.")]
		public ISet<IfcRelFlowControlElements> AssignedToFlowElement { get { return this._AssignedToFlowElement; } }
	
	
	}
	
}
