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


namespace BuildingSmart.IFC.IfcGeometricConstraintResource
{
	public partial class IfcConnectionVolumeGeometry : IfcConnectionGeometry
	{
		[DataMember(Order = 0)] 
		[Description("Volume at which related object overlaps with the relating element, given in the LCS of the relating element.")]
		[Required()]
		public IfcSolidOrShell VolumeOnRelatingElement { get; set; }
	
		[DataMember(Order = 1)] 
		[Description("Volume at which related object overlaps with the relating element, given in the LCS of the related element.")]
		public IfcSolidOrShell VolumeOnRelatedElement { get; set; }
	
	
		public IfcConnectionVolumeGeometry(IfcSolidOrShell __VolumeOnRelatingElement, IfcSolidOrShell __VolumeOnRelatedElement)
		{
			this.VolumeOnRelatingElement = __VolumeOnRelatingElement;
			this.VolumeOnRelatedElement = __VolumeOnRelatedElement;
		}
	
	
	}
	
}
