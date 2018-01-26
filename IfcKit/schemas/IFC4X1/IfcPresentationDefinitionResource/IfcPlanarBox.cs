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

namespace BuildingSmart.IFC.IfcPresentationDefinitionResource
{
	[Guid("bec0a45e-76ad-42eb-9bc8-d02b405ab69b")]
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
	
		[Description(@"The <em>IfcAxis2Placement</em> positions a local coordinate system for the definition of the rectangle. The origin of this local coordinate system serves as the lower left corner of the rectangular box.
	  <blockquote class=""note"">NOTE&nbsp; In case of a 3D placement by <em>IfcAxisPlacement3D the <em>IfcPlanarBox</em> is defined within the xy plane of the definition coordinate system.</blockquote>")]
		public IfcAxis2Placement Placement { get { return this._Placement; } set { this._Placement = value;} }
	
	
	}
	
}
