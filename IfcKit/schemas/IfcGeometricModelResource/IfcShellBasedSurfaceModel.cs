// This file may be edited manually or auto-generated using IfcKit at www.buildingsmart-tech.org.
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
using BuildingSmart.IFC.IfcTopologyResource;

namespace BuildingSmart.IFC.IfcGeometricModelResource
{
	public partial class IfcShellBasedSurfaceModel : IfcGeometricRepresentationItem
	{
		[DataMember(Order = 0)] 
		[Required()]
		[MinLength(1)]
		public ISet<IfcShell> SbsmBoundary { get; protected set; }
	
	
		public IfcShellBasedSurfaceModel(IfcShell[] __SbsmBoundary)
		{
			this.SbsmBoundary = new HashSet<IfcShell>(__SbsmBoundary);
		}
	
		public new IfcDimensionCount Dim { get { return new IfcDimensionCount(); } }
	
	
	}
	
}
