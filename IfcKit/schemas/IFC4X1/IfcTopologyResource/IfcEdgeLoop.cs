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
	[Guid("1642dee1-9c3d-416b-86a9-db23ccf926ae")]
	public partial class IfcEdgeLoop : IfcLoop
	{
		[DataMember(Order=0)] 
		[Required()]
		IList<IfcOrientedEdge> _EdgeList = new List<IfcOrientedEdge>();
	
	
		[Description("A list of oriented edge entities which are concatenated together to form this pat" +
	    "h.")]
		public IList<IfcOrientedEdge> EdgeList { get { return this._EdgeList; } }
	
		public new IfcInteger Ne { get { return new IfcInteger(); } }
	
	
	}
	
}
