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

using BuildingSmart.IFC.IfcExternalReferenceResource;
using BuildingSmart.IFC.IfcGeometricModelResource;
using BuildingSmart.IFC.IfcGeometryResource;
using BuildingSmart.IFC.IfcMeasureResource;
using BuildingSmart.IFC.IfcPresentationDefinitionResource;
using BuildingSmart.IFC.IfcTopologyResource;

namespace BuildingSmart.IFC.IfcPresentationAppearanceResource
{
	[Guid("8495cfb3-40da-4a4e-8481-67e0000fb8d2")]
	public partial class IfcFillAreaStyle : IfcPresentationStyle,
		BuildingSmart.IFC.IfcPresentationAppearanceResource.IfcPresentationStyleSelect
	{
		[DataMember(Order=0)] 
		[Required()]
		ISet<IfcFillStyleSelect> _FillStyles = new HashSet<IfcFillStyleSelect>();
	
		[DataMember(Order=1)] 
		Boolean? _ModelorDraughting;
	
	
		[Description("The set of fill area styles to use in presenting visible curve segments, annotati" +
	    "on fill areas or surfaces.")]
		public ISet<IfcFillStyleSelect> FillStyles { get { return this._FillStyles; } }
	
		[Description("<EPM-HTML>\r\nIndication whether the length measures provided for the presentation " +
	    "style are model based, or draughting based.\r\n<blockquote class=\"change-ifc2x4\">I" +
	    "FC4 CHANGE&nbsp; New attribute.\r\n</blockquote>\r\n</EPM-HTML>")]
		public Boolean? ModelorDraughting { get { return this._ModelorDraughting; } set { this._ModelorDraughting = value;} }
	
	
	}
	
}
