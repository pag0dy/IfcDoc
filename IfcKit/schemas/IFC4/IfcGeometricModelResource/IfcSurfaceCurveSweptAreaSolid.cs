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
using BuildingSmart.IFC.IfcProfileResource;
using BuildingSmart.IFC.IfcTopologyResource;

namespace BuildingSmart.IFC.IfcGeometricModelResource
{
	[Guid("3c76b659-a30a-44af-a964-3f20d2e22949")]
	public partial class IfcSurfaceCurveSweptAreaSolid : IfcSweptAreaSolid
	{
		[DataMember(Order=0)] 
		[XmlElement("IfcCurve")]
		[Required()]
		IfcCurve _Directrix;
	
		[DataMember(Order=1)] 
		[XmlAttribute]
		IfcParameterValue? _StartParam;
	
		[DataMember(Order=2)] 
		[XmlAttribute]
		IfcParameterValue? _EndParam;
	
		[DataMember(Order=3)] 
		[XmlElement("IfcSurface")]
		[Required()]
		IfcSurface _ReferenceSurface;
	
	
		[Description("<EPM-HTML>\r\nThe curve used to define the sweeping operation. The solid is generat" +
	    "ed by sweeping the <em>SELF\\IfcSweptAreaSolid.SweptArea</em> along the <em>Direc" +
	    "trix</em>.\r\n</EPM-HTML>")]
		public IfcCurve Directrix { get { return this._Directrix; } set { this._Directrix = value;} }
	
		[Description(@"<EPM-HTML>
	The parameter value on the <em>Directrix</em> at which the sweeping operation commences. If no value is provided the start of the sweeping operation is at the start of the <em>Directrix</em>.
	<blockquote class=""change-ifc2x4"">IFC4 CHANGE&nbsp; The attribute has been changed to OPTIONAL with upward compatibility for file-based exchange.</blockquote>
	</EPM-HTML>")]
		public IfcParameterValue? StartParam { get { return this._StartParam; } set { this._StartParam = value;} }
	
		[Description(@"<EPM-HTML>
	The parameter value on the <em>Directrix</em> at which the sweeping operation ends. If no value is provided the end of the sweeping operation is at the end of the <em>Directrix</em>.
	<blockquote class=""change-ifc2x4"">IFC4 CHANGE&nbsp; The attribute has been changed to OPTIONAL with upward compatibility for file-based exchange.</blockquote>
	</EPM-HTML>")]
		public IfcParameterValue? EndParam { get { return this._EndParam; } set { this._EndParam = value;} }
	
		[Description("<EPM-HTML>\r\nThe surface containing the <em>Directrix</em>.\r\n</EPM-HTML>")]
		public IfcSurface ReferenceSurface { get { return this._ReferenceSurface; } set { this._ReferenceSurface = value;} }
	
	
	}
	
}
