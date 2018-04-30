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
using BuildingSmart.IFC.IfcPropertyResource;

namespace BuildingSmart.IFC.IfcMaterialResource
{
	public partial class IfcMaterialLayer :
		BuildingSmart.IFC.IfcMaterialResource.IfcMaterialSelect,
		BuildingSmart.IFC.IfcPropertyResource.IfcObjectReferenceSelect
	{
		[DataMember(Order = 0)] 
		[Description("Optional reference to the material from which the layer is constructed. Note, that if this value is not given, it does not denote a layer with no material (an air gap), it only means that the material is not specified at that point.")]
		public IfcMaterial Material { get; set; }
	
		[DataMember(Order = 1)] 
		[XmlAttribute]
		[Description("The thickness of the layer (dimension measured along the local x-axis of Mls LCS, in positive direction).")]
		[Required()]
		public IfcPositiveLengthMeasure LayerThickness { get; set; }
	
		[DataMember(Order = 2)] 
		[XmlAttribute]
		[Description("<EPM-HTML>  Indication of whether the material layer represents an air layer (or cavity).   <ul>    <li>set to TRUE if the material layer is an air gap and provides air exchange from the layer to the outside air.</li>    <li>set to UNKNOWN if the material layer is an air gap and does not provide air exchange (or when this information about air exchange of the air gap is not available).</li>    <li>set to FALSE if the material layer is a solid material layer (the default).</li>   </ul>  </EPM-HTML>")]
		public IfcLogical? IsVentilated { get; set; }
	
		[InverseProperty("MaterialLayers")] 
		[Description("Reference to the material layer set, in which the material layer is included.")]
		public IfcMaterialLayerSet ToMaterialLayerSet { get; set; }
	
	
		public IfcMaterialLayer(IfcMaterial __Material, IfcPositiveLengthMeasure __LayerThickness, IfcLogical? __IsVentilated)
		{
			this.Material = __Material;
			this.LayerThickness = __LayerThickness;
			this.IsVentilated = __IsVentilated;
		}
	
	
	}
	
}
