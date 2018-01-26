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
using BuildingSmart.IFC.IfcTopologyResource;

namespace BuildingSmart.IFC.IfcGeometricModelResource
{
	[Guid("c5319aaa-961e-4cc6-804c-662e631fb696")]
	public partial class IfcFacetedBrepWithVoids : IfcManifoldSolidBrep
	{
		[DataMember(Order=0)] 
		[Required()]
		[MinLength(1)]
		ISet<IfcClosedShell> _Voids = new HashSet<IfcClosedShell>();
	
	
		public IfcFacetedBrepWithVoids()
		{
		}
	
		public IfcFacetedBrepWithVoids(IfcClosedShell __Outer, IfcClosedShell[] __Voids)
			: base(__Outer)
		{
			this._Voids = new HashSet<IfcClosedShell>(__Voids);
		}
	
		[Description("Set of closed shells defining voids within the solid.")]
		public ISet<IfcClosedShell> Voids { get { return this._Voids; } }
	
	
	}
	
}
