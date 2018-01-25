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
	[Guid("c43b29f0-fa72-4a7c-a838-670ae11ec004")]
	public partial class IfcSurfaceStyleRefraction : IfcPresentationItem,
		BuildingSmart.IFC.IfcPresentationAppearanceResource.IfcSurfaceStyleElementSelect
	{
		[DataMember(Order=0)] 
		[XmlAttribute]
		IfcReal? _RefractionIndex;
	
		[DataMember(Order=1)] 
		[XmlAttribute]
		IfcReal? _DispersionFactor;
	
	
		[Description("The index of refraction for all wave lengths of light. The refraction index is th" +
	    "e ratio between the speed of light in a vacuum and the speed of light in the med" +
	    "ium. E.g. glass has a refraction index of 1.5, whereas water has an index of 1.3" +
	    "3")]
		public IfcReal? RefractionIndex { get { return this._RefractionIndex; } set { this._RefractionIndex = value;} }
	
		[Description("The Abbe constant given as a fixed ratio between the refractive indices of the ma" +
	    "terial at different wavelengths. A low Abbe number means a high dispersive power" +
	    ". In general this translates to a greater angular spread of the emergent spectru" +
	    "m.")]
		public IfcReal? DispersionFactor { get { return this._DispersionFactor; } set { this._DispersionFactor = value;} }
	
	
	}
	
}
