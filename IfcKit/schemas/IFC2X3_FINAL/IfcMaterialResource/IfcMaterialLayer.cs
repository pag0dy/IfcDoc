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
using BuildingSmart.IFC.IfcMeasureResource;
using BuildingSmart.IFC.IfcPresentationAppearanceResource;
using BuildingSmart.IFC.IfcPropertyResource;
using BuildingSmart.IFC.IfcRepresentationResource;

namespace BuildingSmart.IFC.IfcMaterialResource
{
	[Guid("7fdcceda-cca1-4604-8876-51db2b6c8548")]
	public partial class IfcMaterialLayer :
		BuildingSmart.IFC.IfcMaterialResource.IfcMaterialSelect,
		BuildingSmart.IFC.IfcPropertyResource.IfcObjectReferenceSelect
	{
		[DataMember(Order=0)] 
		IfcMaterial _Material;
	
		[DataMember(Order=1)] 
		[XmlAttribute]
		[Required()]
		IfcPositiveLengthMeasure _LayerThickness;
	
		[DataMember(Order=2)] 
		[XmlAttribute]
		IfcLogical? _IsVentilated;
	
		[InverseProperty("MaterialLayers")] 
		IfcMaterialLayerSet _ToMaterialLayerSet;
	
	
		[Description("Optional reference to the material from which the layer is constructed. Note, tha" +
	    "t if this value is not given, it does not denote a layer with no material (an ai" +
	    "r gap), it only means that the material is not specified at that point.")]
		public IfcMaterial Material { get { return this._Material; } set { this._Material = value;} }
	
		[Description("The thickness of the layer (dimension measured along the local x-axis of Mls LCS," +
	    " in positive direction).")]
		public IfcPositiveLengthMeasure LayerThickness { get { return this._LayerThickness; } set { this._LayerThickness = value;} }
	
		[Description(@"<EPM-HTML>
	Indication of whether the material layer represents an air layer (or cavity). 
	<ul>
	  <li>set to TRUE if the material layer is an air gap and provides air exchange from the layer to the outside air.</li>
	  <li>set to UNKNOWN if the material layer is an air gap and does not provide air exchange (or when this information about air exchange of the air gap is not available).</li>
	  <li>set to FALSE if the material layer is a solid material layer (the default).</li> 
	</ul>
	</EPM-HTML>")]
		public IfcLogical? IsVentilated { get { return this._IsVentilated; } set { this._IsVentilated = value;} }
	
		[Description("Reference to the material layer set, in which the material layer is included.")]
		public IfcMaterialLayerSet ToMaterialLayerSet { get { return this._ToMaterialLayerSet; } set { this._ToMaterialLayerSet = value;} }
	
	
	}
	
}
