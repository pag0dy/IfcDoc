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

using BuildingSmart.IFC.IfcGeometricModelResource;
using BuildingSmart.IFC.IfcGeometryResource;
using BuildingSmart.IFC.IfcKernel;
using BuildingSmart.IFC.IfcMeasureResource;
using BuildingSmart.IFC.IfcPresentationAppearanceResource;
using BuildingSmart.IFC.IfcProductExtension;
using BuildingSmart.IFC.IfcProfileResource;
using BuildingSmart.IFC.IfcTopologyResource;

namespace BuildingSmart.IFC.IfcGeometricConstraintResource
{
	[Guid("0b7a3b78-5844-48d7-8cfa-af35fa085e67")]
	public partial class IfcConnectionVolumeGeometry : IfcConnectionGeometry
	{
		[DataMember(Order=0)] 
		[Required()]
		IfcSolidOrShell _VolumeOnRelatingElement;
	
		[DataMember(Order=1)] 
		IfcSolidOrShell _VolumeOnRelatedElement;
	
	
		[Description("<EPM-HTML>\r\nVolume at which related object overlaps with the relating element, gi" +
	    "ven in the LCS of the relating element.\r\n</EPM-HTML>")]
		public IfcSolidOrShell VolumeOnRelatingElement { get { return this._VolumeOnRelatingElement; } set { this._VolumeOnRelatingElement = value;} }
	
		[Description("<EPM-HTML>\r\nVolume at which related object overlaps with the relating element, gi" +
	    "ven in the LCS of the related element.\r\n</EPM-HTML>")]
		public IfcSolidOrShell VolumeOnRelatedElement { get { return this._VolumeOnRelatedElement; } set { this._VolumeOnRelatedElement = value;} }
	
	
	}
	
}
