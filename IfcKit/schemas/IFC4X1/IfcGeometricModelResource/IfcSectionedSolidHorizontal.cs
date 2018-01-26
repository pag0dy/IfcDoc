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

using BuildingSmart.IFC.IfcGeometricConstraintResource;
using BuildingSmart.IFC.IfcGeometryResource;
using BuildingSmart.IFC.IfcMeasureResource;
using BuildingSmart.IFC.IfcPresentationAppearanceResource;
using BuildingSmart.IFC.IfcPresentationOrganizationResource;
using BuildingSmart.IFC.IfcProfileResource;

namespace BuildingSmart.IFC.IfcGeometricModelResource
{
	[Guid("f68a12da-ce0e-4612-b29e-5a806895b5c8")]
	public partial class IfcSectionedSolidHorizontal : IfcSectionedSolid
	{
		[DataMember(Order=0)] 
		[Required()]
		[MinLength(2)]
		IList<IfcDistanceExpression> _CrossSectionPositions = new List<IfcDistanceExpression>();
	
		[DataMember(Order=1)] 
		[XmlAttribute]
		[Required()]
		IfcBoolean _FixedAxisVertical;
	
	
		public IfcSectionedSolidHorizontal()
		{
		}
	
		public IfcSectionedSolidHorizontal(IfcCurve __Directrix, IfcProfileDef[] __CrossSections, IfcDistanceExpression[] __CrossSectionPositions, IfcBoolean __FixedAxisVertical)
			: base(__Directrix, __CrossSections)
		{
			this._CrossSectionPositions = new List<IfcDistanceExpression>(__CrossSectionPositions);
			this._FixedAxisVertical = __FixedAxisVertical;
		}
	
		[Description("List of distance expressions in sequentially increasing order paired with <i>Cros" +
	    "sSections</i>, indicating the position of the corresponding section along the <i" +
	    ">Directrix</i>.")]
		public IList<IfcDistanceExpression> CrossSectionPositions { get { return this._CrossSectionPositions; } }
	
		[Description("Indicates whether <i>Sections</i> are oriented with the Y axis of each profile fa" +
	    "cing upwards in +Z direction (True), or vertically perpendicular to the <i>Direc" +
	    "trix</i> varying according to slope (False).\r\n")]
		public IfcBoolean FixedAxisVertical { get { return this._FixedAxisVertical; } set { this._FixedAxisVertical = value;} }
	
	
	}
	
}
