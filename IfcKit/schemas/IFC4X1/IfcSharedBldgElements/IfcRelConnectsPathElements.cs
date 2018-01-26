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
using BuildingSmart.IFC.IfcProductExtension;
using BuildingSmart.IFC.IfcUtilityResource;

namespace BuildingSmart.IFC.IfcSharedBldgElements
{
	[Guid("801d751c-7dbf-4a3c-a799-223323377272")]
	public partial class IfcRelConnectsPathElements : IfcRelConnectsElements
	{
		[DataMember(Order=0)] 
		[XmlAttribute]
		[Required()]
		IList<IfcInteger> _RelatingPriorities = new List<IfcInteger>();
	
		[DataMember(Order=1)] 
		[XmlAttribute]
		[Required()]
		IList<IfcInteger> _RelatedPriorities = new List<IfcInteger>();
	
		[DataMember(Order=2)] 
		[XmlAttribute]
		[Required()]
		IfcConnectionTypeEnum _RelatedConnectionType;
	
		[DataMember(Order=3)] 
		[XmlAttribute]
		[Required()]
		IfcConnectionTypeEnum _RelatingConnectionType;
	
	
		public IfcRelConnectsPathElements()
		{
		}
	
		public IfcRelConnectsPathElements(IfcGloballyUniqueId __GlobalId, IfcOwnerHistory __OwnerHistory, IfcLabel? __Name, IfcText? __Description, IfcConnectionGeometry __ConnectionGeometry, IfcElement __RelatingElement, IfcElement __RelatedElement, IfcInteger[] __RelatingPriorities, IfcInteger[] __RelatedPriorities, IfcConnectionTypeEnum __RelatedConnectionType, IfcConnectionTypeEnum __RelatingConnectionType)
			: base(__GlobalId, __OwnerHistory, __Name, __Description, __ConnectionGeometry, __RelatingElement, __RelatedElement)
		{
			this._RelatingPriorities = new List<IfcInteger>(__RelatingPriorities);
			this._RelatedPriorities = new List<IfcInteger>(__RelatedPriorities);
			this._RelatedConnectionType = __RelatedConnectionType;
			this._RelatingConnectionType = __RelatingConnectionType;
		}
	
		[Description(@"Overriding priorities at this connection. It overrides the standard priority given at the wall layer provided by <em>IfcMaterialLayer</em>.<em>Priority</em>. The list of <em>RelatingProperties</em> corresponds to the list of <em>IfcMaterialLayerSet</em>.<em>MaterialLayers</em> of the element referenced by <em>RelatingObject</em>.
	<blockquote class=""change-ifc2x4"">
	IFC4 CHANGE&nbsp; Data type changed to NUMBER and usage to hold a normalized ratio measure [0..1].
	</blockquote>")]
		public IList<IfcInteger> RelatingPriorities { get { return this._RelatingPriorities; } }
	
		[Description(@"Overriding priorities at this connection. It overrides the standard priority given at the wall layer provided by <em>IfcMaterialLayer</em>.<em>Priority</em>. The list of <em>RelatedProperties</em> corresponds to the list of <em>IfcMaterialLayerSet</em>.<em>MaterialLayers</em> of the element referenced by <em>RelatedObject</em>.
	<blockquote class=""change-ifc2x4"">
	IFC4 CHANGE&nbsp; Data type changed to NUMBER and usage to hold a normalized ratio measure [0..1].
	</blockquote>")]
		public IList<IfcInteger> RelatedPriorities { get { return this._RelatedPriorities; } }
	
		[Description("Indication of the connection type in relation to the path of the <em>RelatingObje" +
	    "ct</em>.\r\n")]
		public IfcConnectionTypeEnum RelatedConnectionType { get { return this._RelatedConnectionType; } set { this._RelatedConnectionType = value;} }
	
		[Description("Indication of the connection type in relation to the path of the <em>RelatingObje" +
	    "ct</em>.\r\n")]
		public IfcConnectionTypeEnum RelatingConnectionType { get { return this._RelatingConnectionType; } set { this._RelatingConnectionType = value;} }
	
	
	}
	
}
