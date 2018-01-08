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
	[Guid("beedc2df-a5bb-4bb2-830c-6b59b3d3f29f")]
	public partial class IfcRelFlowControlElements : IfcRelConnects
	{
		[DataMember(Order=0)] 
		[Required()]
		ISet<IfcDistributionControlElement> _RelatedControlElements = new HashSet<IfcDistributionControlElement>();
	
		[DataMember(Order=1)] 
		[Required()]
		IfcDistributionFlowElement _RelatingFlowElement;
	
	
		[Description("References control elements which may be used to impart control on the Distributi" +
	    "on Element.\r\n")]
		public ISet<IfcDistributionControlElement> RelatedControlElements { get { return this._RelatedControlElements; } }
	
		[Description("Relationship to a distribution flow element\r\n")]
		public IfcDistributionFlowElement RelatingFlowElement { get { return this._RelatingFlowElement; } set { this._RelatingFlowElement = value;} }
	
	
	}
	
}
