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

using BuildingSmart.IFC.IfcGeometryResource;
using BuildingSmart.IFC.IfcMeasureResource;
using BuildingSmart.IFC.IfcPresentationAppearanceResource;

namespace BuildingSmart.IFC.IfcTopologyResource
{
	[Guid("47c088c9-be86-473f-a8d3-cfc2f822e52d")]
	public partial class IfcEdge : IfcTopologicalRepresentationItem
	{
		[DataMember(Order=0)] 
		[XmlElement]
		[Required()]
		IfcVertex _EdgeStart;
	
		[DataMember(Order=1)] 
		[XmlElement]
		[Required()]
		IfcVertex _EdgeEnd;
	
	
		[Description("Start point (vertex) of the edge.\r\n")]
		public IfcVertex EdgeStart { get { return this._EdgeStart; } set { this._EdgeStart = value;} }
	
		[Description("End point (vertex) of the edge. The same vertex can be used for both EdgeStart an" +
	    "d EdgeEnd.\r\n")]
		public IfcVertex EdgeEnd { get { return this._EdgeEnd; } set { this._EdgeEnd = value;} }
	
	
	}
	
}
