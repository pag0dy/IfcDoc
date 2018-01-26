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
using BuildingSmart.IFC.IfcMeasureResource;
using BuildingSmart.IFC.IfcPresentationAppearanceResource;
using BuildingSmart.IFC.IfcPresentationOrganizationResource;

namespace BuildingSmart.IFC.IfcPresentationResource
{
	[Guid("0bb8d7c4-dfce-4f64-aca2-e17ba0069393")]
	public partial class IfcPlanarBox : IfcPlanarExtent
	{
		[DataMember(Order=0)] 
		[Required()]
		IfcAxis2Placement _Placement;
	
	
		public IfcPlanarBox()
		{
		}
	
		public IfcPlanarBox(IfcLengthMeasure __SizeInX, IfcLengthMeasure __SizeInY, IfcAxis2Placement __Placement)
			: base(__SizeInX, __SizeInY)
		{
			this._Placement = __Placement;
		}
	
		[Description(@"<EPM-HTML>
	The <i>IfcAxis2Placement</i> positions a local coordinate system for the definition of the rectangle. The origin of this local coordinate system serves as the lower left corner of the rectangular box.
	  <blockquote> <small>NOTE&nbsp; In case of a 3D placement by <i>IfcAxisPlacement3D the <i>IfcPlanarBox</i> is defined within the xy plane of the definition coordinate system.</small></blockquote>
	</EPM-HTML>")]
		public IfcAxis2Placement Placement { get { return this._Placement; } set { this._Placement = value;} }
	
	
	}
	
}
