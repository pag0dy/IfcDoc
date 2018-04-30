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

using BuildingSmart.IFC.IfcGeometricConstraintResource;
using BuildingSmart.IFC.IfcGeometryResource;
using BuildingSmart.IFC.IfcMeasureResource;
using BuildingSmart.IFC.IfcPresentationAppearanceResource;
using BuildingSmart.IFC.IfcPresentationOrganizationResource;
using BuildingSmart.IFC.IfcProfileResource;

namespace BuildingSmart.IFC.IfcGeometricModelResource
{
	public partial class IfcSectionedSolidHorizontal : IfcSectionedSolid
	{
		[DataMember(Order = 0)] 
		[Description("List of distance expressions in sequentially increasing order paired with <i>CrossSections</i>, indicating the position of the corresponding section along the <i>Directrix</i>.")]
		[Required()]
		[MinLength(2)]
		public IList<IfcDistanceExpression> CrossSectionPositions { get; protected set; }
	
		[DataMember(Order = 1)] 
		[XmlAttribute]
		[Description("Indicates whether <i>Sections</i> are oriented with the Y axis of each profile facing upwards in +Z direction (True), or vertically perpendicular to the <i>Directrix</i> varying according to slope (False).  ")]
		[Required()]
		public IfcBoolean FixedAxisVertical { get; set; }
	
	
		public IfcSectionedSolidHorizontal(IfcCurve __Directrix, IfcProfileDef[] __CrossSections, IfcDistanceExpression[] __CrossSectionPositions, IfcBoolean __FixedAxisVertical)
			: base(__Directrix, __CrossSections)
		{
			this.CrossSectionPositions = new List<IfcDistanceExpression>(__CrossSectionPositions);
			this.FixedAxisVertical = __FixedAxisVertical;
		}
	
	
	}
	
}
