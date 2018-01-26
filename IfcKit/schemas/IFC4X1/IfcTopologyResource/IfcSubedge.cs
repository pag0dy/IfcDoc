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
	[Guid("301f5c35-1bd3-43f4-8839-f47887d4d763")]
	public partial class IfcSubedge : IfcEdge
	{
		[DataMember(Order=0)] 
		[XmlElement]
		[Required()]
		IfcEdge _ParentEdge;
	
	
		public IfcSubedge()
		{
		}
	
		public IfcSubedge(IfcVertex __EdgeStart, IfcVertex __EdgeEnd, IfcEdge __ParentEdge)
			: base(__EdgeStart, __EdgeEnd)
		{
			this._ParentEdge = __ParentEdge;
		}
	
		[Description("The Edge, or Subedge, which contains the Subedge.")]
		public IfcEdge ParentEdge { get { return this._ParentEdge; } set { this._ParentEdge = value;} }
	
	
	}
	
}
