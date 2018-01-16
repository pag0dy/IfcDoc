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

namespace BuildingSmart.IFC.IfcTopologyResource
{
	[Guid("e82ce556-c7d7-4d71-80e1-f4a2a7af3ec0")]
	public partial class IfcEdgeLoop : IfcLoop
	{
		[DataMember(Order=0)] 
		[Required()]
		IList<IfcOrientedEdge> _EdgeList = new List<IfcOrientedEdge>();
	
	
		[Description("A list of oriented edge entities which are concatenated together to form this pat" +
	    "h.")]
		public IList<IfcOrientedEdge> EdgeList { get { return this._EdgeList; } }
	
		public new Int64 Ne { get { return null; } }
	
	
	}
	
}
