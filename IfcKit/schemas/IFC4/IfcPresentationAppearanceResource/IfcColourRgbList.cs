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
	[Guid("02b8b9ac-609f-4e13-8a54-94743a93eebf")]
	public partial class IfcColourRgbList : IfcPresentationItem
	{
		[DataMember(Order=0)] 
		[Required()]
		IList<IfcNormalisedRatioMeasure> _ColourList = new List<IfcNormalisedRatioMeasure>();
	
	
		[Description("<EPM-HTML>\r\nList of colours defined by the red, green and blue component.\r\n</EPM-" +
	    "HTML>")]
		public IList<IfcNormalisedRatioMeasure> ColourList { get { return this._ColourList; } }
	
	
	}
	
}
