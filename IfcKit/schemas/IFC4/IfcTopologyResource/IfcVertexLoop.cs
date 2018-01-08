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
	[Guid("492ce60a-9294-46dd-85f5-c8937e2f84fe")]
	public partial class IfcVertexLoop : IfcLoop
	{
		[DataMember(Order=0)] 
		[XmlElement("IfcVertex")]
		[Required()]
		IfcVertex _LoopVertex;
	
	
		[Description("The vertex which defines the entire loop.")]
		public IfcVertex LoopVertex { get { return this._LoopVertex; } set { this._LoopVertex = value;} }
	
	
	}
	
}
