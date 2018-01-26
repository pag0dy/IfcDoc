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
	[Guid("6b533111-cfa2-48bc-af7c-15b5debf8f5b")]
	public partial class IfcClosedShell : IfcConnectedFaceSet,
		BuildingSmart.IFC.IfcTopologyResource.IfcShell
	{
	
		public IfcClosedShell()
		{
		}
	
		public IfcClosedShell(IfcFace[] __CfsFaces)
			: base(__CfsFaces)
		{
		}
	
	
	}
	
}
