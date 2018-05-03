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
using BuildingSmart.IFC.IfcMeasureResource;
using BuildingSmart.IFC.IfcPresentationAppearanceResource;
using BuildingSmart.IFC.IfcPresentationOrganizationResource;

namespace BuildingSmart.IFC.IfcPresentationDefinitionResource
{
	public partial class IfcPlanarExtent : IfcGeometricRepresentationItem
	{
		[DataMember(Order = 0)] 
		[XmlAttribute]
		[Description("The extent in the direction of the x-axis.")]
		[Required()]
		public IfcLengthMeasure SizeInX { get; set; }
	
		[DataMember(Order = 1)] 
		[XmlAttribute]
		[Description("The extent in the direction of the y-axis.")]
		[Required()]
		public IfcLengthMeasure SizeInY { get; set; }
	
	
		public IfcPlanarExtent(IfcLengthMeasure __SizeInX, IfcLengthMeasure __SizeInY)
		{
			this.SizeInX = __SizeInX;
			this.SizeInY = __SizeInY;
		}
	
	
	}
	
}
