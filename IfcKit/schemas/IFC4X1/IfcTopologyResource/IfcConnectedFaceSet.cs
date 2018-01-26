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
	[Guid("00739840-0188-4605-bb14-19851c954616")]
	public partial class IfcConnectedFaceSet : IfcTopologicalRepresentationItem
	{
		[DataMember(Order=0)] 
		[Required()]
		[MinLength(1)]
		ISet<IfcFace> _CfsFaces = new HashSet<IfcFace>();
	
	
		public IfcConnectedFaceSet()
		{
		}
	
		public IfcConnectedFaceSet(IfcFace[] __CfsFaces)
		{
			this._CfsFaces = new HashSet<IfcFace>(__CfsFaces);
		}
	
		[Description("The set of faces arcwise connected along common edges or vertices.")]
		public ISet<IfcFace> CfsFaces { get { return this._CfsFaces; } }
	
	
	}
	
}
