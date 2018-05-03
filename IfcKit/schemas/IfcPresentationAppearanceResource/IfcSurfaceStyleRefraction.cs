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

using BuildingSmart.IFC.IfcMeasureResource;
using BuildingSmart.IFC.IfcPresentationDefinitionResource;

namespace BuildingSmart.IFC.IfcPresentationAppearanceResource
{
	public partial class IfcSurfaceStyleRefraction : IfcPresentationItem,
		BuildingSmart.IFC.IfcPresentationAppearanceResource.IfcSurfaceStyleElementSelect
	{
		[DataMember(Order = 0)] 
		[XmlAttribute]
		[Description("The index of refraction for all wave lengths of light. The refraction index is the ratio between the speed of light in a vacuum and the speed of light in the medium. E.g. glass has a refraction index of 1.5, whereas water has an index of 1.33")]
		public IfcReal? RefractionIndex { get; set; }
	
		[DataMember(Order = 1)] 
		[XmlAttribute]
		[Description("The Abbe constant given as a fixed ratio between the refractive indices of the material at different wavelengths. A low Abbe number means a high dispersive power. In general this translates to a greater angular spread of the emergent spectrum.")]
		public IfcReal? DispersionFactor { get; set; }
	
	
		public IfcSurfaceStyleRefraction(IfcReal? __RefractionIndex, IfcReal? __DispersionFactor)
		{
			this.RefractionIndex = __RefractionIndex;
			this.DispersionFactor = __DispersionFactor;
		}
	
	
	}
	
}
