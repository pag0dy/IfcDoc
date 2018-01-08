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
using BuildingSmart.IFC.IfcGeometricModelResource;
using BuildingSmart.IFC.IfcGeometryResource;
using BuildingSmart.IFC.IfcKernel;
using BuildingSmart.IFC.IfcMaterialResource;
using BuildingSmart.IFC.IfcMeasureResource;
using BuildingSmart.IFC.IfcPresentationAppearanceResource;
using BuildingSmart.IFC.IfcProductExtension;
using BuildingSmart.IFC.IfcPropertyResource;
using BuildingSmart.IFC.IfcRepresentationResource;

namespace BuildingSmart.IFC.IfcSharedBldgElements
{
	[Guid("801d751c-7dbf-4a3c-a799-223323377272")]
	public partial class IfcRelConnectsPathElements : IfcRelConnectsElements
	{
		[DataMember(Order=0)] 
		[Required()]
		IList<Decimal> _RelatingPriorities = new List<Decimal>();
	
		[DataMember(Order=1)] 
		[Required()]
		IList<Decimal> _RelatedPriorities = new List<Decimal>();
	
		[DataMember(Order=2)] 
		[XmlAttribute]
		[Required()]
		IfcConnectionTypeEnum _RelatedConnectionType;
	
		[DataMember(Order=3)] 
		[XmlAttribute]
		[Required()]
		IfcConnectionTypeEnum _RelatingConnectionType;
	
	
		[Description(@"<EPM-HTML>
	Overriding priorities at this connection. It overrides the standard priority given at the wall layer provided by <em>IfcMaterialLayer</em>.<em>Priority</em>. The list of <em>RelatingProperties</em> corresponds to the list of <em>IfcMaterialLayerSet</em>.<em>MaterialLayers</em> of the element referenced by <em>RelatingObject</em>.
	<blockquote class=""change-ifc2x4"">
	IFC4 CHANGE&nbsp; Data type changed to NUMBER and usage to hold a normalized ratio measure [0..1].
	</blockquote>
	</EPM-HTML>")]
		public IList<Decimal> RelatingPriorities { get { return this._RelatingPriorities; } }
	
		[Description(@"<EPM-HTML>
	Overriding priorities at this connection. It overrides the standard priority given at the wall layer provided by <em>IfcMaterialLayer</em>.<em>Priority</em>. The list of <em>RelatedProperties</em> corresponds to the list of <em>IfcMaterialLayerSet</em>.<em>MaterialLayers</em> of the element referenced by <em>RelatedObject</em>.
	<blockquote class=""change-ifc2x4"">
	IFC4 CHANGE&nbsp; Data type changed to NUMBER and usage to hold a normalized ratio measure [0..1].
	</blockquote>
	</EPM-HTML>")]
		public IList<Decimal> RelatedPriorities { get { return this._RelatedPriorities; } }
	
		[Description("Indication of the connection type in relation to the path of the RelatingObject.\r" +
	    "\n")]
		public IfcConnectionTypeEnum RelatedConnectionType { get { return this._RelatedConnectionType; } set { this._RelatedConnectionType = value;} }
	
		[Description("Indication of the connection type in relation to the path of the RelatingObject.\r" +
	    "\n")]
		public IfcConnectionTypeEnum RelatingConnectionType { get { return this._RelatingConnectionType; } set { this._RelatingConnectionType = value;} }
	
	
	}
	
}
