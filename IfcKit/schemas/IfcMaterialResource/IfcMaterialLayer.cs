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

using BuildingSmart.IFC.IfcExternalReferenceResource;
using BuildingSmart.IFC.IfcMeasureResource;
using BuildingSmart.IFC.IfcProductExtension;
using BuildingSmart.IFC.IfcPropertyResource;

namespace BuildingSmart.IFC.IfcMaterialResource
{
	public partial class IfcMaterialLayer : IfcMaterialDefinition
	{
		[DataMember(Order = 0)] 
		[XmlElement]
		[Description("Optional reference to the material from which the layer is constructed. Note that if this value is not given, it does not denote a layer with no material (an air gap), it only means that the material is not specified at that point.")]
		public IfcMaterial Material { get; set; }
	
		[DataMember(Order = 1)] 
		[XmlAttribute]
		[Description("The thickness of the material layer. The meaning of \"thickness\" depends on its usage. In case of building elements elements utilizing <em>IfcMaterialLayerSetUsage</em>, the dimension is measured along the positive <em>LayerSetDirection</em> as specified in <em>IfcMaterialLayerSetUsage</em>.    <blockquote class=\"note\">NOTE&nbsp; The attribute value can be 0. for material thicknesses very close to zero, such as for a membrane. Material layers with thickess 0. may not be rendered in the geometric representation.</blockquote>  <blockquote class=\"change-ifc2x4\">IFC4 CHANGE&nbsp; The attribute datatype has been changed to <em>IfcNonNegativeLengthMeasure</em> allowing for 0. as thickness.</blockquote>")]
		[Required()]
		public IfcNonNegativeLengthMeasure LayerThickness { get; set; }
	
		[DataMember(Order = 2)] 
		[XmlAttribute]
		[Description("Indication of whether the material layer represents an air layer (or cavity).   <ul>    <li class=\"small\">set to TRUE if the material layer is an air gap and provides air exchange from the layer to the outside air.</li>    <li class=\"small\">set to UNKNOWN if the material layer is an air gap and does not provide air exchange (or when this information about air exchange of the air gap is not available).</li>    <li class=\"small\">set to FALSE if the material layer is a solid material layer (the default).</li>   </ul>")]
		public IfcLogical? IsVentilated { get; set; }
	
		[DataMember(Order = 3)] 
		[XmlAttribute]
		[Description("The name by which the material layer is known.")]
		public IfcLabel? Name { get; set; }
	
		[DataMember(Order = 4)] 
		[XmlAttribute]
		[Description("Definition of the material layer in more descriptive terms than given by attributes Name or Category.")]
		public IfcText? Description { get; set; }
	
		[DataMember(Order = 5)] 
		[XmlAttribute]
		[Description("Category of the material layer, e.g. the role it has in the layer set it belongs to (such as 'load bearing', 'thermal insulation' etc.). The list of keywords might be extended by model view definitions, however the following keywords shall apply in general:  <ul>   <li class=\"small\">'LoadBearing' &mdash; for all material layers having a load bearing function.</li>   <li class=\"small\">'Insulation' &mdash; for all material layers having an insolating function. </li>   <li class=\"small\">'Finish' &mdash; for the material layer being the inner or outer finish.</li>  </ul>")]
		public IfcLabel? Category { get; set; }
	
		[DataMember(Order = 6)] 
		[XmlAttribute]
		[Description("The relative priority of the layer, expressed as normalised integer range [0..100]. Controls how layers intersect in connections and corners of building elements: a layer from one element protrudes into (i.e. displaces) a layer from another element in a joint of these elements if the former element's layer has higher priority than the latter. The priority value for a material layer in an element has to be set and maintained by software applications in relation to the material layers in connected elements.    <blockquote class=\"note\">NOTE&nbsp; The layer priority at a connection may be overridden by the priority attributes of <em>IfcRelConnectsPathElements</em> if that relationship is used to establish a logical connection between two building elements having a layer structure.</blockquote>")]
		public IfcInteger? Priority { get; set; }
	
		[InverseProperty("MaterialLayers")] 
		[Description("Reference to the <em>IfcMaterialLayerSet</em> in which the material layer is included.")]
		public IfcMaterialLayerSet ToMaterialLayerSet { get; set; }
	
	
		public IfcMaterialLayer(IfcMaterial __Material, IfcNonNegativeLengthMeasure __LayerThickness, IfcLogical? __IsVentilated, IfcLabel? __Name, IfcText? __Description, IfcLabel? __Category, IfcInteger? __Priority)
		{
			this.Material = __Material;
			this.LayerThickness = __LayerThickness;
			this.IsVentilated = __IsVentilated;
			this.Name = __Name;
			this.Description = __Description;
			this.Category = __Category;
			this.Priority = __Priority;
		}
	
	
	}
	
}
