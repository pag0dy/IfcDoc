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
using BuildingSmart.IFC.IfcPresentationAppearanceResource;
using BuildingSmart.IFC.IfcPresentationOrganizationResource;

namespace BuildingSmart.IFC.IfcTopologyResource
{
	[Guid("eff397a5-b06c-4b05-bb01-450f0eb9d3fd")]
	public partial class IfcEdge : IfcTopologicalRepresentationItem
	{
		[DataMember(Order=0)] 
		[Required()]
		IfcVertex _EdgeStart;
	
		[DataMember(Order=1)] 
		[Required()]
		IfcVertex _EdgeEnd;
	
	
		public IfcEdge()
		{
		}
	
		public IfcEdge(IfcVertex __EdgeStart, IfcVertex __EdgeEnd)
		{
			this._EdgeStart = __EdgeStart;
			this._EdgeEnd = __EdgeEnd;
		}
	
		[Description("Start point (vertex) of the edge.\r\n")]
		public IfcVertex EdgeStart { get { return this._EdgeStart; } set { this._EdgeStart = value;} }
	
		[Description("End point (vertex) of the edge. The same vertex can be used for both EdgeStart an" +
	    "d EdgeEnd.\r\n")]
		public IfcVertex EdgeEnd { get { return this._EdgeEnd; } set { this._EdgeEnd = value;} }
	
	
	}
	
}
