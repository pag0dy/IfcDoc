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
	public partial class IfcPlanarBox : IfcPlanarExtent
	{
		[DataMember(Order = 0)] 
		[Description("The <em>IfcAxis2Placement</em> positions a local coordinate system for the definition of the rectangle. The origin of this local coordinate system serves as the lower left corner of the rectangular box.    <blockquote class=\"note\">NOTE&nbsp; In case of a 3D placement by <em>IfcAxisPlacement3D the <em>IfcPlanarBox</em> is defined within the xy plane of the definition coordinate system.</blockquote>")]
		[Required()]
		public IfcAxis2Placement Placement { get; set; }
	
	
		public IfcPlanarBox(IfcLengthMeasure __SizeInX, IfcLengthMeasure __SizeInY, IfcAxis2Placement __Placement)
			: base(__SizeInX, __SizeInY)
		{
			this.Placement = __Placement;
		}
	
	
	}
	
}
