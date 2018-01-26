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
	
	
		public IfcConnectionVolumeGeometry()
		{
		}
	
		public IfcConnectionVolumeGeometry(IfcSolidOrShell __VolumeOnRelatingElement, IfcSolidOrShell __VolumeOnRelatedElement)
		{
			this._VolumeOnRelatingElement = __VolumeOnRelatingElement;
			this._VolumeOnRelatedElement = __VolumeOnRelatedElement;
		}
	
		[Description("Volume at which related object overlaps with the relating element, given in the L" +
	    "CS of the relating element.")]
		public IfcSolidOrShell VolumeOnRelatingElement { get { return this._VolumeOnRelatingElement; } set { this._VolumeOnRelatingElement = value;} }
	
		[Description("Volume at which related object overlaps with the relating element, given in the L" +
	    "CS of the related element.")]
		public IfcSolidOrShell VolumeOnRelatedElement { get { return this._VolumeOnRelatedElement; } set { this._VolumeOnRelatedElement = value;} }
	
	
	}
	
}
