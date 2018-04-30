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

namespace BuildingSmart.IFC.IfcGeometricModelResource
{
	public partial class IfcGeometricSet : IfcGeometricRepresentationItem
	{
		[DataMember(Order = 0)] 
		[Description("The geometric elements which make up the geometric set, these may be points, curves or surfaces; but are required to be of the same coordinate space dimensionality.")]
		[Required()]
		[MinLength(1)]
		public ISet<IfcGeometricSetSelect> Elements { get; protected set; }
	
	
		public IfcGeometricSet(IfcGeometricSetSelect[] __Elements)
		{
			this.Elements = new HashSet<IfcGeometricSetSelect>(__Elements);
		}
	
		public new IfcDimensionCount Dim { get { return new IfcDimensionCount(); } }
	
	
	}
	
}
