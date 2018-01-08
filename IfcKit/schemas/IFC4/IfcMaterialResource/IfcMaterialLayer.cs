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
using BuildingSmart.IFC.IfcGeometryResource;
using BuildingSmart.IFC.IfcMeasureResource;
using BuildingSmart.IFC.IfcPresentationAppearanceResource;
using BuildingSmart.IFC.IfcProductExtension;
using BuildingSmart.IFC.IfcProfileResource;
using BuildingSmart.IFC.IfcPropertyResource;
using BuildingSmart.IFC.IfcRepresentationResource;

namespace BuildingSmart.IFC.IfcMaterialResource
{
	[Guid("1550d694-6c4a-46c4-9661-12b1956f035d")]
	public partial class IfcMaterialLayer : IfcMaterialDefinition
	{
		[DataMember(Order=0)] 
		[XmlElement("IfcMaterial")]
		IfcMaterial _Material;
	
		[DataMember(Order=1)] 
		[XmlAttribute]
		[Required()]
		IfcNonNegativeLengthMeasure _LayerThickness;
	
		[DataMember(Order=2)] 
		[XmlAttribute]
		IfcLogical? _IsVentilated;
	
		[DataMember(Order=3)] 
		[XmlAttribute]
		IfcLabel? _Name;
	
		[DataMember(Order=4)] 
		[XmlAttribute]
		IfcText? _Description;
	
		[DataMember(Order=5)] 
		[XmlAttribute]
		IfcLabel? _Category;
	
		[DataMember(Order=6)] 
		[XmlAttribute]
		IfcInteger? _Priority;
	
		[InverseProperty("MaterialLayers")] 
		IfcMaterialLayerSet _ToMaterialLayerSet;
	
	
		[Description("Optional reference to the material from which the layer is constructed. Note that" +
	    " if this value is not given, it does not denote a layer with no material (an air" +
	    " gap), it only means that the material is not specified at that point.")]
		public IfcMaterial Material { get { return this._Material; } set { this._Material = value;} }
	
		[Description(@"The thickness of the material layer. The meaning of ""thickness"" depends on its usage. In case of building elements elements utilizing <em>IfcMaterialLayerSetUsage</em>, the dimension is measured along the positive <em>LayerSetDirection</em> as specified in <em>IfcMaterialLayerSetUsage</em>.
	
	<blockquote class=""note"">NOTE&nbsp; The attribute value can be 0. for material thicknesses very close to zero, such as for a membrane. Material layers with thickess 0. may not be rendered in the geometric representation.</blockquote>
	<blockquote class=""change-ifc2x4"">IFC4 CHANGE&nbsp; The attribute datatype has been changed to <em>IfcNonNegativeLengthMeasure</em> allowing for 0. as thickness.</blockquote>")]
		public IfcNonNegativeLengthMeasure LayerThickness { get { return this._LayerThickness; } set { this._LayerThickness = value;} }
	
		[Description(@"Indication of whether the material layer represents an air layer (or cavity). 
	<ul>
	  <li>set to TRUE if the material layer is an air gap and provides air exchange from the layer to the outside air.</li>
	  <li>set to UNKNOWN if the material layer is an air gap and does not provide air exchange (or when this information about air exchange of the air gap is not available).</li>
	  <li>set to FALSE if the material layer is a solid material layer (the default).</li> 
	</ul>")]
		public IfcLogical? IsVentilated { get { return this._IsVentilated; } set { this._IsVentilated = value;} }
	
		[Description("The name by which the material layer is known.")]
		public IfcLabel? Name { get { return this._Name; } set { this._Name = value;} }
	
		[Description("Definition of the material layer in more descriptive terms than given by attribut" +
	    "es Name or Category.")]
		public IfcText? Description { get { return this._Description; } set { this._Description = value;} }
	
		[Description(@"Category of the material layer, e.g. the role it has in the layer set it belongs to (such as 'load bearing', 'thermal insulation' etc.). The list of keywords might be extended by model view definitions, however the following keywords shall apply in general:
	<ul>
	 <li>'Load Bearing' &mdash; for all material layers having a load bearing function.</li>
	 <li>'Insulation' &mdash; for all material layers having an insolating function. </li>
	 <li>'Inner finish' &mdash; for the material layer being the inner finish.</li>
	 <li>'Outer finish' &mdash; for the material layer being the outer finish.</li>
	</ul>")]
		public IfcLabel? Category { get { return this._Category; } set { this._Category = value;} }
	
		[Description(@"The relative priority of the layer, expressed as normalised integer range [0..100]. Controls how layers intersect in connections and corners of building elements: a layer from one element protrudes into (i.e. displaces) a layer from another element in a joint of these elements if the former element's layer has higher priority than the latter. The priority value for a material layer in an element has to be set and maintained by software applications in relation to the material layers in connected elements.
	
	<blockquote class=""note"">NOTE&nbsp; The layer priority at a connection may be overridden by the priority attributes of <em>IfcRelConnectsPathElements</em> if that relationship is used to establish a logical connection between two building elements having a layer structure.</blockquote>")]
		public IfcInteger? Priority { get { return this._Priority; } set { this._Priority = value;} }
	
		[Description("Reference to the <em>IfcMaterialLayerSet</em> in which the material layer is incl" +
	    "uded.")]
		public IfcMaterialLayerSet ToMaterialLayerSet { get { return this._ToMaterialLayerSet; } set { this._ToMaterialLayerSet = value;} }
	
	
	}
	
}
