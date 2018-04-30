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

namespace BuildingSmart.IFC.IfcPresentationResource
{
	public partial class IfcPlanarBox : IfcPlanarExtent
	{
		[DataMember(Order = 0)] 
		[Description("<EPM-HTML>  The <i>IfcAxis2Placement</i> positions a local coordinate system for the definition of the rectangle. The origin of this local coordinate system serves as the lower left corner of the rectangular box.    <blockquote> <small>NOTE&nbsp; In case of a 3D placement by <i>IfcAxisPlacement3D the <i>IfcPlanarBox</i> is defined within the xy plane of the definition coordinate system.</small></blockquote>  </EPM-HTML>")]
		[Required()]
		public IfcAxis2Placement Placement { get; set; }
	
	
		public IfcPlanarBox(IfcLengthMeasure __SizeInX, IfcLengthMeasure __SizeInY, IfcAxis2Placement __Placement)
			: base(__SizeInX, __SizeInY)
		{
			this.Placement = __Placement;
		}
	
	
	}
	
}
